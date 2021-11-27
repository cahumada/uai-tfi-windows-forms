using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eFramework;
using eSecurity;

namespace Gabe.Controles
{
    public partial class UsuarioControl : UserControl
    {
        private int codigoUsuario = 1;
        private EstadosABM estado = EstadosABM.Consulta;

        public int CodigoUsuario
        {
            get { return codigoUsuario; }
            set
            {
                codigoUsuario = value;

                //Seteo Idioma
                if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
                {
                    MasterForm.AplicarIdioma(this);
                }
            }
        }

        public EstadosABM Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public UsuarioControl()
        {
            InitializeComponent();
        }

        private bool ValidarUsuario(bool pMensaje = false)
        {
            bool EsValido = true;

            if (TxtUser.Text.Length > 0)
            {
                var usuario = new Usuarios(Convert.ToInt32(TxtUser.Text));

                if (usuario.UsuarioId > 0)
                    LblUser.Text = usuario.Nik;
                else
                {
                    if (pMensaje && estado != EstadosABM.Consulta)
                    {
                        ErrProv.BlinkRate = 200;
                        ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                        ErrProv.SetError(this, Idioma.ObtenerEtiqueta("USRCTRL01_Val001"));
                    }

                    EsValido = false;

                    TxtUser.Text = "";
                    LblUser.Text = "";
                }
            }
            else
            {
                TxtUser.Text = "";
                LblUser.Text = "";
            }

            return EsValido;
        }
        private bool ValidarErrorUduario()
        {
            bool EsValido = true;

            if (string.IsNullOrEmpty(TxtUser.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(this, Idioma.ObtenerEtiqueta("CLICTRL01_Val003"));

                EsValido = false;
                LblUser.Text = "";
            }
            else
            {
                if (Usuarios.ValidarUsuarioExistente(Convert.ToInt32(TxtUser.Text)))
                {
                    ErrProv.BlinkRate = 200;
                    ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    ErrProv.SetError(this, Idioma.ObtenerEtiqueta("USRCTRL01_Val001"));

                    EsValido = false;
                }
                else
                    ErrProv.SetError(this, "");
            }

            return EsValido;
        }

        private void TxtUser_TextChanged(object sender, EventArgs e)
        {
            ValidarUsuario(false);
        }

        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            int id;
            
            if (!int.TryParse(e.KeyChar.ToString(), out id) || e.KeyChar == Convert.ToChar(Keys.Back) ||
                e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                e.Handled = false;
            }

        }

        private void TxtUser_Validating(object sender, CancelEventArgs e)
        {
            if (estado != EstadosABM.Consulta)
            {
                if (!ValidarErrorUduario())
                    e.Cancel = true;

                if (!ValidarUsuario())
                    e.Cancel = true;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var form = new USRL001_Title(codigoUsuario);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;

            form.FormBorderStyle = FormBorderStyle.FixedSingle;

            form.ShowDialog(this);

            if (form.Usuario != null && form.Usuario.UsuarioId > 0)
            {
                TxtUser.Text = form.Usuario.UsuarioId.ToString();
                LblUser.Text = form.Usuario.Nik;
            }
        }
    }
}
