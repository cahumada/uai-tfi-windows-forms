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
    public class Familia : ObjetoSimple, IComparable<Familia>
    {
        private Familia_DTO _Familia = new Familia_DTO();

        #region Propiedades
        public int FamiliaId
        {
            get { return _Familia.FamiliaId; }
            set { _Familia.FamiliaId = value; }
        }

        public string Descripcion
        {
            get { return _Familia.Descripcion; }
            set { _Familia.Descripcion = value; }
        }

        public string DescCorta
        {
            get { return _Familia.DescCorta; }
            set { _Familia.DescCorta = value; }
        }

        public DateTime Fecha
        {
            get { return _Familia.Fecha; }
            set { _Familia.Fecha = value; }
        }
        #endregion

        #region FamiliaPatente

        private ObjetoLista<Patente> FamiliaPatente = new ObjetoLista<Patente>(TipoAgregacion.MuchosAMuchos);

        public ObjetoLista<Patente> Patentes
        {
            get
            {
                FamiliaPatente.Cargar(true);

                return FamiliaPatente.get_ItemsVisibles();
            }
        }

        #endregion

        #region Contructores
        public Familia()
        {
            // Se vinculan los delegados
            VincularDelegados();
        }

        public Familia(int pId)
        {
            ObtenerFamilia(pId);

            // Se vinculan los delegados
            VincularDelegados();
        }

        public Familia(DataRow pDr)
        {
            _Familia.FamiliaId = (Convert.IsDBNull(pDr["Id_Familia"])) ? default(int) : (int)pDr["Id_Familia"];
            _Familia.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? null : pDr["Descripcion"].ToString();
            _Familia.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? null : pDr["Desc_Corta"].ToString();

            // Se vinculan los delegados
            VincularDelegados();
        }

        public Familia(Familia_DTO pFamilia)
        {
            ObtenerFamilia(pFamilia);

            // Se vinculan los delegados
            VincularDelegados();
        }
        #endregion

        #region Metodos
        public List<Familia> ObtenerFamilia()
        {
            var mCol = new List<Familia>();

            foreach (var mFamilia in Familia_DAL.ObtenerFamilia())
            {
                mCol.Add(new Familia(mFamilia));
            }

            return mCol;
        }

        public void ObtenerFamilia(int pId)
        {
            var mFamilia = new Familia_DTO();

            mFamilia = Familia_DAL.ObtenerFamilia(pId);

            _Familia = mFamilia;
        }

        public void ObtenerFamilia(Familia_DTO pFamilia)
        {
            try
            {
                _Familia = pFamilia;
            }
            catch (Exception)
            {
            }
        }

        public override void Guardar()
        {
            if (_Familia.FamiliaId <= 0)
                Familia_DAL.AltaFamilia(_Familia);
            else
                Familia_DAL.ModificarFamilia(_Familia);
        }

        public override void Eliminar()
        {
            if (_Familia.FamiliaId > 0)
                Familia_DAL.EliminarFamilia(_Familia.FamiliaId);

        }

        public override DataSet ObtenerDataSet()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region FamiliaPatente
        public int AgregarPatente(Patente pObjeto)
        {
            if (pObjeto.PatenteId > 0)
                return FamiliaPatente.Agregar(pObjeto);
            else
                return default(int);
        }

        public void QuitarPatente(Patente pObjeto)
        {
            if (pObjeto.PatenteId > 0)
                FamiliaPatente.Eliminar(pObjeto);
        }

        public void QuitarPatentes()
        {
            FamiliaPatente.EliminarTodo();
        }

        private void AltaFamiliaPatente(ref Patente pObjeto)
        {
            var familiaPatente = new FamiliaPatente();
            familiaPatente.AltaFamiliaPatente(this.FamiliaId, pObjeto.PatenteId);
        }

        private void EliminarFamiliaPatente(ref Patente pObjeto)
        {
            var familiaPatente = new FamiliaPatente();
            familiaPatente.EliminarFamiliaPatente(this.FamiliaId, pObjeto.PatenteId);
        }

        private void ObtenerFamiliaPatentes()
        {
            this.FamiliaPatente.Cargar((new FamiliaPatente()).ObtenerFamiliaPatente(this.FamiliaId));
        }

        public Patente ObtenerFamiliaPatenteIndice(Int32 pIndice)
        {
            return FamiliaPatente[pIndice];
        }

        public void PersistirFamiliaPatentes()
        {
            FamiliaPatente.Persistir();
        }

        #endregion

        public int CompareTo(Familia other)
        {
            if (FamiliaId < other.FamiliaId)
                return 1;

            if (FamiliaId > other.FamiliaId)
                return -1;

            return 0;
        }

        private void VincularDelegados()
        {
            FamiliaPatente.RequerimientoCarga += ObtenerFamiliaPatentes;
            FamiliaPatente.InsertarRelacionMuchosAMuchos += AltaFamiliaPatente;
            FamiliaPatente.EliminarRelacionMuchosAMuchos += EliminarFamiliaPatente;
            
        }
    }
}
