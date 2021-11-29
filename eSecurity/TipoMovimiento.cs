using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eDataAccess.Security;

namespace eSecurity
{
    public class TipoMovimiento
    {
        private TipoMovimiento_DTO _TipoMovimiento = new TipoMovimiento_DTO();

        #region Propiedades

        public int CriticidadId
        {
            get { return _TipoMovimiento.TipoMovimientoId; }

            set { _TipoMovimiento.TipoMovimientoId = value; }
        }

        public string Descripcion
        {
            get { return _TipoMovimiento.Descripcion; }

            set { _TipoMovimiento.Descripcion = value; }
        }
        public string DescCorta
        {
            get { return _TipoMovimiento.DescCorta; }

            set { _TipoMovimiento.DescCorta = value; }
        }
        #endregion

        #region Constructores

        public TipoMovimiento()
        {

        }

        public TipoMovimiento(int pId)
        {
            ObtenerTipoMovimiento(pId);
        }

        public TipoMovimiento(TipoMovimiento_DTO pTipoMovimiento)
        {
            ObtenerTipoMovimiento(pTipoMovimiento);
        }

        #endregion

        #region Metodos

        public List<TipoMovimiento> ObtenerTipoMovimiento()
        {
            List<TipoMovimiento> mCol = new List<TipoMovimiento>();

            foreach (TipoMovimiento_DTO tipoMovimiento in TipoMovimiento_DAL.ObtenerTipoMovimiento())
                mCol.Add(new TipoMovimiento(tipoMovimiento));

            return mCol;
        }

        public void ObtenerTipoMovimiento(Int32 pId)
        {
            try
            {
                _TipoMovimiento = TipoMovimiento_DAL.ObtenerTipoMovimiento(pId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ObtenerTipoMovimiento(TipoMovimiento_DTO pTipoMovimiento)
        {
            try
            {
                _TipoMovimiento = pTipoMovimiento;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
