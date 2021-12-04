using eSecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public partial class Login_Title : Form
    {
        private Usuarios usuario = new Usuarios();

        public Login_Title()
        {
            InitializeComponent();
        }

        private void Login_Title_Load(object sender, EventArgs e)
        {
            //Seteo Idioma
            if ((new Idioma()).ObtenerIdiomaPorDefecto())
                MasterForm.AplicarIdioma(this);

            //Muestra el Splash de la aplicación
            ShowSplashScreen();

            Login_txtUser.Text = string.Empty;
            Login_txtPass.Text = string.Empty;
        }

        private void ShowSplashScreen()
        {
            using (var splash = new Gabe_Splash())
            {
                if (splash.ShowDialog() == DialogResult.Cancel)
                    this.Close();
            }
        }

        private void Login_BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_BtnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login_txtUser.Text) && !string.IsNullOrEmpty(Login_txtPass.Text))
            {
                if (usuario.ValidarClaveUsuario(Login_txtUser.Text, Login_txtPass.Text))
                {
                    // Oculta el login
                    this.Visible = false;
                    using (var mdiGabe = new MDI_Gabe(usuario))
                    {
                        mdiGabe.ShowDialog();
                    }
                }
                else
                {
                    if (usuario.Intentos > 0 && !usuario.Bloqueado) // Mensaje de intentos
                        MessageBox.Show(string.Format(Idioma.ObtenerEtiqueta("Login_Msg004"), usuario.Intentos.ToString()), "Gabe", MessageBoxButtons.OK);

                    // Usuario y contraseña inválida
                    MessageBox.Show(Idioma.ObtenerEtiqueta("Login_Msg001"), "Gabe", MessageBoxButtons.OK);


                    if (usuario.Bloqueado) // Usuario bloqueado
                        MessageBox.Show(Idioma.ObtenerEtiqueta("Login_Msg003"), "Gabe", MessageBoxButtons.OK);

                }

            }
            else
                MessageBox.Show(Idioma.ObtenerEtiqueta("Login_Msg002"), "Gabe", MessageBoxButtons.OK); // Debe completar el usuario y contraseña1
        }
    }
}
