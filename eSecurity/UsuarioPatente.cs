using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eFramework;

namespace eSecurity
{
    public class UsuarioPatente : ObjetoSimple
    {
        private UsuarioPatente_DTO _UsuarioPatente = new UsuarioPatente_DTO();

        public long UsuarioPatenteId
        {
            get { return _UsuarioPatente.UsuarioPatenteId; }
            set { _UsuarioPatente.UsuarioPatenteId = value; }
        }

        public Usuarios_DTO Usuario
        {
            get { return _UsuarioPatente.Usuario; }
            set { _UsuarioPatente.Usuario = value; }
        }

        public Patente_DTO Patente
        {
            get { return _UsuarioPatente.Patente; }
            set { _UsuarioPatente.Patente = value; }
        }

        public bool Denegado
        {
            get { return _UsuarioPatente.Denegado; }
            set { _UsuarioPatente.Denegado = value; }
        }

        public string Familia
        {
            get { return _UsuarioPatente.Familia; }
            set { _UsuarioPatente.Familia = value; }
        }

        public int DVH
        {
            get { return _UsuarioPatente.DVH; }
            set { _UsuarioPatente.DVH = value; }
        }

        #region Constructores
        public UsuarioPatente()
        {

        }

        public UsuarioPatente(int pUsuario, int pPatente)
        {
            //ObtenerUsuarioPatente(pUsuario);
            Patente = Patente_DAL.ObtenerPatente(pPatente);
            Usuario = Usuarios_DAL.ObtenerUsuario(pUsuario);
        }

        public UsuarioPatente(DataRow pDr)
        {
            //USUARIO
            _UsuarioPatente.Usuario.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            _UsuarioPatente.Usuario.Nik = (Convert.IsDBNull(pDr["Nik"])) ? "" : pDr["Nik"].ToString();
            _UsuarioPatente.Usuario.Contrasena = (Convert.IsDBNull(pDr["Contrasena"])) ? "" : pDr["Contrasena"].ToString();
            _UsuarioPatente.Usuario.IdiomaId = (Convert.IsDBNull(pDr["Id_Idioma"])) ? 0 : (int)pDr["Id_Idioma"];
            _UsuarioPatente.Usuario.Intentos = (Convert.IsDBNull(pDr["Intentos"])) ? (short)0 : (short)pDr["Intentos"];
            _UsuarioPatente.Usuario.Bloqueado = (!Convert.IsDBNull(pDr["Bloqueado"])) && (bool)pDr["Bloqueado"];

            //PATENTE
            _UsuarioPatente.Patente.PatenteId = (Convert.IsDBNull(pDr["Id_Patente"])) ? 0 : (int)pDr["Id_Patente"];
            _UsuarioPatente.Patente.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            _UsuarioPatente.Patente.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            _UsuarioPatente.Patente.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            //USUARIOPATENTE
            _UsuarioPatente.UsuarioPatenteId = (Convert.IsDBNull(pDr["Id_UsuarioPatente"])) ? 0 : (long)pDr["Id_UsuarioPatente"];
            _UsuarioPatente.Familia = (Convert.IsDBNull(pDr["Familia"])) ? "" : pDr["Familia"].ToString();
            _UsuarioPatente.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];
            _UsuarioPatente.Denegado = (!Convert.IsDBNull(pDr["Denegado"])) && (bool)pDr["Denegado"];
        }

        public UsuarioPatente(UsuarioPatente_DTO pUsuarioPatente)
        {
            _UsuarioPatente = pUsuarioPatente;
        }
        #endregion


        #region Metodos
        public override void Eliminar()
        {
            UsuarioPatente_DAL.EliminarUsuarioPatente(_UsuarioPatente.Usuario.UsuarioId, _UsuarioPatente.Patente.PatenteId);
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }

        public override void Guardar()
        {
            UsuarioPatente_DAL.AltaUsuarioPatente(_UsuarioPatente.Usuario.UsuarioId, _UsuarioPatente.Patente.PatenteId, _UsuarioPatente.Denegado);
        }

        public void AltaUsuarioPatente(int pUsuarioId, int pPatenteId, bool pDenegar = false)
        {
            _UsuarioPatente.UsuarioPatenteId = 0;
            _UsuarioPatente.Usuario.UsuarioId = pUsuarioId;
            _UsuarioPatente.Patente.PatenteId = pPatenteId;

            Guardar();
        }

        public void AltaUsuarioPatente()
        {
            if (this.Usuario.UsuarioId > 0 && this.Patente.PatenteId > 0)
                Guardar();
        }

        public void EliminarUsuarioPatente(int pUsuarioId, int pPatenteId)
        {
            _UsuarioPatente.Usuario.UsuarioId = pUsuarioId;
            _UsuarioPatente.Patente.PatenteId = pPatenteId;

            Eliminar();
        }

        public void EliminarUsuarioPatente()
        {
            if (this.Usuario.UsuarioId > 0 && this.Patente.PatenteId > 0)
                Eliminar();
        }

        public DataTable ObtenerUsuarioPatente(Usuarios pUsuario)
        {
            return ObtenerUsuarioPatente(pUsuario.UsuarioId);
        }

        public DataTable ObtenerUsuarioPatente(int pUsuarioId)
        {
            var dataTable = UsuarioPatente_DAL.ObtenerUsuarioPatente(pUsuarioId);


            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                {
                    if (!Convert.IsDBNull(dataTable.Rows[i][1]) && // [1] = Descripcion
                        !string.IsNullOrEmpty(dataTable.Rows[i][1].ToString()))
                        dataTable.Rows[i][1] = dataTable.Rows[i][1].ToString();
                    // dataTable.Rows[i][1] = Encriptado.DataDecryption(dataTable.Rows[i][1].ToString()); //TODO
                }
            }

            return dataTable;
        }

        public static bool UsuarioPatenteHabilitada(int pUsuario, int pPatente)
        {
            try
            {
                return UsuarioPatente_DAL.UsuarioPatenteHabilitada(pUsuario, pPatente);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
