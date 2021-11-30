using eDataAccess.Security;
using eFramework;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class Usuarios : ObjetoSimple
    {
        private Usuarios_DTO _Usuario = new Usuarios_DTO();

        #region Contructores

        public Usuarios()
        {
            // Se vinculan los delegados
            VincularDelegados();
        }

        public Usuarios(int pId)
        {
            ObtenerUsuario(pId);

            // Se vinculan los delegados
            VincularDelegados();
        }

        public Usuarios(Usuarios_DTO pUsuario)
        {
            ObtenerUsuario(pUsuario);

            // Se vinculan los delegados
            VincularDelegados();
        }
        #endregion

        #region Propiedades

        public int UsuarioId
        {
            get => _Usuario.UsuarioId;
            set => _Usuario.UsuarioId = value;
        }

        public int IdiomaId
        {
            get => _Usuario.IdiomaId;
            set => _Usuario.IdiomaId = value;
        }

        public string Nik
        {
            get => _Usuario.Nik;
            set => _Usuario.Nik = value;
        }

        public string Contrasena
        {
            get => _Usuario.Contrasena;
            set => _Usuario.Contrasena = value;
        }

        public short Intentos
        {
            get => _Usuario.Intentos;
            set => _Usuario.Intentos = value;
        }

        public bool Bloqueado
        {
            get => _Usuario.Bloqueado;
            set => _Usuario.Bloqueado = value;
        }

        public int DVH
        {
            get => _Usuario.DVH;
            set => _Usuario.DVH = value;
        }

        public bool Admin
        {
            get => _Usuario.Admin;
            set => _Usuario.Admin = value;
        }

        #region UsuarioFamilia

        private ObjetoLista<Familia> UsuarioFamilias = new ObjetoLista<Familia>(TipoAgregacion.MuchosAMuchos);


        public ObjetoLista<Familia> Familias
        {
            get
            {
                UsuarioFamilias.Cargar(true);

                return UsuarioFamilias.get_ItemsVisibles();
            }
        }

        #endregion

        #region UsuarioPatente

        private ObjetoLista<UsuarioPatente> UsuarioPatentes = new ObjetoLista<UsuarioPatente>(TipoAgregacion.MuchosAMuchos);

        public ObjetoLista<UsuarioPatente> Patentes
        {
            get
            {
                UsuarioPatentes.Cargar(true);

                return UsuarioPatentes.get_ItemsVisibles();
            }
        }
        #endregion

        #endregion

        #region Metodos
        public List<Usuarios> ObtenerUsuario()
        {
            var mCol = new List<Usuarios>();

            foreach (var mUsuario in Usuarios_DAL.ObtenerUsuario())
            {
                mCol.Add(new Usuarios(mUsuario));
            }

            return mCol;
        }

        public void ObtenerUsuario(int pId)
        {
            var mUsuario = new Usuarios_DTO();

            mUsuario = Usuarios_DAL.ObtenerUsuario(pId);

            _Usuario = mUsuario;
        }

        public void ObtenerUsuario(string pNik)
        {
            var mUsuario = new Usuarios_DTO();

            mUsuario = Usuarios_DAL.ObtenerUsuario(pNik);

            _Usuario = mUsuario;
        }

        public void ObtenerUsuario(Usuarios_DTO pUsuario)
        {
            try
            {
                _Usuario = pUsuario;
            }
            catch (Exception)
            {
            }
        }

        public override void Eliminar()
        {
            try
            {
                if (_Usuario.UsuarioId > 0)
                {
                    Usuarios_DAL.EliminarUsuario(UsuarioId);

                    // Persisto las colecciones
                    if (UsuarioFamilias.Count > 0)
                        UsuarioFamilias.Persistir();

                    if (UsuarioPatentes.Count > 0)
                        UsuarioPatentes.Persistir();
                }
            }
            catch (Exception)
            {
            }
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }

        public override void Guardar()
        {
            try
            {
                if (_Usuario.UsuarioId <= 0)
                    Usuarios_DAL.AltaUsuario(_Usuario);
                else
                    Usuarios_DAL.ModificarUsuario(_Usuario);

                // Persisto las colecciones
                if (UsuarioFamilias.Count > 0)
                    UsuarioFamilias.Persistir();

                if (UsuarioPatentes.Count > 0)
                    UsuarioPatentes.Persistir();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Desbloquear()
        {
            try
            {
                if (_Usuario.UsuarioId > 0)
                {
                    _Usuario.Bloqueado = false;
                    _Usuario.Intentos = 0;

                    Usuarios_DAL.Desbloquear(_Usuario.UsuarioId);
                }
            }
            catch (Exception)
            {
            }
        }

        public void BlanquearContrasena(string pNuevaContrasena)
        {
            if (UsuarioId > 0)
            {
                string nuevaContrasena = Encriptado.GetHashMD5(pNuevaContrasena);

                Contrasena = nuevaContrasena;

                Usuarios_DAL.BlanquearPassword(UsuarioId, nuevaContrasena);
            }
        }

        public void ActualizarIdioma(short pIdioma)
        {
            try
            {
                if (_Usuario.UsuarioId > 0)
                {
                    _Usuario.IdiomaId = pIdioma;

                    Usuarios_DAL.ActualizarIdioma(_Usuario.UsuarioId, pIdioma);
                }
            }
            catch (Exception)
            {
            }
        }

        public bool ValidarClaveUsuario(string pNik, string pContrasena)
        {
            string mEncryptPass;

            ObtenerUsuario(pNik);

            if (_Usuario.UsuarioId > 0)
            {
                //Si el usuario NO se encuentra bloqueado
                if (!_Usuario.Bloqueado)
                {
                    mEncryptPass = Encriptado.GetHashMD5(pContrasena);

                    //Si las claves encriptadas son iguales esta OK
                    if (mEncryptPass.TrimEnd() == _Usuario.Contrasena.TrimEnd())
                    {
                        _Usuario.Intentos = 0;
                        _Usuario.Bloqueado = false;
                            
                        Guardar();

                        return true;
                    }

                    //Se incrementa en 1 el intento de logueo
                    _Usuario.Intentos++;
                    
                    // Se bloquea usuario
                    if (_Usuario.Intentos >= 3)
                        _Usuario.Bloqueado = true;

                    Guardar();
                }
            }

            return false;
        }

        public bool ValidarUsuario()
        {
            return true;
        }

        public static bool ValidarUsuarioExistente(int pUsuario)
        {
            return Usuarios_DAL.ValidarUsuarioExistente(pUsuario);
        }

        #region UsuarioFamilia

        public int AgregarFamilia(Familia pObjeto)
        {
            if (pObjeto.FamiliaId > 0)
                return UsuarioFamilias.Agregar(pObjeto);
            else
                return default(int);
        }

        public void QuitarFamilia(Familia pObjeto)
        {
            if (pObjeto.FamiliaId > 0)
                UsuarioFamilias.Eliminar(pObjeto);
        }

        public void QuitarFamilias()
        {
            UsuarioFamilias.EliminarTodo();
        }

        private void AltaFamiliaUsuario(ref Familia pObjeto)
        {
            var usuarioFamilia = new UsuarioFamilia();
            usuarioFamilia.AltaUsuarioFamilia(this.UsuarioId, pObjeto.FamiliaId);
        }

        private void EliminarFamiliaUsuario(ref Familia pObjeto)
        {
            var usuarioFamilia = new UsuarioFamilia();
            usuarioFamilia.EliminarUsuarioFamilia(this.UsuarioId, pObjeto.FamiliaId);
        }

        private void ObtenerFamilias()
        {
            this.UsuarioFamilias.Cargar((new UsuarioFamilia()).ObtenerUsuarioFamilia(this.UsuarioId));
        }

        public bool ExisteFamilia(Familia pFamilia)
        {
            foreach (var familia in Familias)
            {
                if (familia.FamiliaId == pFamilia.FamiliaId)
                    return true;
            }

            return false;
        }

        public Familia ObtenerFamiliaIndice(int pIndice)
        {
            return UsuarioFamilias[pIndice];
        }

        public void PersistirFamilias()
        {
            UsuarioFamilias.Persistir();
        }

        #endregion

        private void VincularDelegados()
        {
            UsuarioFamilias.RequerimientoCarga += ObtenerFamilias;
            UsuarioFamilias.InsertarRelacionMuchosAMuchos += AltaFamiliaUsuario;
            UsuarioFamilias.EliminarRelacionMuchosAMuchos += EliminarFamiliaUsuario;

            UsuarioPatentes.RequerimientoCarga += ObtenerPatentes;
            UsuarioPatentes.InsertarRelacionMuchosAMuchos += AltaPatenteUsuario;
            UsuarioPatentes.EliminarRelacionMuchosAMuchos += EliminarPatenteUsuario;
        }
        #endregion

        #region UsuarioPatente

        public int AgregarPatente(UsuarioPatente pObjeto)
        {
            if (pObjeto.Patente.PatenteId > 0)
                return UsuarioPatentes.Agregar(pObjeto);
            else
                return default(int);
        }

        public void QuitarPatente(UsuarioPatente pObjeto)
        {
            if (pObjeto.Patente.PatenteId > 0)
                UsuarioPatentes.Eliminar(pObjeto);
        }

        public void QuitarPatente()
        {
            UsuarioPatentes.EliminarTodo();
        }

        private void AltaPatenteUsuario(ref UsuarioPatente pObjeto)
        {
            pObjeto.AltaUsuarioPatente();
        }

        private void EliminarPatenteUsuario(ref UsuarioPatente pObjeto)
        {
            pObjeto.EliminarUsuarioPatente();
        }

        private void ObtenerPatentes()
        {
            this.UsuarioPatentes.Cargar((new UsuarioPatente()).ObtenerUsuarioPatente(this.UsuarioId));
        }

        public bool ExistePatente(Patente pPatente)
        {
            foreach (var patente in Patentes)
            {
                if (patente.Patente.PatenteId == pPatente.PatenteId)
                    return true;
            }

            return false;
        }

        public UsuarioPatente ObtenerPatenteIndice(int pIndice)
        {
            return UsuarioPatentes[pIndice];
        }

        public void CambiarEstadoPorIndice(int pIndice, bool pDenegado)
        {
            UsuarioPatentes[pIndice].Denegado = pDenegado;
        }

        public void PersistirPatentes()
        {
            UsuarioPatentes.Persistir();
        }

        #endregion
    }
}
