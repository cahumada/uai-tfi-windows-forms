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
    public class FamiliaPatente: ObjetoSimple
    {
        private FamiliaPatente_DTO _FamiliaPatente = new FamiliaPatente_DTO();

        #region Propiedades

        public long FamiliaPatenteId
        {
            get { return _FamiliaPatente.FamiliaPatenteId; }
            set { _FamiliaPatente.FamiliaPatenteId = value; }
        }

        public Familia_DTO Familia
        {
            get { return _FamiliaPatente.Familia; }
            set { _FamiliaPatente.Familia = value; }
        }

        public Patente_DTO Patente
        {
            get { return _FamiliaPatente.Patente; }
            set { _FamiliaPatente.Patente = value; }
        }
        public int DVH { 
            get { return _FamiliaPatente.DVH; } 
            set { _FamiliaPatente.DVH = value; }
        }
        #endregion

        #region Metodos
        public override void Eliminar()
        {
            FamiliaPatente_DAL.EliminarFamiliaPatente(_FamiliaPatente.Familia.FamiliaId, _FamiliaPatente.Patente.PatenteId);
        }

        public override void Guardar()
        {
            FamiliaPatente_DAL.AltaFamiliaPatente(_FamiliaPatente.Familia.FamiliaId, _FamiliaPatente.Patente.PatenteId);
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }

        public void AltaFamiliaPatente(int pFamiliaId, int pPatenteId)
        {
            _FamiliaPatente.FamiliaPatenteId = 0;
            _FamiliaPatente.Familia.FamiliaId= pFamiliaId;
            _FamiliaPatente.Patente.PatenteId = pPatenteId;

            Guardar();
        }

        public void EliminarFamiliaPatente(int pFamiliaId, int pPatenteId)
        {
            _FamiliaPatente.Familia.FamiliaId = pFamiliaId;
            _FamiliaPatente.Patente.PatenteId = pPatenteId;

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

        public bool ValidarFamiliaPatente()
        {
            return true;
        }
        #endregion
    }
}
