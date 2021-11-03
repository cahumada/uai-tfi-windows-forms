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

namespace Gabe
{
    public partial class USR003_Title : Form
    {
        private int codigoUsuario;
        private Usuarios usuario = new Usuarios();
        private EstadosABM estado = new EstadosABM();


        public USR003_Title(int pCodigoUsuario, Usuarios pUsuario = null, EstadosABM pEstado = EstadosABM.Nuevo)
        {
            codigoUsuario = pCodigoUsuario;

            // Usuario en tratamiento
            if (pUsuario != null)
                usuario = pUsuario;


            // Requerimiento solicitado
            estado = pEstado;

            InitializeComponent();
        }

        /// <summary>
        /// Carga los controles según el estado
        /// </summary>
        private void CargarControles()
        {
            switch (estado)
            {
                case EstadosABM.BlanquearClave:
                    USR003_Grp01.Name = "USR003_Grp01";
                    CambiarUsuario();
                    break;
            }
        }

        private void CambiarUsuario(bool pGuardar = false)
        {
            if (pGuardar)
            {
                if (usuario == null)
                    usuario = new Usuarios();

                usuario.Nik = USR003_txtNik.Text;
            }
            else
            {
                if (usuario.UsuarioId > 0)
                    USR003_txtNik.Text = usuario.Nik;
            }
        }

        private void GEN001_Btn006_Click(object sender, EventArgs e)
        {
            if (USR003_txtPass.Text == USR003_txtCPass.Text)
            {
                if (!MasterForm.ControlErrores(this, ErrProv))
                {
                    switch (estado)
                    {
                        case EstadosABM.BlanquearClave:
                            if (usuario.UsuarioId > 0)
                                usuario.BlanquearContrasena(USR003_txtPass.Text.Trim());
                            break;
                    }

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR003_Val001"), "Gabe", MessageBoxButtons.OK);
            }
        }

        private void GEN001_Btn007_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void USR003_Title_Load(object sender, EventArgs e)
        {
            CargarControles();

            USR003_txtNik.Enabled = false;

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }
        }

        private void USR003_txtPass_Validating(object sender, CancelEventArgs e)
        {
            ErrProv.SetError(USR003_txtPass, "");

            if (string.IsNullOrEmpty(USR003_txtPass.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(USR003_txtPass, Idioma.ObtenerEtiqueta("GEN001_Val001"));
            }
        }

        private void USR003_txtCPass_Validating(object sender, CancelEventArgs e)
        {
            ErrProv.SetError(USR003_txtCPass, "");

            if (string.IsNullOrEmpty(USR003_txtCPass.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(USR003_txtCPass, Idioma.ObtenerEtiqueta("GEN001_Val001"));
            }
        }
    }
}
