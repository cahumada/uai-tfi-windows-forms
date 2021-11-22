using eFramework;
using eSecurity;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public partial class MDI_Gabe : Form
    {
        private DataTable _Dt;
        private Usuarios _Usuario;

        public MDI_Gabe()
        {
            InitializeComponent();
        }

        public MDI_Gabe(Usuarios pUsuario)
        {
            InitializeComponent();

            _Usuario = pUsuario;
        }

        private void MDI_Gabe_Load(object sender, EventArgs e)
        {
            if (new Idioma().ObtenerIdiomaPorDefecto(_Usuario.UsuarioId))
                MasterForm.AplicarIdioma(this);

            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;

            _Dt = MyMenu.GenerarMenu();

            for (int nPrincipal = 0; nPrincipal < _Dt.Rows.Count; nPrincipal++)
            {
                var _Descripcion = _Dt.Rows[nPrincipal]["Descripcion"].ToString();
                var _Etiqueta = Idioma.ObtenerEtiqueta(_Descripcion);

                var _Menu = new ToolStripMenuItem(_Etiqueta, null, MenuClick, _Etiqueta);
                _Menu.DisplayStyle = ToolStripItemDisplayStyle.Text;
                _Menu.Tag = _Etiqueta;
                _Menu.Enabled = (_Descripcion == "MDI_Gabe_Mnu005");

                if (string.IsNullOrEmpty(_Dt.Rows[nPrincipal]["HijoDe"].ToString()))
                {
                    if (!string.IsNullOrEmpty(_Dt.Rows[nPrincipal]["FamiliaId"].ToString()))
                    {
                        foreach (UsuarioFamilia _Familia in _Usuario.Familias)
                        {
                            if (_Dt.Rows[nPrincipal]["FamiliaId"].ToString() == _Familia.Familia.FamiliaId.ToString())
                                _Menu.Enabled = true;
                        }
                    }

                    menuStrip1.Items.Add(_Menu);
                }

                AgregarSubMenu(_Dt.Rows[nPrincipal]["Id"].ToString(), _Menu);
            }
        }

        public void AgregarSubMenu(string pId, ToolStripMenuItem pMenu)
        {
            DataRow[] _DrFiltrado;
            var _DtCopia = new DataTable();

            _DtCopia = _Dt.Clone();
            _DrFiltrado = _Dt.Select("[HijoDe]='" + pId + "'");

            foreach (DataRow dr in _DrFiltrado)
            {
                _DtCopia.ImportRow(dr);
            }

            if (_DtCopia.Rows.Count > 0)
            {
                //Se crea cada sub item del menu
                for (int nSub = 0; nSub < _DtCopia.Rows.Count; nSub++)
                {
                    var _Descripcion = _DtCopia.Rows[nSub]["Descripcion"].ToString();
                    var _Etiqueta = Idioma.ObtenerEtiqueta(_Descripcion);

                    var _SubMenu = new ToolStripMenuItem(_Etiqueta, null, SubMenuClick, _Etiqueta);
                    _SubMenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    _SubMenu.Tag = _DtCopia.Rows[nSub]["NombreForm"].ToString();

                    //Si es el item del menu "Salir" queda activo
                    _SubMenu.Enabled = (_Descripcion == "MDI_Gabe_Mnu005");

                    if (!string.IsNullOrEmpty(_DtCopia.Rows[nSub]["PatenteId"].ToString()))
                    {
                        foreach (UsuarioPatente _Patente in _Usuario.Patentes)
                        {
                            if (_DtCopia.Rows[nSub]["PatenteId"].ToString() == _Patente.Patente.PatenteId.ToString())
                                _SubMenu.Enabled = true;
                        }
                    }

                    pMenu.DropDownItems.Add(_SubMenu);

                    if (!string.IsNullOrEmpty(_DtCopia.Rows[nSub]["HijoDe"].ToString()))
                    {
                        AgregarSubMenu(_DtCopia.Rows[nSub]["Id"].ToString(), _SubMenu);
                    }
                }
            }
        }

        public void SubMenuClick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(((ToolStripMenuItem)sender).Tag.ToString()))
                {
                    var nombreForm = "Gabe." + ((ToolStripMenuItem)sender).Tag.ToString();
                    
                    var assembly = Assembly.GetExecutingAssembly();

                    var form = new Form();
                    form = (Form)assembly.CreateInstance(nombreForm, true, BindingFlags.CreateInstance, null, new object[] { _Usuario.UsuarioId }, null, null);

                    if (form != null)
                    {
                        form.MdiParent = this;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MaximizeBox = false;

                        form.Show();
                    }
                    else
                        MessageBox.Show(Idioma.ObtenerEtiqueta("GEN001_Msg002"), "Gabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                throw;
            }

        }

        public void MenuClick(object sender, EventArgs e)
        {

            // Si la opción es Salir
            if (((ToolStripMenuItem) sender).Tag.ToString() == Idioma.ObtenerEtiqueta("MDI_Gabe_Mnu005"))
            {
                this.Close();

                MasterForm.CerrarInstacias();
            }

            // Si la opción es Idioma
            if (((ToolStripMenuItem)sender).Tag.ToString() == Idioma.ObtenerEtiqueta("MDI_Gabe_Mnu023"))
            {
                
            }
        }
    }
}
