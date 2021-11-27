using eSecurity;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public class MasterForm
    {
        #region Methods
        internal static bool AplicarIdioma(Control pForm)
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

                    if (mControl.HasChildren)
                        if (ControlErrores(mControl, pError))
                            return true;
                }
            }

            return false;
        }

        internal static void CerrarInstacias()
        {
            foreach (var process in Process.GetProcessesByName(Assembly.GetExecutingAssembly().FullName))
            {
                process.Kill();
            }
        }

        internal static void LimpiarControles(Control pControl)
        {
            SubLimpiarControles(pControl);

            if (pControl.HasChildren)
            {
                foreach (Control ctrl in pControl.Controls)
                {
                    LimpiarControles(ctrl);
                }
            }
        }

        private static void SubLimpiarControles(Control pControl)
        {
            if (pControl.GetType() == typeof(TextBox))
            {
                ((TextBox)pControl).Clear();
            }

            if (pControl.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)pControl).Clear();
            }

            if (pControl.GetType() == typeof(DataGridView))
            {
                ((DataGridView)pControl).Rows.Clear();
            }

            if (pControl.GetType() == typeof(DateTimePicker))
            {
                ((DateTimePicker)pControl).Value = DateTime.Now;
            }

            if (pControl.GetType() == typeof(PictureBox))
            {
                ((PictureBox)pControl).Image = null;
            }

            if (pControl.GetType() == typeof(CheckBox))
            {
                ((CheckBox)pControl).Checked = false;
            }

            if (pControl.GetType() == typeof(NumericUpDown))
            {
                ((NumericUpDown)pControl).Value = 0;
            }
        }

        internal static void ModificarToolTip(Control pControl, ToolTip pToolTip)
        {
            if (!(pControl.GetType() == typeof(DataGridView)) &&
                  !(string.IsNullOrEmpty(Idioma.ObtenerEtiqueta(pControl.Name + "_tt"))))
            {
                pToolTip.SetToolTip(pControl, Idioma.ObtenerEtiqueta(pControl.Name + "_tt"));
            }

            if (pControl.HasChildren)
            {
                foreach (Control ctrl in pControl.Controls)
                {
                    if (!(ctrl.GetType() == typeof(DataGridView)) &&
                        !(string.IsNullOrEmpty(Idioma.ObtenerEtiqueta(ctrl.Name + "_tt"))))
                    {
                        pToolTip.SetToolTip(ctrl, Idioma.ObtenerEtiqueta(ctrl.Name + "_tt"));
                    }

                    if (ctrl.HasChildren)
                        ModificarToolTip(ctrl, pToolTip);
                }
            }
        }
        #endregion
    }
}
