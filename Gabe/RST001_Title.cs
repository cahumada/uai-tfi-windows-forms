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
using eSecurity;

namespace Gabe
{
    public partial class RST001_Title : Form
    {
        private int codigoUsuario;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public RST001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void RST001_Title_Load(object sender, EventArgs e)
        {
            Limpiar();

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Restore");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }

        public void Limpiar()
        {
            RST001_txtPath.Enabled = false;
            RST001_txtPath.Text = string.Empty;

            RST001_NumFiles.Value = 1;
            RST001_NumFiles.Maximum = 10;
            RST001_NumFiles.Minimum = 1;
        }

        private void RST001_txtPath_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(RST001_txtPath.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(RST001_txtPath, Idioma.ObtenerEtiqueta("RST001_Val001"));
            }
            else
                ErrProv.SetError(RST001_txtPath, "");
        }

        private void GEN001_Btn012_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
                RST001_txtPath.Text = FolderBrowserDialog1.SelectedPath;
        }

        private void GEN001_Btn007_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GEN001_Btn006_Click(object sender, EventArgs e)
        {
            RST001_txtPath_Validating(RST001_txtPath, new CancelEventArgs());

            if (!MasterForm.ControlErrores(this, ErrProv))
            {
                BackupRestore bkp = new BackupRestore();

                GEN001_Btn006.Enabled = false;

                try
                {
                    if (bkp.RealizarRestore(RST001_txtPath.Text, Convert.ToInt32(RST001_NumFiles.Value), codigoUsuario))
                        MessageBox.Show(Idioma.ObtenerEtiqueta("RST001_Msg001"), "Gabe", MessageBoxButtons.OK);

                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gabe", MessageBoxButtons.OK);
                }
                finally
                {
                    GEN001_Btn006.Enabled = true;
                }
            }
        }
    }
}
