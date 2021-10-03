using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class Bitacora
    {
        private Bitacora_DTO _Bitacora;

        #region Contructores
        public Bitacora()
        {

        }

        public Bitacora(long pId)
        {
            ObtenerBitacora(pId);
        }

        public Bitacora(Bitacora_DTO pBitacora)
        {
            ObtenerBitacora(pBitacora);
        }
        #endregion

        #region Metodos
        public List<Bitacora> ObtenerBitacora()
        {
            var mCol = new List<Bitacora>();

            foreach (var mBitacora in Bitacora_DAL.ObtenerBitacora())
            {
                mCol.Add(new Bitacora(mBitacora));
            }

            return mCol;
        }

        public void ObtenerBitacora(long pId)
        {
            var mBitacora = new Bitacora_DTO();

            mBitacora = Bitacora_DAL.ObtenerBitacora(pId);

            _Bitacora = mBitacora;
        }

        public void ObtenerBitacora(Bitacora_DTO pBitacora)
        {
            try
            {
                _Bitacora = pBitacora;
            }
            catch (Exception)
            {
            }
        }

        public void Eliminar()
        {
            if (_Bitacora.LogId > 0)
            {
                Bitacora_DAL.EliminarBitacora(_Bitacora.LogId);
            }
        }

        public void Guardar()
        {
            if (_Bitacora.LogId > 0)
            {
                Bitacora_DAL.AltaBitacora(_Bitacora);
            }
        }
        #endregion
    }
}
