using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eDataAccess.Security;

namespace eSecurity
{
    public class Criticidad
    {
        private Criticidad_DTO _Criticidad = new Criticidad_DTO();

        #region Propiedades

        public int CriticidadId
        {
            get { return _Criticidad.CriticidadId; }

            set { _Criticidad.CriticidadId = value; }
        }

        public string Descripcion
        {
            get { return _Criticidad.Descripcion; }

            set { _Criticidad.Descripcion = value; }
        }
        public string DescCorta
        {
            get { return _Criticidad.DescCorta; }

            set { _Criticidad.DescCorta = value; }
        }
        #endregion

        #region Constructores

        public Criticidad()
        {

        }

        public Criticidad(int pId)
        {
            ObtenerCriticidad(pId);
        }

        public Criticidad(Criticidad_DTO pCriticidad)
        {
            ObtenerCriticidad(pCriticidad);
        }

        #endregion

        #region Metodos

        public List<Criticidad> ObtenerCriticidad()
        {
            List<Criticidad> mCol = new List<Criticidad>();

            foreach (Criticidad_DTO criticidad in Criticidad_DAL.ObtenerCriticidad())
                mCol.Add(new Criticidad(criticidad));

            return mCol;
        }

        public void ObtenerCriticidad(Int32 pId)
        {
            try
            {
                _Criticidad = Criticidad_DAL.ObtenerCriticidad(pId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ObtenerCriticidad(Criticidad_DTO pCriticidad)
        {
            try
            {
                _Criticidad = pCriticidad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
