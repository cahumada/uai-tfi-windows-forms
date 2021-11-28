
namespace Gabe
{
    partial class USR005_Title
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
            this.GEN001_Btn010 = new System.Windows.Forms.Button();
            this.USR005_Grp01 = new System.Windows.Forms.GroupBox();
            this.USR005_CliCtrl = new Gabe.Controles.UsuarioControl();
            this.GEN001_Btn008 = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.USR005_DgrPat = new System.Windows.Forms.DataGridView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn009 = new System.Windows.Forms.Button();
            this.GEN001_Btn004 = new System.Windows.Forms.Button();
            this.USR005_Grp01.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USR005_DgrPat)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GEN001_Btn010
            // 
            this.GEN001_Btn010.Location = new System.Drawing.Point(12, 15);
            this.GEN001_Btn010.Name = "GEN001_Btn010";
            this.GEN001_Btn010.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn010.TabIndex = 6;
            this.GEN001_Btn010.Text = "Guardar";
            this.GEN001_Btn010.UseVisualStyleBackColor = true;
            this.GEN001_Btn010.Click += new System.EventHandler(this.GEN001_Btn010_Click);
            // 
            // USR005_Grp01
            // 
            this.USR005_Grp01.Controls.Add(this.USR005_CliCtrl);
            this.USR005_Grp01.Controls.Add(this.GEN001_Btn008);
            this.USR005_Grp01.Location = new System.Drawing.Point(12, 12);
            this.USR005_Grp01.Name = "USR005_Grp01";
            this.USR005_Grp01.Size = new System.Drawing.Size(516, 57);
            this.USR005_Grp01.TabIndex = 6;
            this.USR005_Grp01.TabStop = false;
            this.USR005_Grp01.Text = "Usuario";
            // 
            // USR005_CliCtrl
            // 
            this.USR005_CliCtrl.Estado = eFramework.EstadosABM.Consulta;
            this.USR005_CliCtrl.Location = new System.Drawing.Point(13, 19);
            this.USR005_CliCtrl.Name = "USR005_CliCtrl";
            this.USR005_CliCtrl.Size = new System.Drawing.Size(236, 26);
            this.USR005_CliCtrl.TabIndex = 2;
            // 
            // GEN001_Btn008
            // 
            this.GEN001_Btn008.Location = new System.Drawing.Point(425, 19);
            this.GEN001_Btn008.Name = "GEN001_Btn008";
            this.GEN001_Btn008.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn008.TabIndex = 1;
            this.GEN001_Btn008.Text = "Obtener";
            this.GEN001_Btn008.UseVisualStyleBackColor = true;
            this.GEN001_Btn008.Click += new System.EventHandler(this.GEN001_Btn008_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.USR005_DgrPat);
            this.GroupBox2.Location = new System.Drawing.Point(12, 62);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(516, 321);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            // 
            // USR005_DgrPat
            // 
            this.USR005_DgrPat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.USR005_DgrPat.Location = new System.Drawing.Point(13, 16);
            this.USR005_DgrPat.Name = "USR005_DgrPat";
            this.USR005_DgrPat.Size = new System.Drawing.Size(487, 272);
            this.USR005_DgrPat.TabIndex = 5;
            this.USR005_DgrPat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.USR005_DgrPat_CellContentClick);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GEN001_Btn010);
            this.GroupBox3.Controls.Add(this.GEN001_Btn009);
            this.GroupBox3.Controls.Add(this.GEN001_Btn004);
            this.GroupBox3.Location = new System.Drawing.Point(12, 376);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(516, 47);
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            // 
            // GEN001_Btn009
            // 
            this.GEN001_Btn009.Location = new System.Drawing.Point(93, 15);
            this.GEN001_Btn009.Name = "GEN001_Btn009";
            this.GEN001_Btn009.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn009.TabIndex = 5;
            this.GEN001_Btn009.Text = "Limpiar";
            this.GEN001_Btn009.UseVisualStyleBackColor = true;
            this.GEN001_Btn009.Click += new System.EventHandler(this.GEN001_Btn009_Click);
            // 
            // GEN001_Btn004
            // 
            this.GEN001_Btn004.Location = new System.Drawing.Point(425, 13);
            this.GEN001_Btn004.Name = "GEN001_Btn004";
            this.GEN001_Btn004.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn004.TabIndex = 2;
            this.GEN001_Btn004.Text = "Cerrar";
            this.GEN001_Btn004.UseVisualStyleBackColor = true;
            this.GEN001_Btn004.Click += new System.EventHandler(this.GEN001_Btn004_Click);
            // 
            // USR005_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 434);
            this.Controls.Add(this.USR005_Grp01);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox3);
            this.Name = "USR005_Title";
            this.Text = "USR005_Title";
            this.Load += new System.EventHandler(this.USR005_Title_Load);
            this.USR005_Grp01.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.USR005_DgrPat)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button GEN001_Btn010;
        internal System.Windows.Forms.GroupBox USR005_Grp01;
        internal System.Windows.Forms.Button GEN001_Btn008;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DataGridView USR005_DgrPat;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button GEN001_Btn009;
        internal System.Windows.Forms.Button GEN001_Btn004;
        private Controles.UsuarioControl USR005_CliCtrl;
    }
}