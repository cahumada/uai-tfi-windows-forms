using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class FamiliaPatente
    {
        private FamiliaPatente_DTO _FamiliaPatente;

        #region Propiedades
        public long FamiliaPatenteId { get { return _FamiliaPatente.FamiliaPatenteId; } }
        public Familia_DTO Familia { get { return _FamiliaPatente.Familia; } }
        public Patente_DTO Patente { get { return _FamiliaPatente.Patente; } }
        public int DVH { get { return _FamiliaPatente.DVH; } }
        #endregion

        #region Metodos
        public void Eliminar()
        {
            FamiliaPatente_DAL.EliminarFamiliaPatente(_FamiliaPatente.FamiliaPatenteId);
        }

        public void Guardar()
        {
            FamiliaPatente_DAL.AltaFamiliaPatente(_FamiliaPatente.Familia.FamiliaId, _FamiliaPatente.Patente.PatenteId);
        }

        public void AltaFamiliaPatente(int pFamiliaId, int pPatenteId)
        {
            _FamiliaPatente.FamiliaPatenteId = 0;
            _FamiliaPatente.Familia.FamiliaId= pFamiliaId;
            _FamiliaPatente.Patente.PatenteId = pPatenteId;

            Guardar();
        }

        public void EliminarFamiliaPatente(long pFamiliaPatenteId)
        {
            _FamiliaPatente.FamiliaPatenteId = pFamiliaPatenteId;

            Eliminar();
        }

        public DataTable ObtenerFamiliaPatente(Familia pFamilia)
        {
            return ObtenerFamiliaPatente(pFamilia.FamiliaId);
        }

        public DataTable ObtenerFamiliaPatente(int pFamiliaId)
        {
            return FamiliaPatente_DAL.ObtenerFamiliaPatente(pFamiliaId);
        }
        #endregion
    }
}
