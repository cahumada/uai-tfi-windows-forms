
namespace Gabe
{
    partial class USR002_Title
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
            this.components = new System.ComponentModel.Container();
            this.USR002_Grp01 = new System.Windows.Forms.GroupBox();
            this.USR002_CmbLanguage = new System.Windows.Forms.ComboBox();
            this.USR002_ChkBloqued = new System.Windows.Forms.CheckBox();
            this.USR002_NumAttemp = new System.Windows.Forms.NumericUpDown();
            this.USR002_txtNik = new System.Windows.Forms.TextBox();
            this.USR002_Lbl004 = new System.Windows.Forms.Label();
            this.USR002_Lbl003 = new System.Windows.Forms.Label();
            this.USR002_lbl001 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn007 = new System.Windows.Forms.Button();
            this.GEN001_Btn006 = new System.Windows.Forms.Button();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.USR002_Grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USR002_NumAttemp)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // USR002_Grp01
            // 
            this.USR002_Grp01.Controls.Add(this.USR002_CmbLanguage);
            this.USR002_Grp01.Controls.Add(this.USR002_ChkBloqued);
            this.USR002_Grp01.Controls.Add(this.USR002_NumAttemp);
            this.USR002_Grp01.Controls.Add(this.USR002_txtNik);
            this.USR002_Grp01.Controls.Add(this.USR002_Lbl004);
            this.USR002_Grp01.Controls.Add(this.USR002_Lbl003);
            this.USR002_Grp01.Controls.Add(this.USR002_lbl001);
            this.USR002_Grp01.Location = new System.Drawing.Point(12, 12);
            this.USR002_Grp01.Name = "USR002_Grp01";
            this.USR002_Grp01.Size = new System.Drawing.Size(399, 145);
            this.USR002_Grp01.TabIndex = 3;
            this.USR002_Grp01.TabStop = false;
            this.USR002_Grp01.Text = "Usuario";
            // 
            // USR002_CmbLanguage
            // 
            this.USR002_CmbLanguage.FormattingEnabled = true;
            this.USR002_CmbLanguage.Location = new System.Drawing.Point(134, 96);
            this.USR002_CmbLanguage.Name = "USR002_CmbLanguage";
            this.USR002_CmbLanguage.Size = new System.Drawing.Size(158, 21);
            this.USR002_CmbLanguage.TabIndex = 9;
            // 
            // USR002_ChkBloqued
            // 
            this.USR002_ChkBloqued.AutoSize = true;
            this.USR002_ChkBloqued.Location = new System.Drawing.Point(215, 63);
            this.USR002_ChkBloqued.Name = "USR002_ChkBloqued";
            this.USR002_ChkBloqued.Size = new System.Drawing.Size(77, 17);
            this.USR002_ChkBloqued.TabIndex = 8;
            this.USR002_ChkBloqued.Text = "Bloqueado";
            this.USR002_ChkBloqued.UseVisualStyleBackColor = true;
            // 
            // USR002_NumAttemp
            // 
            this.USR002_NumAttemp.Location = new System.Drawing.Point(134, 60);
            this.USR002_NumAttemp.Name = "USR002_NumAttemp";
            this.USR002_NumAttemp.Size = new System.Drawing.Size(38, 20);
            this.USR002_NumAttemp.TabIndex = 7;
            // 
            // USR002_txtNik
            // 
            this.USR002_txtNik.Location = new System.Drawing.Point(134, 26);
            this.USR002_txtNik.Name = "USR002_txtNik";
            this.USR002_txtNik.Size = new System.Drawing.Size(100, 20);
            this.USR002_txtNik.TabIndex = 5;
            this.USR002_txtNik.Validating += new System.ComponentModel.CancelEventHandler(this.USR002_txtNik_Validating);
            // 
            // USR002_Lbl004
            // 
            this.USR002_Lbl004.AutoSize = true;
            this.USR002_Lbl004.Location = new System.Drawing.Point(20, 99);
            this.USR002_Lbl004.Name = "USR002_Lbl004";
            this.USR002_Lbl004.Size = new System.Drawing.Size(54, 13);
            this.USR002_Lbl004.TabIndex = 2;
            this.USR002_Lbl004.Text = "Lenguaje:";
            // 
            // USR002_Lbl003
            // 
            this.USR002_Lbl003.AutoSize = true;
            this.USR002_Lbl003.Location = new System.Drawing.Point(20, 62);
            this.USR002_Lbl003.Name = "USR002_Lbl003";
            this.USR002_Lbl003.Size = new System.Drawing.Size(105, 13);
            this.USR002_Lbl003.TabIndex = 1;
            this.USR002_Lbl003.Text = "Intentos de Bloqueo:";
            // 
            // USR002_lbl001
            // 
            this.USR002_lbl001.AutoSize = true;
            this.USR002_lbl001.Location = new System.Drawing.Point(20, 29);
            this.USR002_lbl001.Name = "USR002_lbl001";
            this.USR002_lbl001.Size = new System.Drawing.Size(32, 13);
            this.USR002_lbl001.TabIndex = 0;
            this.USR002_lbl001.Text = "Alias:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GEN001_Btn007);
            this.GroupBox1.Controls.Add(this.GEN001_Btn006);
            this.GroupBox1.Location = new System.Drawing.Point(12, 163);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(399, 59);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            // 
            // GEN001_Btn007
            // 
            this.GEN001_Btn007.Location = new System.Drawing.Point(312, 20);
            this.GEN001_Btn007.Name = "GEN001_Btn007";
            this.GEN001_Btn007.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn007.TabIndex = 1;
            this.GEN001_Btn007.Text = "Cancelar";
            this.GEN001_Btn007.UseVisualStyleBackColor = true;
            this.GEN001_Btn007.Click += new System.EventHandler(this.GEN001_Btn007_Click);
            // 
            // GEN001_Btn006
            // 
            this.GEN001_Btn006.Location = new System.Drawing.Point(221, 20);
            this.GEN001_Btn006.Name = "GEN001_Btn006";
            this.GEN001_Btn006.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn006.TabIndex = 0;
            this.GEN001_Btn006.Text = "Aceptar";
            this.GEN001_Btn006.UseVisualStyleBackColor = true;
            this.GEN001_Btn006.Click += new System.EventHandler(this.GEN001_Btn006_Click);
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // USR002_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 230);
            this.Controls.Add(this.USR002_Grp01);
            this.Controls.Add(this.GroupBox1);
            this.Name = "USR002_Title";
            this.Text = "USR002_Title";
            this.Load += new System.EventHandler(this.USR002_Title_Load);
            this.USR002_Grp01.ResumeLayout(false);
            this.USR002_Grp01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.USR002_NumAttemp)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox USR002_Grp01;
        internal System.Windows.Forms.ComboBox USR002_CmbLanguage;
        internal System.Windows.Forms.CheckBox USR002_ChkBloqued;
        internal System.Windows.Forms.NumericUpDown USR002_NumAttemp;
        internal System.Windows.Forms.TextBox USR002_txtNik;
        internal System.Windows.Forms.Label USR002_Lbl004;
        internal System.Windows.Forms.Label USR002_Lbl003;
        internal System.Windows.Forms.Label USR002_lbl001;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button GEN001_Btn007;
        internal System.Windows.Forms.Button GEN001_Btn006;
        private System.Windows.Forms.ErrorProvider ErrProv;
    }
}