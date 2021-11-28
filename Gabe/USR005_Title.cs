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
    public partial class USR005_Title : Form
    {
        internal int codigoUsuario;
        private Usuarios usuario = new Usuarios();

        private HelpProvider helpProvider = new HelpProvider();
        private ToolTip toolTip = new ToolTip();

        public USR005_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void USR005_Title_Load(object sender, EventArgs e)
        {
            USR005_DgrPat.Columns.Add("USR005_DgrPat_cIndexCollection", "IndexCollection");
            USR005_DgrPat.Columns["USR005_DgrPat_cIndexCollection"].Visible = false;

            USR005_DgrPat.Columns.Add("USR005_DgrPat_cFamily", "Familia");
            USR005_DgrPat.Columns["USR005_DgrPat_cFamily"].ReadOnly = true;

            var chkSelecciona = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Check Data",
                Name = "USR005_DgrPat_cChecked",
                ReadOnly = false
            };
            USR005_DgrPat.Columns.Add(chkSelecciona);

            USR005_DgrPat.Columns.Add("USR005_DgrPat_cCodPatent", "Cod Patente");
            USR005_DgrPat.Columns.Add("USR005_DgrPat_cPatent", "Patente");

            var chkDenegar = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Deniega",
                Name = "USR005_DgrPat_cIsDeny",
                ReadOnly = false
            };
            USR005_DgrPat.Columns.Add(chkDenegar);

            USR005_DgrPat.AutoGenerateColumns = false;
            USR005_DgrPat.AllowUserToAddRows = false;
            USR005_DgrPat.AllowUserToDeleteRows = false;
            USR005_DgrPat.AllowUserToResizeRows = false;
            USR005_DgrPat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            USR005_DgrPat.MultiSelect = false;
            USR005_DgrPat.ReadOnly = true;
            USR005_DgrPat.RowHeadersVisible = false;
            USR005_DgrPat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            USR005_CliCtrl.CodigoUsuario = codigoUsuario;
            USR005_CliCtrl.Estado = EstadosABM.Consulta;
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
            USR005_DgrPat.Rows.Clear();

            if (usuario != null && usuario.UsuarioId > 0)
            {
                foreach (var patente in usuario.Patentes)
                {
                    USR005_DgrPat.Rows.Add(patente.IndiceLista, patente.Familia, true, patente.Patente.PatenteId, patente.Patente.Descripcion, patente.Denegado);
                }

                foreach (var patente in (new Patente()).ObtenerPatente())
                {
                    if (!usuario.ExistePatente(patente))
                    {
                        USR005_DgrPat.Rows.Add(null, null, false, patente.PatenteId, patente.Descripcion, false);
                    }
                }
            }


        }

        private void Limpiar()
        {
            MasterForm.HabilitarControles(USR005_Grp01, true);

            USR005_CliCtrl.CodigoUsuario = codigoUsuario;
            USR005_CliCtrl.Estado = EstadosABM.Consulta;
            USR005_CliCtrl.TxtUser.Text = String.Empty;

            GEN001_Btn009.Enabled = false;
            GEN001_Btn010.Enabled = false;

            usuario = null;

            ActualizarOrigen();
        }

        private void GEN001_Btn008_Click(object sender, EventArgs e)
        {
            if (USR005_CliCtrl.LblUser.Text != string.Empty)
            {
                usuario = new Usuarios(System.Convert.ToInt32(USR005_CliCtrl.TxtUser.Text));

                MasterForm.HabilitarControles(USR005_Grp01, false);

                GEN001_Btn009.Enabled = true;
                GEN001_Btn010.Enabled = UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 17);

                ActualizarOrigen();
            }
            else
                MessageBox.Show(Idioma.ObtenerEtiqueta("USR005_Val001"), "Gabe", MessageBoxButtons.OK);
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn009_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void GEN001_Btn010_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                if (MessageBox.Show(Idioma.ObtenerEtiqueta("GEN001_Msg001"), "Gabe", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    usuario.PersistirPatentes();
                    Limpiar();
                }
            }
        }

        private void USR005_DgrPat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si tiene permisos para otorgar o denegar patentes
            if (UsuarioPatente.UsuarioPatenteHabilitada(codigoUsuario, 17))
            {
                {
                    var indice = Convert.ToInt32(USR005_DgrPat.Rows[e.RowIndex].Cells["USR005_DgrPat_cIndexCollection"].Value);

                    // Si lo que se modifica es el checkbox de denegar y no proviende de una familia
                    if (e.ColumnIndex == USR005_DgrPat.Columns["USR005_DgrPat_cIsDeny"].Index 
                        && USR005_DgrPat.Rows[e.RowIndex].Cells[1].Value == null) // Sin familia
                    {
                        var seleccionado = Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[2].Value); // USR005_DgrPat_cChecked
                        var denegado = Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value); // USR005_DgrPat_cIsDeny

                        // Si no existe la patente del usuario y se intenta denegar la patente, se establece en falso
                        if (!seleccionado && denegado)
                        {
                            USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value = false;
                        }
                        else
                        {
                            denegado = !denegado;

                            USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value = denegado;

                            if (indice > 0)
                            {
                                usuario.CambiarEstadoPorIndice(indice, Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value));

                                if (!Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value))
                                {
                                    USR005_DgrPat.Rows[e.RowIndex].Cells[2].Value = false; // Quito selección

                                    usuario.QuitarPatente(usuario.ObtenerPatenteIndice(indice));
                                }
                                else
                                {
                                    var usuarioPatente = new UsuarioPatente(usuario.UsuarioId, Convert.ToInt32(USR005_DgrPat.Rows[e.RowIndex].Cells[3].Value)); // Cod. Patente
                                    usuarioPatente.Denegado = denegado;

                                    usuario.AgregarPatente(usuarioPatente);
                                }
                            }
                        }
                    }

                    // Si lo que se esta cambiando es el checkbox de selección de patente y no proviene de una familia
                    if (e.ColumnIndex == USR005_DgrPat.Columns["USR005_DgrPat_cChecked"].Index
                    && string.IsNullOrEmpty(USR005_DgrPat.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        var seleccionado = !Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[2].Value); // USR005_DgrPat_cChecked
                        var denegado = Convert.ToBoolean(USR005_DgrPat.Rows[e.RowIndex].Cells[5].Value); // USR005_DgrPat_cIsDeny

                        if (seleccionado)
                        {
                            // Si existe en la colección se quita de la misma
                            if (indice < 0)
                                usuario.QuitarPatente(usuario.ObtenerPatenteIndice(indice));
                            else
                            {
                                var usuarioPatente = new UsuarioPatente(usuario.UsuarioId, Convert.ToInt32(USR005_DgrPat.Rows[e.RowIndex].Cells[3].Value)); // Cod. Patente
                                usuarioPatente.Denegado = denegado;

                                usuario.AgregarPatente(usuarioPatente);
                            }

                            ActualizarOrigen();
                        }
                        else if (indice >= 0)
                        {
                            usuario.QuitarPatente(usuario.ObtenerPatenteIndice(indice));

                            ActualizarOrigen();
                        }
                    }
                    
                }
            }
        }
    }
}
