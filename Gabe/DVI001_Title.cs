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
using eSecurity;

namespace Gabe
{
    public partial class DVI001_Title : Form
    {
        int codigoUsuario;
        EstadosABM estado;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public DVI001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void DVI001_Title_Load(object sender, EventArgs e)
        {
            DVI001_DgrDVI.Columns.Add("DVI001_DgrDVI_cId", "Num");
            DVI001_DgrDVI.Columns.Add("DVI001_DgrDVI_cTable", "Tabla");


            DVI001_DgrDVI.AutoGenerateColumns = false;
            DVI001_DgrDVI.AllowUserToAddRows = false;
            DVI001_DgrDVI.AllowUserToDeleteRows = false;
            DVI001_DgrDVI.AllowUserToResizeRows = false;
            DVI001_DgrDVI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DVI001_DgrDVI.MultiSelect = false;
            DVI001_DgrDVI.ReadOnly = true;
            DVI001_DgrDVI.RowHeadersVisible = false;
            DVI001_DgrDVI.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            ActualizarOrigen();

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Usuario Familia");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }

        private void ActualizarOrigen()
        {
            DVI001_DgrDVI.Rows.Clear();

            var mDt = DigitoVerificador.ObtenerErroresIntegridad();

            if (mDt != null && mDt.Rows.Count > 0)
            {
                foreach (DataRow dr in mDt.Rows)
                {
                    var id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt32(dr["Id"]);
                    var nombreTabla = Convert.IsDBNull(dr["NombreTabla"]) ? string.Empty : dr["NombreTabla"];

                    DVI001_DgrDVI.Rows.Add(id, nombreTabla);
                 
                }

                DVI001_Btn001.Enabled = true;
            }
            else
                DVI001_Btn001.Enabled = false;

        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DVI001_Btn001_Click(object sender, EventArgs e)
        {
            try
            {
                DigitoVerificador.ReCalcularDigitosVerificadores(codigoUsuario);

                ActualizarOrigen();

                MessageBox.Show(Idioma.ObtenerEtiqueta("DVI_Msg001"), "Gabe", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Idioma.ObtenerEtiqueta("DVI_Msg002") + " " + ex.Message, "Gabe", MessageBoxButtons.OK);
            }
        }
    }
}
