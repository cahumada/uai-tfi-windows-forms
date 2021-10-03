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
        private Usuarios_DTO _Usuario;

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
        public int UsuarioId { get { return _Usuario.UsuarioId; } }
        public int IdiomaId { get { return _Usuario.IdiomaId; } }
        public string Nik { get { return _Usuario.Nik; } }
        public string Contrasena { get { return _Usuario.Contrasena; } }
        public short Intentos { get { return _Usuario.Intentos; } }
        public bool Bloqueado { get { return _Usuario.Bloqueado; } }
        public int DVH { get { return _Usuario.DVH; } }
        public bool Admin { get { return _Usuario.Admin; } }

        public List<UsuarioFamilia> Familias { get { return (new UsuarioFamilia()).ObtenerUsuarioFamilia(UsuarioId); } }
        public List<UsuarioPatente> Patentes { get { return (new UsuarioPatente()).ObtenerUsuarioPatente(UsuarioId); } }
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

        public void Eliminar(Usuarios_DTO pUsuario)
        {
            try
            {
                if (_Usuario.UsuarioId > 0)
                {
                    Usuarios_DAL.EliminarUsuario(_Usuario.UsuarioId);

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
