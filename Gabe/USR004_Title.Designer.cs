
namespace Gabe
{
    partial class USR004_Title
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.USR004_Grp01 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn008 = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.USR004_DgrFam = new System.Windows.Forms.DataGridView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn010 = new System.Windows.Forms.Button();
            this.GEN001_Btn009 = new System.Windows.Forms.Button();
            this.GEN001_Btn004 = new System.Windows.Forms.Button();
            this.USR004_CliCtrl = new Gabe.Controles.UsuarioControl();
            this.USR004_Grp01.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USR004_DgrFam)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // USR004_Grp01
            // 
            this.USR004_Grp01.Controls.Add(this.USR004_CliCtrl);
            this.USR004_Grp01.Controls.Add(this.GEN001_Btn008);
            this.USR004_Grp01.Location = new System.Drawing.Point(12, 12);
            this.USR004_Grp01.Name = "USR004_Grp01";
            this.USR004_Grp01.Size = new System.Drawing.Size(343, 57);
            this.USR004_Grp01.TabIndex = 3;
            this.USR004_Grp01.TabStop = false;
            this.USR004_Grp01.Text = "Usuario";
            // 
            // GEN001_Btn008
            // 
            this.GEN001_Btn008.Location = new System.Drawing.Point(255, 20);
            this.GEN001_Btn008.Name = "GEN001_Btn008";
            this.GEN001_Btn008.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn008.TabIndex = 1;
            this.GEN001_Btn008.Text = "Obtener";
            this.GEN001_Btn008.UseVisualStyleBackColor = true;
            this.GEN001_Btn008.Click += new System.EventHandler(this.GEN001_Btn008_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.USR004_DgrFam);
            this.GroupBox2.Location = new System.Drawing.Point(12, 62);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(343, 285);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            // 
            // USR004_DgrFam
            // 
            this.USR004_DgrFam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.USR004_DgrFam.Location = new System.Drawing.Point(12, 20);
            this.USR004_DgrFam.Name = "USR004_DgrFam";
            this.USR004_DgrFam.Size = new System.Drawing.Size(318, 253);
            this.USR004_DgrFam.TabIndex = 4;
            this.USR004_DgrFam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.USR004_DgrFam_CellContentClick);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GEN001_Btn010);
            this.GroupBox3.Controls.Add(this.GEN001_Btn009);
            this.GroupBox3.Controls.Add(this.GEN001_Btn004);
            this.GroupBox3.Location = new System.Drawing.Point(12, 340);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(343, 47);
            this.GroupBox3.TabIndex = 5;
            this.GroupBox3.TabStop = false;
            // 
            // GEN001_Btn010
            // 
            this.GEN001_Btn010.Location = new System.Drawing.Point(12, 14);
            this.GEN001_Btn010.Name = "GEN001_Btn010";
            this.GEN001_Btn010.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn010.TabIndex = 6;
            this.GEN001_Btn010.Text = "Guardar";
            this.GEN001_Btn010.UseVisualStyleBackColor = true;
            this.GEN001_Btn010.Click += new System.EventHandler(this.GEN001_Btn010_Click);
            // 
            // GEN001_Btn009
            // 
            this.GEN001_Btn009.Location = new System.Drawing.Point(93, 14);
            this.GEN001_Btn009.Name = "GEN001_Btn009";
            this.GEN001_Btn009.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn009.TabIndex = 5;
            this.GEN001_Btn009.Text = "Limpiar";
            this.GEN001_Btn009.UseVisualStyleBackColor = true;
            this.GEN001_Btn009.Click += new System.EventHandler(this.GEN001_Btn009_Click);
            // 
            // GEN001_Btn004
            // 
            this.GEN001_Btn004.Location = new System.Drawing.Point(255, 14);
            this.GEN001_Btn004.Name = "GEN001_Btn004";
            this.GEN001_Btn004.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn004.TabIndex = 2;
            this.GEN001_Btn004.Text = "Cerrar";
            this.GEN001_Btn004.UseVisualStyleBackColor = true;
            this.GEN001_Btn004.Click += new System.EventHandler(this.GEN001_Btn004_Click);
            // 
            // USR004_CliCtrl
            // 
            this.USR004_CliCtrl.CodigoUsuario = 1;
            this.USR004_CliCtrl.Estado = eFramework.EstadosABM.Consulta;
            this.USR004_CliCtrl.Location = new System.Drawing.Point(12, 20);
            this.USR004_CliCtrl.Name = "USR004_CliCtrl";
            this.USR004_CliCtrl.Size = new System.Drawing.Size(236, 26);
            this.USR004_CliCtrl.TabIndex = 2;
            // 
            // USR004_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 395);
            this.Controls.Add(this.USR004_Grp01);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox3);
            this.Name = "USR004_Title";
            this.Text = "USR004_Title";
            this.Load += new System.EventHandler(this.USR004_Title_Load);
            this.USR004_Grp01.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.USR004_DgrFam)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox USR004_Grp01;
        internal System.Windows.Forms.Button GEN001_Btn008;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DataGridView USR004_DgrFam;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button GEN001_Btn010;
        internal System.Windows.Forms.Button GEN001_Btn009;
        internal System.Windows.Forms.Button GEN001_Btn004;
        private Controles.UsuarioControl USR004_CliCtrl;
    }
}