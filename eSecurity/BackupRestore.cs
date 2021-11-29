using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eDataAccess.Security;

namespace eSecurity
{
    public class BackupRestore
    {
        public bool RealizarBackup(string pRuta, Int32 pCantidadArchivos, Int32 pUsuario)
        {
            try
            {
                BackupRestore_DAL.RealizarBackup(pRuta, pCantidadArchivos);

                Bitacora mBitacora = new Bitacora()
                {
                    CriticidadId = 2,
                    FechaMovimiento = DateTime.Now,
                    MovimientoId = 5,
                    CodigoUsuario = pUsuario

                };

                mBitacora.Guardar();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool RealizarRestore(string pRuta, Int32 pCantidadArchivos, Int32 pUsuario)
        {
            try
            {
                BackupRestore_DAL.RealizarRestore(pRuta, pCantidadArchivos);

                Bitacora mBitacora = new Bitacora()
                {
                    CriticidadId = 2,
                    FechaMovimiento = DateTime.Now,
                    MovimientoId = 6,
                    CodigoUsuario = pUsuario

                };

                mBitacora.Guardar();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
