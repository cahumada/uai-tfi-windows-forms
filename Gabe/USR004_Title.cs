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
    public partial class USR004_Title : Form
    {
        private int codigoUsuario;
        private Usuarios usuario = new Usuarios();

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public USR004_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void USR004_Title_Load(object sender, EventArgs e)
        {
            USR004_DgrFam.Columns.Add("USR004_DgrFam_cIndexCollection", "IndexCollection");
            USR004_DgrFam.Columns["USR004_DgrFam_cIndexCollection"].Visible = false;

            var checkColumn = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Check Data",
                Name = "USR004_DgrFam_cChecked",
                ReadOnly = !UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 15)
            };
            USR004_DgrFam.Columns.Add(checkColumn);

            USR004_DgrFam.Columns.Add("USR004_DgrFam_cCodFamily", "Cod Familia");
            USR004_DgrFam.Columns.Add("USR004_DgrFam_cFamily", "Familia");

            USR004_DgrFam.AutoGenerateColumns = false;
            USR004_DgrFam.AllowUserToAddRows = false;
            USR004_DgrFam.AllowUserToDeleteRows = false;
            USR004_DgrFam.AllowUserToResizeRows = false;
            USR004_DgrFam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            USR004_DgrFam.MultiSelect = false;
            USR004_DgrFam.ReadOnly = true;
            USR004_DgrFam.RowHeadersVisible = false;
            USR004_DgrFam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            USR004_CliCtrl.CodigoUsuario = codigoUsuario;
            USR004_CliCtrl.Estado = EstadosABM.Consulta;
            usuario = null;

            GEN001_Btn009.Enabled = false;
            GEN001_Btn010.Enabled = false;

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
            USR004_DgrFam.Rows.Clear();

            if (usuario != null && usuario.UsuarioId > 0)
            {
                foreach (var familia in usuario.Familias)
                {
                    USR004_DgrFam.Rows.Add(familia.IndiceLista, true, familia.FamiliaId, familia.Descripcion);
                }

                foreach (var familia in (new Familia()).ObtenerFamilia())
                {
                    if (!usuario.ExisteFamilia(familia))
                    {
                        USR004_DgrFam.Rows.Add(0, false, familia.FamiliaId, familia.Descripcion);
                    }
                }
            }


        }

        private void Limpiar()
        {
            MasterForm.HabilitarControles(USR004_Grp01, true);

            USR004_CliCtrl.CodigoUsuario = codigoUsuario;
            USR004_CliCtrl.Estado = EstadosABM.Consulta;
            USR004_CliCtrl.TxtUser.Text = String.Empty;

            GEN001_Btn009.Enabled = false;
            GEN001_Btn010.Enabled = false;

            usuario = null;

            ActualizarOrigen();
        }

        private void GEN001_Btn008_Click(object sender, EventArgs e)
        {
            if (USR004_CliCtrl.LblUser.Text != string.Empty)
            {
                usuario = new Usuarios(System.Convert.ToInt32(USR004_CliCtrl.TxtUser.Text));

                MasterForm.HabilitarControles(USR004_Grp01, false);

                GEN001_Btn009.Enabled = true;
                GEN001_Btn010.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 15);

                ActualizarOrigen();
            }
            else
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR004_Val001"), "Gabe", MessageBoxButtons.OK);
        }

        private void GEN001_Btn009_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn010_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                if (MessageBox.Show(Idioma.ObtenerEtiqueta("GEN001_Msg001"),"Gabe",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    usuario.PersistirFamilias();
                    Limpiar();
                }
            }
        }

        private void USR004_DgrFam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si tiene permisos para otorgar o denegar patentes
            if (UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 15))
            {
                {
                    if (e.ColumnIndex == USR004_DgrFam.Columns["USR004_DgrFam_cChecked"].Index)
                    {
                        var indice = Convert.ToInt32(USR004_DgrFam.Rows[e.RowIndex].Cells["USR004_DgrFam_cIndexCollection"].Value);

                        if (Convert.ToBoolean(USR004_DgrFam.Rows[e.RowIndex].Cells["USR004_DgrFam_cChecked"].Value))
                        {
                            // Si existe en la colección se quita de la misma
                            if (indice >= 0)
                                usuario.QuitarFamilia(usuario.ObtenerFamiliaIndice(indice));
                            else
                                usuario.AgregarFamilia(new Familia(Convert.ToInt32(USR004_DgrFam.Rows[e.RowIndex].Cells["USR004_DgrFam_cCodFamily"].Value)));

                            ActualizarOrigen();
                        }
                        else if (indice <= 0)
                        {
                            usuario.AgregarFamilia(new Familia(Convert.ToInt32(USR004_DgrFam.Rows[e.RowIndex].Cells["USR004_DgrFam_cCodFamily"].Value)));

                            ActualizarOrigen();
                        }
                    }
                }
            }
        }
    }
}
