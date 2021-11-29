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
    public partial class BKP001_Title : Form
    {
        private int codigoUsuario;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public BKP001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void BKP001_Title_Load(object sender, EventArgs e)
        {
            Limpiar();

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Backup");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }

        public void Limpiar()
        {
            BKP001_txtPath.Enabled = false;
            BKP001_txtPath.Text = string.Empty;

            BKP001_NumFiles.Value = 1;
            BKP001_NumFiles.Maximum = 10;
            BKP001_NumFiles.Minimum = 1;
        }

        private void BKP001_txtPath_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(BKP001_txtPath.Text))
            {
                {
                    var withBlock = ErrProv;
                    withBlock.BlinkRate = 200;
                    withBlock.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    withBlock.SetError(BKP001_txtPath, Idioma.ObtenerEtiqueta("BKP001_Val001"));
                }
            }
            else
                ErrProv.SetError(BKP001_txtPath, "");
        }

        private void GEN001_Btn012_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
                BKP001_txtPath.Text = FolderBrowserDialog1.SelectedPath;
        }

        private void GEN001_Btn007_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GEN001_Btn006_Click(object sender, EventArgs e)
        {
            BKP001_txtPath_Validating(BKP001_txtPath, new CancelEventArgs());

            if (!MasterForm.ControlErrores(this, ErrProv))
            {
                BackupRestore bkp = new BackupRestore();

                GEN001_Btn006.Enabled = false;

                try
                {
                    if (bkp.RealizarBackup(BKP001_txtPath.Text, Convert.ToInt32(BKP001_NumFiles.Value), codigoUsuario))
                        MessageBox.Show(Idioma.ObtenerEtiqueta("BKP001_Msg001"), "Gabe", MessageBoxButtons.OK);

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
