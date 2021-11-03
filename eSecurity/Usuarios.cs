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
    public class Usuarios
    {
        private Usuarios_DTO _Usuario = new Usuarios_DTO();

        #region Contructores
        public Usuarios()
        {

        }

        public Usuarios(int pId)
        {
            ObtenerUsuario(pId);
        }

        public Usuarios(Usuarios_DTO pUsuario)
        {
            ObtenerUsuario(pUsuario);
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

        public List<UsuarioFamilia> Familias => (new UsuarioFamilia()).ObtenerUsuarioFamilia(UsuarioId);
        public List<UsuarioPatente> Patentes => (new UsuarioPatente()).ObtenerUsuarioPatente(UsuarioId);

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

        public void Eliminar()
        {
            try
            {
                if (_Usuario.UsuarioId > 0)
                {
                    Usuarios_DAL.EliminarUsuario(UsuarioId);

                    //TODO
                    //    If mUserFamily.Count > 0 Then
                    //    mUserFamily.Persistir()
                    //End If

                    //If mUserPatent.Count > 0 Then
                    //    mUserPatent.Persistir()
                    //End If
                }
            }
            catch (Exception)
            {
            }
        }

        public void Guardar()
        {
            try
            {
                if (_Usuario.UsuarioId <= 0)
                    Usuarios_DAL.AltaUsuario(_Usuario);
                else
                    Usuarios_DAL.ModificarUsuario(_Usuario);

                //TODO
                //If mUserFamily.Count > 0 Then
                //    mUserFamily.Persistir()
                //End If

                //If mUserPatent.Count > 0 Then
                //    mUserPatent.Persistir()
                //End If
            }
            catch (Exception)
            {
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
                string nuevaContrasena = Encrypt.GetHashMD5(pNuevaContrasena);

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
                    mEncryptPass = Encrypt.GetHashMD5(pContrasena);

                    //Si las claves encriptadas son iguales esta OK
                    if (mEncryptPass.TrimEnd() == _Usuario.Contrasena.TrimEnd())
                    {
                        return true;
                    }

                    //Se incrementa en 1 el intento de logueo
                    _Usuario.Intentos++;

                    Guardar();
                }
            }

            return false;
        }

        public bool ValidarUsuario()
        {
            return true;
        }

        #endregion
    }
}
