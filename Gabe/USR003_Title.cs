using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSecurity;

namespace Gabe
{
    public partial class USR003_Title : Form
    {
        private int codigoUsuario;
        private Usuarios usuario;


        public USR003_Title(int pCodigoUsuario, Usuarios pUsuario = null)
        {
            codigoUsuario = pCodigoUsuario;

            if (pUsuario != null)
                usuario = pUsuario;

            //estado = '';
            
            InitializeComponent();
        }

        private void CargarControles()
        {
            //switch (WindowState)
            //{
                
            //}
        }

        private void CambiarUsuario(bool pGuardar = false)
        {
            if (pGuardar)
            {
                if (usuario == null)
                    usuario = new Usuarios();

                usuario.Nik = USR003_txtNik.Text;
            }
            else
            {
                if (usuario.UsuarioId > 0)
                    USR003_txtNik.Text = usuario.Nik;
            }
        }
    }
}
