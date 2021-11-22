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
    public partial class PAT001_Title : Form
    {
        private int codigoUsuario;
        private Patente patente = new Patente();
        private EstadosABM estado;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public PAT001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void PAT001_Title_Load(object sender, EventArgs e)
        {
            PAT001_DgrPat.Columns.Add("PAT001_DgrPat_cPatent", "Patente");
            PAT001_DgrPat.Columns.Add("PAT001_DgrPat_cDescript", "Descripción");
            PAT001_DgrPat.Columns.Add("PAT001_DgrPat_cShort_Desc", "Desc. Corta");

            PAT001_DgrPat.AutoGenerateColumns = false;
            PAT001_DgrPat.AllowUserToAddRows = false;
            PAT001_DgrPat.AllowUserToDeleteRows = false;
            PAT001_DgrPat.AllowUserToResizeRows = false;
            PAT001_DgrPat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PAT001_DgrPat.MultiSelect = false;
            PAT001_DgrPat.ReadOnly = true;
            PAT001_DgrPat.RowHeadersVisible = false;
            PAT001_DgrPat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GEN001_Btn009.Visible = false;

            Limpiar();

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            ActualizarOrigen();

            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Patentes");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }

        private void ActualizarOrigen()
        {
            PAT001_DgrPat.Rows.Clear();

            foreach (var pat in patente.ObtenerPatente())
            {
                PAT001_DgrPat.Rows.Add(pat.PatenteId, pat.Descripcion, pat.DescCorta);
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
                MasterForm.HabilitarControles(PAT001_Grp02, true);

                MasterForm.LimpiarControles(PAT001_Grp02);

                GEN001_Btn001.Enabled = false;
                GEN001_Btn002.Enabled = false;
                GEN001_Btn003.Enabled = false;
            }

            if (EstadosABM.Cancelar == estado)
            {
                MasterForm.HabilitarControles(PAT001_Grp02);

                MasterForm.LimpiarControles(PAT001_Grp02);

                // TODO
                GEN001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 31);
                GEN001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 32);
                GEN001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 33);

                ErrProv.Clear();
            }

            if (EstadosABM.SinCambios == estado)
            {
                MasterForm.HabilitarControles(PAT001_Grp02);

                MasterForm.LimpiarControles(PAT001_Grp02);

                MasterForm.LimpiarControles(GroupBox2);

                // TODO
                GEN001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 31);
                GEN001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 32);
                GEN001_Btn003.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 33);

                ErrProv.Clear();
            }
        }

        private void Validar()
        {
            ErrProv.SetError(PAT001_TxtDescript, "");

            if (string.IsNullOrEmpty(PAT001_TxtDescript.Text) || string.IsNullOrWhiteSpace(PAT001_TxtDescript.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(PAT001_TxtDescript, Idioma.ObtenerEtiqueta("PAT001_Val001"));
            }

            ErrProv.SetError(PAT001_TxtShort_Desc, "");

            if (string.IsNullOrEmpty(PAT001_TxtShort_Desc.Text) || string.IsNullOrWhiteSpace(PAT001_TxtShort_Desc.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(PAT001_TxtShort_Desc, Idioma.ObtenerEtiqueta("PAT001_Val002"));
            }
        }

        private void GEN001_Btn001_Click(object sender, EventArgs e)
        {
            estado = EstadosABM.Nuevo;

            SeleccionarOpcion();

            PAT001_TxtDescript.Clear();
            PAT001_TxtShort_Desc.Clear();
        }

        private void GEN001_Btn002_Click(object sender, EventArgs e)
        {
            if (PAT001_DgrPat.SelectedRows.Count > 0)
            {
                estado = EstadosABM.Modificar;

                SeleccionarOpcion();

                patente = new Patente((int)PAT001_DgrPat.SelectedRows[0].Cells[0].Value);

                PAT001_TxtDescript.Text = patente.Descripcion;
                PAT001_TxtShort_Desc.Text = patente.DescCorta;
            }
        }

        private void GEN001_Btn003_Click(object sender, EventArgs e)
        {
            if (PAT001_DgrPat.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Idioma.ObtenerEtiqueta("PAT001_Msg001"), "Gabe", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {
                    patente = new Patente((int)PAT001_DgrPat.SelectedRows[0].Cells[0].Value);

                    patente.Eliminar();

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
                    patente = new Patente();

                if (patente != null)
                {
                    patente.Descripcion = PAT001_TxtDescript.Text;
                    patente.DescCorta= PAT001_TxtShort_Desc.Text;

                    patente.Guardar();
                }

                ActualizarOrigen();

                estado = EstadosABM.Cancelar;
                SeleccionarOpcion();
            }
        }
    }
}
