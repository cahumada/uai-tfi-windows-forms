using eSecurity;
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

namespace Gabe
{
    public partial class USR002_Title : Form
    {
        int codigoUsuario;
        Usuarios usuario = new Usuarios();
        EstadosABM estado;
        private string contrasenaNueva = ConfigurationManager.AppSettings["NuevaContraseña"];

        public USR002_Title(int pCodigoUsuario, Usuarios pUsuario = null, EstadosABM pEstado = EstadosABM.Nuevo)
        {
            codigoUsuario = pCodigoUsuario;

            // Usuario en tratamiento
            if (pUsuario != null)
                usuario = pUsuario;


            // Requerimiento solicitado
            estado = pEstado;

            InitializeComponent();
        }

        private void GEN001_Btn007_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarControles()
        {
            switch (estado)
            {
                case EstadosABM.Modificar:
                    USR002_Grp01.Name = "USR002_Grp02";
                    CargarUsuario();

                    break;

                case EstadosABM.Nuevo:
                    USR002_Grp01.Name = "USR002_Grp01";
                    CargarUsuario();

                    break;

                case EstadosABM.Eliminar:
                    USR002_Grp01.Name = "USR002_Grp03";
                    CargarUsuario();

                    // Desactivo controles del grupo
                    MasterForm.HabilitarControles(USR002_Grp01);
                    break;

                case EstadosABM.Consulta:
                    USR002_Grp01.Name = "USR002_Grp04";
                    CargarUsuario();

                    // Desactivo controles del grupo
                    MasterForm.HabilitarControles(USR002_Grp01);

                    // Inhabilito botón Aceptar
                    MasterForm.HabilitarControles(GEN001_Btn006, true, false);
                    break;

                case EstadosABM.CambiarIdioma:
                    USR002_Grp01.Name = "USR002_Grp05";
                    CargarUsuario();

                    break;

                case EstadosABM.Desbloquear:
                    USR002_Grp01.Name = "USR002_Grp06";
                    CargarUsuario();

                    break;
            }
        }

        private void ValidarAlias()
        {
            ErrProv.SetError(USR002_txtNik, "");

            if (string.IsNullOrEmpty(USR002_txtNik.Text))
            {
                ErrProv.BlinkRate = 200;
                ErrProv.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ErrProv.SetError(USR002_txtNik, Idioma.ObtenerEtiqueta("USR002_Val004"));
            }
        }

        private void CargarUsuario(bool pGuardar = false)
        {
            if (pGuardar)
            {
                if (usuario == null)
                {
                    usuario = new Usuarios();
                }

                usuario.Nik = USR002_txtNik.Text.ToUpper();
                usuario.Bloqueado = USR002_ChkBloqued.Checked;
                usuario.IdiomaId = (int)USR002_CmbLanguage.SelectedValue;
            }
            else
            {
                if (usuario.UsuarioId > 0)
                {
                    USR002_txtNik.Text = usuario.Nik.ToUpper();
                    USR002_NumAttemp.Value = usuario.Intentos;
                    USR002_ChkBloqued.Checked = usuario.Bloqueado;
                    USR002_CmbLanguage.SelectedValue = usuario.IdiomaId;
                }
            }
        }

        private void USR002_Title_Load(object sender, EventArgs e)
        {
            // Cargo combo Idioma
            USR002_CmbLanguage.DataSource = (new eSecurity.Idioma()).ObtenerIdiomas();
            USR002_CmbLanguage.DisplayMember = "Descripcion";
            USR002_CmbLanguage.ValueMember = "IdiomaId";

            CargarControles();

            USR002_NumAttemp.Enabled = false;
            USR002_ChkBloqued.Enabled = false;

            if (estado == EstadosABM.CambiarIdioma)
            {
                USR002_txtNik.Enabled = false;
                USR002_Lbl003.Visible = false;
                USR002_NumAttemp.Visible = false;
                USR002_ChkBloqued.Visible = false;
            }

            if (estado == EstadosABM.Desbloquear)
            {
                USR002_txtNik.Enabled = false;
                USR002_ChkBloqued.Enabled = false;
                USR002_Lbl004.Visible = false;
                USR002_CmbLanguage.Visible = false;
            }

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }
        }

        private void USR002_txtNik_Validating(object sender, CancelEventArgs e)
        {
            ValidarAlias();
        }

        private void GEN001_Btn006_Click(object sender, EventArgs e)
        {
            ValidarAlias();

            if (!MasterForm.ControlErrores(this, ErrProv))
            {
                switch (estado)
                {
                    case EstadosABM.Nuevo:
                        usuario.Contrasena = Encrypt.GetHashMD5(contrasenaNueva);

                        CargarUsuario(true);
                        usuario.Guardar();
                        break;

                    case EstadosABM.Modificar:
                        CargarUsuario(true);
                        usuario.Guardar();
                        break;

                    case EstadosABM.Eliminar:
                        if (usuario.UsuarioId > 0)
                        {
                            if (MessageBox.Show(Idioma.ObtenerEtiqueta("USR002_Val004"), "Gabe",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                usuario.Eliminar();
                            }
                        }
                        break;

                    case EstadosABM.CambiarIdioma:
                        if (usuario.UsuarioId > 0)
                        {
                            usuario.ActualizarIdioma(Convert.ToInt16(USR002_CmbLanguage.SelectedValue));
                        }
                        break;

                    case EstadosABM.Desbloquear:
                        if (usuario.UsuarioId > 0)
                        {
                            usuario.Desbloquear();
                        }
                        break;
                }

                this.Close();
            }
        }
    }
}
