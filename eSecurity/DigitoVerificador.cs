using eDataAccess.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class DigitoVerificador
    {
        #region Propiedades
        private int _DigitoVerificador { get; set; }
        private int _Calculador { get; set; }
        #endregion

        #region Metodos
        /// <summary>
        /// Calcula el digito verificador horizontal
        /// </summary>
        /// <param name="pNombreTabla"></param>
        /// <returns></returns>
        public int CalcularDigVerif(string pNombreTabla)
        {
            return DigitoVerificador_DAL.CalcularDigVerif(pNombreTabla);
        }

        /// <summary>
        /// Verifica integridad del sistema comprobando los digitos verificadores.
        /// </summary>
        /// <returns></returns>
        public static int VerificarIntegridad()
        {
            return DigitoVerificador_DAL.VerificarIntegridad();
        }
        #endregion
    }
}
