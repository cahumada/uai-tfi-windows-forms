using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class Familia
    {
        private Familia_DTO _Familia = new Familia_DTO();

        #region Propiedades
        public int FamiliaId { 
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

        #region Contructores
        public Familia()
        {
        }

        public Familia(int pId)
        {
            ObtenerFamilia(pId);
        }

        public Familia(Familia_DTO pFamilia)
        {
            ObtenerFamilia(pFamilia);
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

        public void Guardar()
        {
            if (_Familia.FamiliaId <= 0)
                Familia_DAL.AltaFamilia(_Familia);
            else
                Familia_DAL.ModificarFamilia(_Familia);
        }

        public void Eliminar()
        {
            if (_Familia.FamiliaId > 0)
                Familia_DAL.EliminarFamilia(_Familia.FamiliaId);
        }
        #endregion
    }
}
