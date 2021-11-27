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
    public partial class USRL001_Title : Form
    {
        int codigoUsuario;
        Usuarios usuario;

        public Usuarios Usuario
        {
            get { return usuario; }
        }

        public USRL001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void USRL001_Title_Load(object sender, EventArgs e)
        {
            USRL001_DgrUsr.Columns.Add("USR001_DgrUsr_cUser", "Usuario");
            USRL001_DgrUsr.Columns.Add("USR001_DgrUsr_cNik", "Alias");

            USRL001_DgrUsr.AutoGenerateColumns = false;
            USRL001_DgrUsr.AllowUserToAddRows = false;
            USRL001_DgrUsr.AllowUserToDeleteRows = false;
            USRL001_DgrUsr.AllowUserToResizeRows = false;
            USRL001_DgrUsr.AutoSize = true;
            USRL001_DgrUsr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            USRL001_DgrUsr.MultiSelect = false;
            USRL001_DgrUsr.ReadOnly = true;
            USRL001_DgrUsr.RowHeadersVisible = false;
            USRL001_DgrUsr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }

            // Acualizo grilla
            ActualizarOrigen();
        }

        private void ActualizarOrigen()
        {
            USRL001_DgrUsr.Rows.Clear();

            foreach (var usu in (new Usuarios().ObtenerUsuario()))
            {
                USRL001_DgrUsr.Rows.Add(usu.UsuarioId, usu.Nik);
            }
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn006_Click(object sender, EventArgs e)
        {
            if (USRL001_DgrUsr.SelectedRows.Count > 0)
            {
                usuario = new Usuarios((int)USRL001_DgrUsr.SelectedRows[0].Cells[0].Value);

                this.Close();
            }
        }

        private void USRL001_DgrUsr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            usuario = new Usuarios((int)USRL001_DgrUsr.SelectedRows[0].Cells[0].Value);

            this.Close();
        }
    }
}
