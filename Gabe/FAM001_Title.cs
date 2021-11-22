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
    public partial class FAM001_Title : Form
    {
        private int codigoUsuario;
        private Familia familia = new Familia();
        private EstadosABM estado;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public FAM001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void FAM001_Title_Load(object sender, EventArgs e)
        {
            FAM001_DgrFam.Columns.Add("FAM001_DgrFam_cFamily", "Familia");
            FAM001_DgrFam.Columns.Add("FAM001_DgrFam_cDescript", "Descripción");
            FAM001_DgrFam.Columns.Add("FAM001_DgrFam_cShort_Desc", "Desc. Corta");

            FAM001_DgrFam.AutoGenerateColumns = false;
            FAM001_DgrFam.AllowUserToAddRows = false;
            FAM001_DgrFam.AllowUserToDeleteRows = false;
            FAM001_DgrFam.AllowUserToResizeRows = false;
            FAM001_DgrFam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FAM001_DgrFam.MultiSelect = false;
            FAM001_DgrFam.ReadOnly = true;
            FAM001_DgrFam.RowHeadersVisible = false;
            FAM001_DgrFam.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GEN001_Btn009.Visible = false;

            Limpiar();

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            ActualizarOrigen();

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Familias");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }

        private void ActualizarOrigen()
        {
            FAM001_DgrFam.Rows.Clear();

            foreach (var fam in familia.ObtenerFamilia())
            {
                FAM001_DgrFam.Rows.Add(fam.FamiliaId, fam.Descripcion, fam.DescCorta);
            }
        }

        private void Limpiar()
        {
            estado = EstadosABM.SinCambios;

            SeleccionarOpcion();
        }

        private void SeleccionarOpcion()
        {
            if (EstadosABM.Nuevo == estado || EstadosABM.Modificar == estado)
            {
                MasterForm.HabilitarControles(FAM001_Grp02, true);

                MasterForm.LimpiarControles(FAM001_Grp02);

                GEN001_Btn001.Enabled = false;
                GEN001_Btn002.Enabled = false;
                GEN001_Btn003.Enabled = false;
            }

            if (EstadosABM.Cancelar == estado)
            {
                MasterForm.HabilitarControles(FAM001_Grp02);

                MasterForm.LimpiarControles(FAM001_Grp02);

                // TODO
                GEN001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 27);
                GEN001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 28);
                GEN001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 29);

                ErrProv.Clear();
            }

            if (EstadosABM.SinCambios == estado)
            {
                MasterForm.HabilitarControles(FAM001_Grp02);

                MasterForm.LimpiarControles(FAM001_Grp02);

                MasterForm.LimpiarControles(GroupBox2);

                // TODO
                GEN001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 27);
                GEN001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 28);
                GEN001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 29);

                ErrProv.Clear();
            }
        }

        private void Validar()
        {
            ErrProv.SetError(FAM001_TxtDescript, "");

            if (string.IsNullOrEmpty(FAM001_TxtDescript.Text) || string.IsNullOrWhiteSpace(FAM001_TxtDescript.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(FAM001_TxtDescript, Idioma.ObtenerEtiqueta("FAM001_Val001"));
            }

            ErrProv.SetError(FAM001_TxtShort_Desc, "");

            if (string.IsNullOrEmpty(FAM001_TxtShort_Desc.Text) || string.IsNullOrWhiteSpace(FAM001_TxtShort_Desc.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(FAM001_TxtShort_Desc, Idioma.ObtenerEtiqueta("FAM001_Val002"));
            }
        }

        private void GEN001_Btn001_Click(object sender, EventArgs e)
        {
            estado = EstadosABM.Nuevo;

            SeleccionarOpcion();

            FAM001_TxtDescript.Clear();
            FAM001_TxtShort_Desc.Clear();
        }

        private void GEN001_Btn002_Click(object sender, EventArgs e)
        {
            if (FAM001_DgrFam.SelectedRows.Count > 0)
            {
                estado = EstadosABM.Modificar;

                SeleccionarOpcion();

                familia = new Familia((int)FAM001_DgrFam.SelectedRows[0].Cells[0].Value);

                FAM001_TxtDescript.Text = familia.Descripcion;
                FAM001_TxtShort_Desc.Text = familia.DescCorta;
            }
        }

        private void GEN001_Btn003_Click(object sender, EventArgs e)
        {
            if (FAM001_DgrFam.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Idioma.ObtenerEtiqueta("FAM001_Msg001"), "Gabe", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {
                    familia = new Familia((int)FAM001_DgrFam.SelectedRows[0].Cells[0].Value);

                    familia.Eliminar();

                    ActualizarOrigen();
                }
            }
        }

        private void GEN001_Btn009_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn007_Click(object sender, EventArgs e)
        {
            estado = EstadosABM.Cancelar;
            SeleccionarOpcion();
        }

        private void GEN001_Btn010_Click(object sender, EventArgs e)
        {
            Validar();

            if (!MasterForm.ControlErrores(this, ErrProv))
            {
                if (estado == EstadosABM.Nuevo)
                    familia = new Familia();

                if (familia != null)
                {
                    familia.Descripcion = FAM001_TxtDescript.Text;
                    familia.DescCorta = FAM001_TxtShort_Desc.Text;

                    familia.Guardar();
                }

                ActualizarOrigen();

                estado = EstadosABM.Cancelar;
                SeleccionarOpcion();
            }
        }
    }
}
