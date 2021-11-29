using eSecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eFramework;

namespace Gabe
{
    public partial class USR001_Title : Form
    {
        int codigoUsuario;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public USR001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void ActualizarOrigen()
        {
            USR001_DgrUsr.Rows.Clear();

            foreach (var usuario in new Usuarios().ObtenerUsuario())
            {
                USR001_DgrUsr.Rows.Add(usuario.UsuarioId, usuario.Nik, usuario.Intentos, usuario.Bloqueado, usuario.IdiomaId, (new Idioma(usuario.IdiomaId)).Descripcion, usuario.Contrasena);
            }
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn001_Click(object sender, EventArgs e)
        {
            // Agregado
            var form = new USR002_Title(codigoUsuario, null, EstadosABM.Nuevo);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            // No permite expandir el formulario
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            form.ShowDialog(this);

            ActualizarOrigen();

        }

        private void GEN001_Btn002_Click(object sender, EventArgs e)
        {
            // Modificado
            if (USR001_DgrUsr.SelectedRows.Count > 0)
            {
                var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

                var form = new USR002_Title(codigoUsuario, usuario, EstadosABM.Modificar);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.MaximizeBox = false;
                // No permite expandir el formulario
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

                form.ShowDialog(this);

                ActualizarOrigen();
            }

        }

        private void GEN001_Btn003_Click(object sender, EventArgs e)
        {
            // Eliminado
            if (USR001_DgrUsr.SelectedRows.Count > 0)
            {
                var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

                var form = new USR002_Title(codigoUsuario, usuario, EstadosABM.Eliminar);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.MaximizeBox = false;
                // No permite expandir el formulario
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

                form.ShowDialog(this);

                ActualizarOrigen();
            }
            else
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR001_Val001"), "Gabe", MessageBoxButtons.OK);
            }

        }

        private void USR001_Btn002_Click(object sender, EventArgs e)
        {
            // Desbloquear
            if (USR001_DgrUsr.SelectedRows.Count > 0)
            {
                // Si está bloqueado
                if ((bool)USR001_DgrUsr.SelectedRows[0].Cells[3].Value)
                {
                    var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

                    var form = new USR002_Title(codigoUsuario, usuario, EstadosABM.Desbloquear);

                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.MaximizeBox = false;
                    // No permite expandir el formulario
                    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

                    form.ShowDialog(this);

                    ActualizarOrigen();
                }
                else
                {
                    MessageBox.Show(Idioma.ObtenerEtiqueta("USR001_Val002"), "Gabe", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR001_Val001"), "Gabe", MessageBoxButtons.OK);
            }
            
        }

        private void USR001_Btn003_Click(object sender, EventArgs e)
        {
            // Reset
            if (USR001_DgrUsr.SelectedRows.Count > 0)
            {
                var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

                var form = new USR003_Title(codigoUsuario, usuario, EstadosABM.BlanquearClave);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.MaximizeBox = false;
                // No permite expandir el formulario
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

                form.ShowDialog(this);

                ActualizarOrigen();
            }
            else
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR001_Val001"), "Gabe", MessageBoxButtons.OK);
            }
        }

        private void USR001_Btn001_Click(object sender, EventArgs e)
        {
            // Modificado Idioma
            if (USR001_DgrUsr.SelectedRows.Count > 0)
            {
                var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

                var form = new USR002_Title(codigoUsuario, usuario, EstadosABM.CambiarIdioma);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.MaximizeBox = false;
                // No permite expandir el formulario
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

                form.ShowDialog(this);

                ActualizarOrigen();
            }
            else
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR001_Val001"), "Gabe", MessageBoxButtons.OK);
            }
        }

        private void USR001_DgrUsr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var usuario = new Usuarios((int)USR001_DgrUsr.SelectedRows[0].Cells[0].Value);

            var form = new USR002_Title(codigoUsuario, usuario, EstadosABM.Consulta);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            // No permite expandir el formulario
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            form.ShowDialog(this);
        }

        private void USR001_Title_Load_1(object sender, EventArgs e)
        {
            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cUser", "Usuario");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cNik", "Alias");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cAttemptsBlock", "Intento de Bloqueo");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cIs_Blocked", "Bloqueado");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cCodLanguage", "CodLenguage");
            USR001_DgrUsr.Columns["USR001_DgrUsr_cCodLanguage"].Visible = false;

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cLanguage", "Lenguage");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cPassword", "Contraseña");
            USR001_DgrUsr.Columns["USR001_DgrUsr_cPassword"].Visible = false;

            USR001_DgrUsr.AutoGenerateColumns = false;
            USR001_DgrUsr.AllowUserToAddRows = false;
            USR001_DgrUsr.AllowUserToDeleteRows = false;
            USR001_DgrUsr.AllowUserToResizeRows = false;
            USR001_DgrUsr.AutoSize = true;
            USR001_DgrUsr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            USR001_DgrUsr.MultiSelect = false;
            USR001_DgrUsr.ReadOnly = true;
            USR001_DgrUsr.RowHeadersVisible = false;
            USR001_DgrUsr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GEN001_Btn002.Visible = false;

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
                MasterForm.AplicarIdioma(this);

            //Acualizo grilla
            ActualizarOrigen();

            // *** Verifico permisos
            // Alta Usuario
            GEN001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 10);
            // Baja Usuario
            GEN001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 11);
            // Desbloquear
            USR001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 12);
            // Blanquear Pass
            USR001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 13);
            // Modificado Idioma
            USR001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 14);

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Usuarios");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }
    }
}
