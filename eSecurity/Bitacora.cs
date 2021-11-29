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
    public class Bitacora: ObjetoSimple
    {
        private Bitacora_DTO _Bitacora = new Bitacora_DTO();

        #region Propiedades
        public long LogId
        {
            get { return _Bitacora.LogId; }

            set { _Bitacora.LogId = value; }
        }

        public int UsuarioId
        {
            get { return _Bitacora.UsuarioId; }

            set { _Bitacora.UsuarioId = value; }
        }

        public int MovimientoId
        {
            get { return _Bitacora.MovimientoId; }

            set { _Bitacora.MovimientoId = value; }
        }

        public int CriticidadId
        {
            get { return _Bitacora.CriticidadId; }

            set { _Bitacora.CriticidadId = value; }
        }

        public DateTime FechaMovimiento
        {
            get { return _Bitacora.FechaMovimiento; }

            set { _Bitacora.FechaMovimiento = value; }
        }

        public int DVH
        {
            get { return _Bitacora.DVH; }

            set { _Bitacora.DVH = value; }
        }

        #endregion

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
            List<Bitacora> mCol = new List<Bitacora>();

            foreach (Bitacora_DTO mUser in Bitacora_DAL.ObtenerBitacora())
                mCol.Add(new Bitacora(mUser));

            return mCol;
        }

        public DataTable ObtenerBitacoraReporte()
        {
            return Bitacora_DAL.ObtenerBitacoraReporte();
        }

        public DataTable ObtenerBitacoraReporte(DateTime pFechaDesde, DateTime pFechasHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            return Bitacora_DAL.ObtenerBitacoraReporte(pFechaDesde, pFechasHasta, pUsuario, pCriticidad);
        }

        public void ObtenerBitacora(long pLogId)
        {
            try
            {
                _Bitacora = Bitacora_DAL.ObtenerBitacora(pLogId);
            }
            catch (Exception ex)
            {
            }
        }

        public List<Bitacora> ObtenerBitacora(DateTime pFechaDesde, DateTime pFechasHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            try
            {
                List<Bitacora> mCol = new List<Bitacora>();

                foreach (Bitacora_DTO mUser in Bitacora_DAL.ObtenerBitacora(pFechaDesde, pFechasHasta, pUsuario, pCriticidad))
                    mCol.Add(new Bitacora(mUser));

                return mCol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ObtenerBitacora(Bitacora_DTO pBitacora)
        {
            try
            {
                _Bitacora = pBitacora;
            }
            catch (Exception ex)
            {
            }
        }

        public override void Eliminar()
        {
            try
            {
                if (LogId > 0)
                    Bitacora_DAL.EliminarBitacora(LogId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool EliminarBitacora(DateTime pFechaDesde, DateTime pFechasHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            try
            {
                Bitacora_DAL.EliminarBitacora(pFechaDesde, pFechasHasta, pUsuario, pCriticidad);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool EliminarBitacora()
        {
            try
            {
                Bitacora_DAL.EliminarBitacora();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void Guardar()
        {
            try
            {
                if (UsuarioId > 0)
                    Bitacora_DAL.AltaBitacora(_Bitacora);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ValidarUsuario()
        {
            return true;
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }
        #endregion
    }
}
