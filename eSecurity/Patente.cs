using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFramework;

namespace eSecurity
{
    public class Patente : ObjetoSimple
    {
        private Patente_DTO _Patente = new Patente_DTO();

        public int PatenteId
        {
            get { return _Patente.PatenteId; }

            set { _Patente.PatenteId = value; }
        }

        public string Descripcion
        {
            get { return _Patente.Descripcion; }

            set { _Patente.Descripcion = value; }
        }

        public DateTime Fecha
        {
            get { return _Patente.Fecha; }

            set { _Patente.Fecha = value; }
        }

        public string DescCorta
        {
            get { return _Patente.DescCorta; }

            set { _Patente.DescCorta = value; }
        }

        #region Contructores
        public Patente()
        {

        }

        public Patente(int pId)
        {
            ObtenerPatente(pId);
        }

        public Patente(DataRow pDr)
        {
            _Patente.PatenteId = (Convert.IsDBNull(pDr["Id_Patente"])) ? default(int) : (int)pDr["Id_Patente"];
            _Patente.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? null : pDr["Descripcion"].ToString();
            _Patente.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? null : pDr["Desc_Corta"].ToString();
        }

        public Patente(Patente_DTO pPatente)
        {
            ObtenerPatente(pPatente);
        }
        #endregion

        #region Metodos
        public List<Patente> ObtenerPatente()
        {
            var mCol = new List<Patente>();

            foreach (var mPatente in Patente_DAL.ObtenerPatente())
            {
                mCol.Add(new Patente(mPatente));
            }

            return mCol;
        }

        public void ObtenerPatente(int pId)
        {
            var mPatente = new Patente_DTO();

            mPatente = Patente_DAL.ObtenerPatente(pId);

            _Patente = mPatente;
        }

        public void ObtenerPatente(Patente_DTO pPatente)
        {
            try
            {
                _Patente = pPatente;
            }
            catch (Exception)
            {
            }
        }

        public override void Guardar()
        {
            if (_Patente.PatenteId <= 0)
                Patente_DAL.AltaPatente(_Patente);
            else
                Patente_DAL.ModificarPatente(_Patente);
        }

        public override void Eliminar()
        {
            if (_Patente.PatenteId > 0)
                Patente_DAL.EliminarPatente(_Patente.PatenteId);
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }

        #endregion

        #region Operadores
        public static bool operator ==(Patente pPatente, Patente pPatente2)
        {
            return pPatente.PatenteId == pPatente2.PatenteId;
        }

        public static bool operator !=(Patente pPatente, Patente pPatente2)
        {
            return pPatente.PatenteId != pPatente2.PatenteId;
        }
        #endregion
    }
}
