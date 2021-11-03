using eSecurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabe
{
    public partial class USR001_Title : Form
    {
        int codigoUsuario;

        public USR001_Title(int pCodigoUsuario)
        {
            codigoUsuario = pCodigoUsuario;

            InitializeComponent();
        }

        private void USR001_Title_Load(object sender, EventArgs e)
        {
            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cUser", "Usuario");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cNik", "Alias");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cAttemptsBlock", "Intento de Bloqueo");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cIs_Blocked", "Bloqueado");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cCodLanguage", "CodLenguage");
            USR001_DgrUsr.Columns["USR001_DgrUsr_cCodLanguage"].Visible = false;

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cLanguage", "Lenguage");

            USR001_DgrUsr.Columns.Add("USR001_DgrUsr_cPassword", "Contraseña");
            USR001_DgrUsr.Columns["USR001_DgrUsr_cPassword"].Visible = false;

            USR001_DgrUsr.AutoGenerateColumns = false;
            USR001_DgrUsr.AllowUserToAddRows = false;
            USR001_DgrUsr.AllowUserToDeleteRows = false;
            USR001_DgrUsr.AllowUserToResizeRows = false;
            USR001_DgrUsr.AutoSize = true;
            USR001_DgrUsr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            USR001_DgrUsr.MultiSelect = false;
            USR001_DgrUsr.ReadOnly = true;
            USR001_DgrUsr.RowHeadersVisible = false;
            USR001_DgrUsr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GEN001_Btn002.Visible = false;

            //Seteo Idioma
            if (new Idioma().ObtenerIdiomaPorDefecto(codigoUsuario))
                MasterForm.AplicarIdioma(this);

            //Acualizo grilla
            ChargeDataSource();
        }

        private void ChargeDataSource()
        {
            USR001_DgrUsr.Rows.Clear();

            foreach (var usuario in new Usuarios().ObtenerUsuario())
            {
                USR001_DgrUsr.Rows.Add(usuario.UsuarioId, usuario.Nik, usuario.Intentos, usuario.Bloqueado, usuario.IdiomaId, (new Idioma(usuario.IdiomaId)).Descripcion, usuario.Contrasena);
            }
        }

        private void GEN001_Btn004_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEN001_Btn001_Click(object sender, EventArgs e)
        {
            //    'Nuevo
            //Dim mFrm As New USR002_Title(mUserCode, Nothing, eFramework.ConstantBasic.StatesABM.NewItem)

            //mFrm.StartPosition = FormStartPosition.CenterScreen
            //mFrm.MaximizeBox = False
            //'No permite expandir el formulario
            //mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //mFrm.ShowDialog(Me)

            //ChargeDataSource()

        }

        private void GEN001_Btn002_Click(object sender, EventArgs e)
        {
            //    'Modificar
            //If USR001_DgrUsr.SelectedRows.Count > 0 Then
            //    Dim mUser As New Users(CType(USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cUser").Value, Int32))

            //    Dim mFrm As New USR002_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.ModifyItem)

            //    mFrm.StartPosition = FormStartPosition.CenterScreen
            //    mFrm.MaximizeBox = False
            //    'No permite expandir el formulario
            //    mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //    mFrm.ShowDialog(Me)

            //    ChargeDataSource()
            //End If
        }

        private void GEN001_Btn003_Click(object sender, EventArgs e)
        {
            //    'Eliminar
            //If USR001_DgrUsr.SelectedRows.Count > 0 Then
            //    Dim mUser As New Users(CType(USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cUser").Value, Int32))

            //    Dim mFrm As New USR002_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.DeleteItem)

            //    mFrm.StartPosition = FormStartPosition.CenterScreen
            //    mFrm.MaximizeBox = False
            //    'No permite expandir el formulario
            //    mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //    mFrm.ShowDialog(Me)

            //    ChargeDataSource()
            //Else
            //    MsgBox(Language.ObtenerEtiqueta("USR001_Val001"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            //End If
        }

        private void USR001_Btn002_Click(object sender, EventArgs e)
        {
            //    'Desbloquear
            //If USR001_DgrUsr.SelectedRows.Count > 0 Then
            //    If USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cIs_Blocked").Value Then
            //        Dim mUser As New Users(CType(USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cUser").Value, Int32))

            //        Dim mFrm As New USR002_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.UnLock)

            //        mFrm.StartPosition = FormStartPosition.CenterScreen
            //        mFrm.MaximizeBox = False
            //        'No permite expandir el formulario
            //        mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //        mFrm.ShowDialog(Me)

            //        ChargeDataSource()
            //    Else
            //        MsgBox(Language.ObtenerEtiqueta("USR001_Val002"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            //    End If
            //Else
            //    MsgBox(Language.ObtenerEtiqueta("USR001_Val001"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            //End If
        }

        private void USR001_Btn003_Click(object sender, EventArgs e)
        {
            //    'Reset
            //If USR001_DgrUsr.SelectedRows.Count > 0 Then
            //    Dim mUser As New Users(CType(USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cUser").Value, Int32))

            //    Dim mFrm As New USR003_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.BlankPass)

            //    mFrm.StartPosition = FormStartPosition.CenterScreen
            //    mFrm.MaximizeBox = False
            //    'No permite expandir el formulario
            //    mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //    mFrm.ShowDialog(Me)

            //    ChargeDataSource()
            //Else
            //    MsgBox(Language.ObtenerEtiqueta("USR001_Val001"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            //End If
        }

        private void USR001_Btn001_Click(object sender, EventArgs e)
        {
            //    'Mod Idioma
            //If USR001_DgrUsr.SelectedRows.Count > 0 Then
            //    Dim mUser As New Users(CType(USR001_DgrUsr.SelectedRows(0).Cells("USR001_DgrUsr_cUser").Value, Int32))

            //    Dim mFrm As New USR002_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.ChangeLanguage)

            //    mFrm.StartPosition = FormStartPosition.CenterScreen
            //    mFrm.MaximizeBox = False
            //    'No permite expandir el formulario
            //    mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //    mFrm.ShowDialog(Me)

            //    ChargeDataSource()
            //Else
            //    MsgBox(Language.ObtenerEtiqueta("USR001_Val001"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            //End If
        }

        private void USR001_DgrUsr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //    Dim mUser As New Users(CType(USR001_DgrUsr.Item("USR001_DgrUsr_cUser", e.RowIndex).Value, Int32))

            //Dim mFrm As New USR002_Title(mUserCode, mUser, eFramework.ConstantBasic.StatesABM.QueryItem)

            //mFrm.StartPosition = FormStartPosition.CenterScreen
            //mFrm.MaximizeBox = False
            //'No permite expandir el formulario
            //mFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            //mFrm.ShowDialog(Me)
        }
    }
}
