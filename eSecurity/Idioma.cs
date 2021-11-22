using eDataAccess.Security;
using eSecurity.Languages;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eSecurity
{
    public class Idioma
    {
        private Idioma_DTO _Idioma;

        #region Propiedades
        public string Descripcion
        {
            get { return _Idioma.Descripcion; }
            set { _Idioma.Descripcion = value; }
        }

        public int IdiomaId
        {
            get { return _Idioma.IdiomaId; }
            set { _Idioma.IdiomaId = value; }
        }

        public string DescCorta
        {
            get { return _Idioma.DescCorta; }
            set { _Idioma.DescCorta = value; }
        }

        #endregion

        #region Contructores
        public Idioma()
        {

        }

        public Idioma(int pId)
        {
            ObtenerIdioma(pId);
        }

        public Idioma(Idioma_DTO pIdioma)
        {
            _Idioma = pIdioma;
        }
        #endregion

        #region Metodos
        public bool ObtenerIdiomaPorDefecto(int pUsuarioId = 0)
        {
            try
            {
                //Obtengo el Idioma del usuario/por defecto del sistema
                _Idioma = Idioma_DAL.ObtenerIdiomaPorDefecto(pUsuarioId);

                //Establece el idioma que va a utilizar (archivo de recurso)
                Thread.CurrentThread.CurrentCulture = new CultureInfo(_Idioma.DescCorta);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_Idioma.DescCorta);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ObtenerIdioma(int pIdiomaId)
        {
            try
            {
                _Idioma = Idioma_DAL.ObtenerIdioma(pIdiomaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string ObtenerEtiqueta(string pClave)
        {
            return StringResources.ResourceManager.GetString(pClave);
        }

        public List<Idioma> ObtenerIdiomas()
        {
            var mCol = new List<Idioma>();

            foreach (var mFamilia in Idioma_DAL.ObtenerIdiomas())
            {
                mCol.Add(new Idioma(mFamilia));
            }

            return mCol;
        }
        
        #endregion
    }
}
