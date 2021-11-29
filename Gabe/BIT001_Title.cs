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
    public partial class BIT001_Title : Form
    {
        private int codigoUsuario;
        private int usuarioBusqueda;
        private int criticidad;
        private DateTime fechaDesde;
        private DateTime fechahasta;

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public BIT001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void BIT001_Title_Load(object sender, EventArgs e)
        {
            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cLog", "Log");

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cUser", "CUser");
            BIT001_DgrBit.Columns["BIT001_DgrBit_cUser"].Visible = false;

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cNik", "Usuario");

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cCodTypMovement", "Cod Tipo Movimiento");
            BIT001_DgrBit.Columns["BIT001_DgrBit_cCodTypMovement"].Visible = false;

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cTypMovement", "Tipo Movimiento");

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cCodCriticality", "Cod Criticidad");
            BIT001_DgrBit.Columns["BIT001_DgrBit_cCodCriticality"].Visible = false;

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cCriticality", "Criticidad");

            BIT001_DgrBit.Columns.Add("BIT001_DgrBit_cEffectDate", "Fecha");
            BIT001_DgrBit.Columns["BIT001_DgrBit_cEffectDate"].ValueType = typeof(DateTime);

            BIT001_DgrBit.AutoGenerateColumns = false;
            BIT001_DgrBit.AllowUserToAddRows = false;
            BIT001_DgrBit.AllowUserToDeleteRows = false;
            BIT001_DgrBit.AllowUserToResizeRows = false;
            BIT001_DgrBit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BIT001_DgrBit.MultiSelect = false;
            BIT001_DgrBit.ReadOnly = true;
            BIT001_DgrBit.RowHeadersVisible = false;
            BIT001_DgrBit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BIT001_UsrCtrl.CodigoUsuario = codigoUsuario;
            BIT001_UsrCtrl.Estado = EstadosABM.Consulta;

            BIT001_CmbCriticality.DropDownStyle = ComboBoxStyle.DropDownList;

            // Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            // Carga el combo de criticidad
            ActualizarCriticidad();

            // *** Verifico permisos
            // Depurar Bitacora
            BIT001_Btn001.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 16); //TODO
            BIT001_Btn002.Enabled = false;


            helpProvider.HelpNamespace = ConfigurationManager.AppSettings["HelpFile"];
            helpProvider.SetHelpKeyword(this, "Bitácora");
            helpProvider.SetHelpNavigator(this, HelpNavigator.KeywordIndex);

            MasterForm.ModificarToolTip(this, toolTip);
        }
        
        private void ActualizarOrigen()
        {
            BIT001_DgrBit.Rows.Clear();

            if (BIT001_ChkAll.Checked)
            {
                foreach (Bitacora bitacora in (new Bitacora()).ObtenerBitacora())
                {
                    BIT001_DgrBit.Rows.Add(bitacora.LogId,
                                            bitacora.UsuarioId,
                                            (new Usuarios(bitacora.UsuarioId).Nik),
                                            bitacora.MovimientoId,
                                            (new TipoMovimiento(bitacora.MovimientoId).Descripcion),
                                            bitacora.CriticidadId,
                                            (new Criticidad(bitacora.CriticidadId).Descripcion),
                                            bitacora.FechaMovimiento);
                }
            }
            else
                foreach (Bitacora bitacora in (new Bitacora()).ObtenerBitacora(fechaDesde, fechahasta, usuarioBusqueda, criticidad))
                {

                    BIT001_DgrBit.Rows.Add(bitacora.LogId,
                                            bitacora.UsuarioId,
                                            (new Usuarios(bitacora.UsuarioId).Nik),
                                            bitacora.MovimientoId,
                                            (new TipoMovimiento(bitacora.MovimientoId).Descripcion),
                                            bitacora.CriticidadId,
                                            (new Criticidad(bitacora.CriticidadId).Descripcion),
                                            bitacora.FechaMovimiento);
                }

            BIT001_Btn002.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 54);


        }

        private void ActualizarCriticidad()
        {
            BIT001_CmbCriticality.DataSource = (new Criticidad()).ObtenerCriticidad();
            BIT001_CmbCriticality.DisplayMember = "Descripcion";
            BIT001_CmbCriticality.ValueMember = "CriticidadId";
        }
        private void Limpiar()
        {
            MasterForm.HabilitarControles(BIT001_Grp01, true);
            BIT001_ChkAll.Checked = false;
            BIT001_DgrBit.Rows.Clear();
            BIT001_Btn002.Enabled = false;
        }

        private void GEN001_Btn005_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BIT001_UsrCtrl.TxtUser.Text))
                usuarioBusqueda = Convert.ToInt32(BIT001_UsrCtrl.TxtUser.Text);

            criticidad = Convert.ToInt32(BIT001_CmbCriticality.SelectedValue);

            fechaDesde = BIT001_Dtm01.Value;

            fechahasta = BIT001_Dtm02.Value;

            ActualizarOrigen();

            MasterForm.HabilitarControles(BIT001_Grp01);
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn009_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void BIT001_Btn001_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Idioma.ObtenerEtiqueta("BIT001_Msg001"), "Gabe",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (BIT001_ChkAll.Checked)
                    Bitacora.EliminarBitacora();
                else
                    Bitacora.EliminarBitacora(BIT001_Dtm01.Value, BIT001_Dtm02.Value, Convert.ToInt32(BIT001_UsrCtrl.TxtUser.Text), Convert.ToInt32(BIT001_CmbCriticality.SelectedValue));

                Limpiar();
            }
        }

        private void BIT001_ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (BIT001_ChkAll.Checked)
            {
                BIT001_Dtm01.Enabled = false;
                BIT001_Dtm02.Enabled = false;
                BIT001_UsrCtrl.Enabled = false;
                BIT001_CmbCriticality.Enabled = false;
            }
            else
            {
                BIT001_Dtm01.Enabled = true;
                BIT001_Dtm02.Enabled = true;
                BIT001_UsrCtrl.Enabled = true;
                BIT001_CmbCriticality.Enabled = true;
            }
        }
    }
}
