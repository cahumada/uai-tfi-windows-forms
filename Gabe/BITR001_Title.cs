using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using eSecurity;

namespace Gabe
{
    public partial class BITR001_Title : Form
    {
        private int codigoUsuario;
        private DataTable dt = new DataTable();

        private HelpProvider helpProvider = new HelpProvider();

        public DataTable DataSource
        {
            set
            {
                dt = value;
            }
        }

        public BITR001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void BITR001_Title_Load(object sender, EventArgs e)
        {
            ImpresionBitacora mReporte = new ImpresionBitacora();

            var reporteUsuario = ConfigurationManager.AppSettings["ReportUsr"];
            var reporteContrasena = ConfigurationManager.AppSettings["ReportPass"];
            var reporteServidor = ConfigurationManager.AppSettings["ReportServer"];


            mReporte.SetDatabaseLogon(reporteUsuario, reporteContrasena, reporteServidor, "GabeDB");
            mReporte.DataSourceConnections[0].IntegratedSecurity = true;

            // Asigno DT que obtengo por la propiedad
            mReporte.SetDataSource(dt);

            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            crystalReportViewer1.ReportSource = mReporte;

            // Seteo Idioma
            if ((new Idioma()).ObtenerIdiomaPorDefecto(codigoUsuario))
                MasterForm.AplicarIdioma(this);

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Imprimir Bitácora");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
