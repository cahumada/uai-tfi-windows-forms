using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSecurity;
using eSecurity_DTO;

namespace Gabe
{
    public partial class FAMPAT001_Title : Form
    {
        private Familia familia = new Familia();
        private Patente patente = new Patente();
        private int codigoUsuario;

        public FAMPAT001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;
            InitializeComponent();
        }

        private void FAMPAT001_Title_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Test001_Btn001_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = familia.ObtenerFamilia();

            Test001_Btn006.Enabled = true;
        }

        private void Test001_Btn005_Click(object sender, EventArgs e)
        {
           
        }

        private void Test001_Btn002_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0 && DataGridView3.SelectedRows.Count > 0)
            {
                familia.ObtenerFamilia(System.Convert.ToInt32(DataGridView1.SelectedRows[0].Cells[0].Value));

                familia.AgregarPatente(new Patente(System.Convert.ToInt32(DataGridView3.SelectedRows[0].Cells[0].Value)));


                DataGridView2.DataSource = familia.Patentes;

                MessageBox.Show("Se agregó la patante a la familia seleccionada", "Gabe", MessageBoxButtons.OK);
            }
        }

        private void Test001_Btn003_Click(object sender, EventArgs e)
        {
            if (DataGridView2.SelectedRows.Count > 0)
            {
                var indice = System.Convert.ToInt32(DataGridView2.SelectedRows[0].Cells[2].Value);

                familia.QuitarPatente(familia.ObtenerFamiliaPatenteIndice(indice));

                DataGridView2.DataSource = familia.Patentes;

                MessageBox.Show("Se quitó la patante a la familia seleccionada", "Gabe", MessageBoxButtons.OK);
            }
        }

        private void Test001_Btn004_Click(object sender, EventArgs e)
        {
            try
            {
                familia.PersistirFamiliaPatentes();
                
                MessageBox.Show("Los datos se guardaron con éxito", "Gabe", MessageBoxButtons.OK);
                
                Iniciar();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hubo un error, no se pudieron actualizar los datos", "Gabe", MessageBoxButtons.OK);
            }
           
        }

        private void Test001_Btn006_Click(object sender, EventArgs e)
        {
            DataGridView3.DataSource = patente.ObtenerPatente();

            Test001_Btn002.Enabled = true;
            Test001_Btn003.Enabled = true;
            Test001_Btn004.Enabled = true;
        }

        private void CargarFamiliaPatentes()
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                familia = new Familia((int)DataGridView1.SelectedRows[0].Cells[0].Value);

                DataGridView2.DataSource = familia.Patentes;
            }
        }

        private void Iniciar()
        {
            // Familias
            DataGridView1.Columns.Clear();
            DataGridView1.Columns.Add("Test001_DataGridView1_cFamily", "Familia");
            DataGridView1.Columns["Test001_DataGridView1_cFamily"].DataPropertyName = "FamiliaId";

            DataGridView1.Columns.Add("cDescript", "Descripción");
            DataGridView1.Columns["cDescript"].DataPropertyName = "Descripcion";

            DataGridView1.Columns.Add("cShort_Desc", "Desc. Corta");
            DataGridView1.Columns["cShort_Desc"].DataPropertyName = "Desc_Corta";
            DataGridView1.Columns["cShort_Desc"].Visible = false;

            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView1.ReadOnly = true;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            // Patentes
            DataGridView2.Columns.Clear();
            DataGridView2.Columns.Add("cPatent", "Patente");
            DataGridView2.Columns["cPatent"].DataPropertyName = "PatenteId";

            DataGridView2.Columns.Add("cDescript", "Descripción");
            DataGridView2.Columns["cDescript"].DataPropertyName = "Descripcion";

            DataGridView2.Columns.Add("cIndexCollection", "IndexCollection");
            DataGridView2.Columns["cIndexCollection"].DataPropertyName = "IndiceLista";
            DataGridView2.Columns["cIndexCollection"].Visible = false;

            DataGridView2.AutoGenerateColumns = false;
            DataGridView2.RowHeadersVisible = false;
            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView2.ReadOnly = true;
            DataGridView2.AllowUserToResizeRows = false;
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            // Familia Patente
            DataGridView3.Columns.Clear();
            DataGridView3.Columns.Add("cPatent", "Patente");
            DataGridView3.Columns["cPatent"].DataPropertyName = "PatenteId";

            DataGridView3.Columns.Add("cDescript", "Descripción");
            DataGridView3.Columns["cDescript"].DataPropertyName = "Descripcion";

            DataGridView3.AutoGenerateColumns = false;
            DataGridView3.RowHeadersVisible = false;
            DataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView3.ReadOnly = true;
            DataGridView3.AllowUserToResizeRows = false;
            DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
            {
                MasterForm.AplicarIdioma(this);
            }
            
            Test001_Btn002.Enabled = false;
            Test001_Btn003.Enabled = false;
            Test001_Btn004.Enabled = false;
            Test001_Btn001.Enabled = true;

            CargarFamiliaPatentes();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarFamiliaPatentes();
        }
    }
}
