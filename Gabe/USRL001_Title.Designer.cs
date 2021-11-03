
namespace Gabe
{
    partial class USRL001_Title
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
            this.USRL001_Grp01 = new System.Windows.Forms.GroupBox();
            this.USRL001_DgrUsr = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn006 = new System.Windows.Forms.Button();
            this.GEN001_Btn004 = new System.Windows.Forms.Button();
            this.USRL001_Grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USRL001_DgrUsr)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // USRL001_Grp01
            // 
            this.USRL001_Grp01.Controls.Add(this.USRL001_DgrUsr);
            this.USRL001_Grp01.Location = new System.Drawing.Point(12, 12);
            this.USRL001_Grp01.Name = "USRL001_Grp01";
            this.USRL001_Grp01.Size = new System.Drawing.Size(271, 252);
            this.USRL001_Grp01.TabIndex = 2;
            this.USRL001_Grp01.TabStop = false;
            this.USRL001_Grp01.Text = "Usuarios";
            // 
            // USRL001_DgrUsr
            // 
            this.USRL001_DgrUsr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.USRL001_DgrUsr.Location = new System.Drawing.Point(13, 19);
            this.USRL001_DgrUsr.Name = "USRL001_DgrUsr";
            this.USRL001_DgrUsr.Size = new System.Drawing.Size(246, 220);
            this.USRL001_DgrUsr.TabIndex = 0;
            this.USRL001_DgrUsr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.USRL001_DgrUsr_CellDoubleClick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.GEN001_Btn006);
            this.GroupBox2.Controls.Add(this.GEN001_Btn004);
            this.GroupBox2.Location = new System.Drawing.Point(12, 257);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(271, 50);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            // 
            // GEN001_Btn006
            // 
            this.GEN001_Btn006.Location = new System.Drawing.Point(103, 13);
            this.GEN001_Btn006.Name = "GEN001_Btn006";
            this.GEN001_Btn006.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn006.TabIndex = 0;
            this.GEN001_Btn006.Text = "Aceptar";
            this.GEN001_Btn006.UseVisualStyleBackColor = true;
            this.GEN001_Btn006.Click += new System.EventHandler(this.GEN001_Btn006_Click);
            // 
            // GEN001_Btn004
            // 
            this.GEN001_Btn004.Location = new System.Drawing.Point(184, 13);
            this.GEN001_Btn004.Name = "GEN001_Btn004";
            this.GEN001_Btn004.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn004.TabIndex = 1;
            this.GEN001_Btn004.Text = "Cerrar";
            this.GEN001_Btn004.UseVisualStyleBackColor = true;
            this.GEN001_Btn004.Click += new System.EventHandler(this.GEN001_Btn004_Click);
            // 
            // USRL001_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 315);
            this.Controls.Add(this.USRL001_Grp01);
            this.Controls.Add(this.GroupBox2);
            this.Name = "USRL001_Title";
            this.Text = "USRL001_Title";
            this.Load += new System.EventHandler(this.USRL001_Title_Load);
            this.USRL001_Grp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.USRL001_DgrUsr)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox USRL001_Grp01;
        internal System.Windows.Forms.DataGridView USRL001_DgrUsr;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button GEN001_Btn006;
        internal System.Windows.Forms.Button GEN001_Btn004;
    }
}