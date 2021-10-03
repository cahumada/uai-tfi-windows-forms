using eSecurity;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public class MasterForm
    {
        #region Methods
        internal static bool AplicarIdioma(Form pForm)
        {
            try
            {
                CambiarIdioma(pForm);

                foreach (Control mControl in pForm.Controls)
                {
                    CambiarIdioma(pForm);

                    ControlesHijos(mControl);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ControlesHijos(Control pControl)
        {
            CambiarIdioma(pControl);

            if (pControl.GetType() == typeof(DataGridView))
            {
                foreach (DataGridViewColumn mCol in ((DataGridView)pControl).Columns)
                {
                    var _Etiqueta = Idioma.ObtenerEtiqueta(mCol.Name);
                    var _Etiqueta_tt = Idioma.ObtenerEtiqueta(mCol.Name + "_tt");

                    if (!string.IsNullOrEmpty(_Etiqueta))
                        mCol.HeaderText = _Etiqueta;

                    if (!string.IsNullOrEmpty(_Etiqueta_tt))
                        mCol.ToolTipText = _Etiqueta_tt;
                }
            }
            else if (pControl.HasChildren)
            {
                foreach (Control mControlHijo in pControl.Controls)
                {
                    ControlesHijos(mControlHijo);
                }
            }
        }

        private static void CambiarIdioma(Control pControl)
        {
            var _Etiqueta = Idioma.ObtenerEtiqueta(pControl.Name);

            if (!string.IsNullOrEmpty(_Etiqueta))
                pControl.Text = _Etiqueta;
        }

        internal static void HabilitarControles(Control pControl, bool pHabilitado = false, bool pVisible = true)
        {
            if (pControl.GetType() == typeof(TextBox))
                ((TextBox)pControl).ReadOnly = !pHabilitado;
            else
                pControl.Enabled = pHabilitado;

            pControl.Visible = pVisible;

            if (pControl.HasChildren)
            {
                foreach (Control mControl in pControl.Controls)
                {
                    mControl.Enabled = pHabilitado;
                    mControl.Visible = pVisible;

                    if (mControl.HasChildren)
                        HabilitarControles(mControl, pHabilitado);
                }
            }
        }

        internal static bool ControlErrores(Control pControl, ErrorProvider pError)
        {
            if (pError.GetError(pControl).Length > 0)
                return true;

            if (pControl.HasChildren)
            {
                foreach (Control mControl in pControl.Controls)
                {
                    if (pError.GetError(mControl).Length > 0)
                        return true;

                    if (pControl.HasChildren)
                        if (ControlErrores(mControl, pError))
                            return true;
                }
            }

            return false;
        }
        #endregion
    }
}
