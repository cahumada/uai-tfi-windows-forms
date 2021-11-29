
namespace Gabe
{
    partial class RST001_Title
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
            this.RST001_Grp01 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn012 = new System.Windows.Forms.Button();
            this.RST001_txtPath = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RST001_LblText = new System.Windows.Forms.Label();
            this.RST001_NumFiles = new System.Windows.Forms.NumericUpDown();
            this.RST001_LblFiles = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GEN001_Btn007 = new System.Windows.Forms.Button();
            this.GEN001_Btn006 = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.RST001_Grp01.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RST001_NumFiles)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // RST001_Grp01
            // 
            this.RST001_Grp01.Controls.Add(this.GEN001_Btn012);
            this.RST001_Grp01.Controls.Add(this.RST001_txtPath);
            this.RST001_Grp01.Location = new System.Drawing.Point(12, 12);
            this.RST001_Grp01.Name = "RST001_Grp01";
            this.RST001_Grp01.Size = new System.Drawing.Size(486, 66);
            this.RST001_Grp01.TabIndex = 6;
            this.RST001_Grp01.TabStop = false;
            this.RST001_Grp01.Text = "Ubicacion";
            // 
            // GEN001_Btn012
            // 
            this.GEN001_Btn012.Location = new System.Drawing.Point(15, 29);
            this.GEN001_Btn012.Name = "GEN001_Btn012";
            this.GEN001_Btn012.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn012.TabIndex = 1;
            this.GEN001_Btn012.Text = "Seleccionar";
            this.GEN001_Btn012.UseVisualStyleBackColor = true;
            this.GEN001_Btn012.Click += new System.EventHandler(this.GEN001_Btn012_Click);
            // 
            // RST001_txtPath
            // 
            this.RST001_txtPath.Location = new System.Drawing.Point(111, 31);
            this.RST001_txtPath.Name = "RST001_txtPath";
            this.RST001_txtPath.Size = new System.Drawing.Size(353, 20);
            this.RST001_txtPath.TabIndex = 0;
            this.RST001_txtPath.Validating += new System.ComponentModel.CancelEventHandler(this.RST001_txtPath_Validating);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.RST001_LblText);
            this.GroupBox1.Controls.Add(this.RST001_NumFiles);
            this.GroupBox1.Controls.Add(this.RST001_LblFiles);
            this.GroupBox1.Location = new System.Drawing.Point(12, 67);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(486, 90);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            // 
            // RST001_LblText
            // 
            this.RST001_LblText.ForeColor = System.Drawing.Color.Red;
            this.RST001_LblText.Location = new System.Drawing.Point(174, 27);
            this.RST001_LblText.Name = "RST001_LblText";
            this.RST001_LblText.Size = new System.Drawing.Size(290, 53);
            this.RST001_LblText.TabIndex = 2;
            this.RST001_LblText.Text = "En caso de requerir un respaldo multivolumen debe seleccionar la cantidad de arch" +
    "ivos a crear";
            // 
            // RST001_NumFiles
            // 
            this.RST001_NumFiles.Location = new System.Drawing.Point(111, 25);
            this.RST001_NumFiles.Name = "RST001_NumFiles";
            this.RST001_NumFiles.Size = new System.Drawing.Size(43, 20);
            this.RST001_NumFiles.TabIndex = 1;
            // 
            // RST001_LblFiles
            // 
            this.RST001_LblFiles.AutoSize = true;
            this.RST001_LblFiles.Location = new System.Drawing.Point(12, 27);
            this.RST001_LblFiles.Name = "RST001_LblFiles";
            this.RST001_LblFiles.Size = new System.Drawing.Size(96, 13);
            this.RST001_LblFiles.TabIndex = 0;
            this.RST001_LblFiles.Text = "Cantidad Archivos:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.GEN001_Btn007);
            this.GroupBox2.Controls.Add(this.GEN001_Btn006);
            this.GroupBox2.Location = new System.Drawing.Point(12, 150);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(486, 43);
            this.GroupBox2.TabIndex = 8;
            this.GroupBox2.TabStop = false;
            // 
            // GEN001_Btn007
            // 
            this.GEN001_Btn007.Location = new System.Drawing.Point(396, 13);
            this.GEN001_Btn007.Name = "GEN001_Btn007";
            this.GEN001_Btn007.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn007.TabIndex = 5;
            this.GEN001_Btn007.Text = "Cancelar";
            this.GEN001_Btn007.UseVisualStyleBackColor = true;
            this.GEN001_Btn007.Click += new System.EventHandler(this.GEN001_Btn007_Click);
            // 
            // GEN001_Btn006
            // 
            this.GEN001_Btn006.Location = new System.Drawing.Point(304, 13);
            this.GEN001_Btn006.Name = "GEN001_Btn006";
            this.GEN001_Btn006.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn006.TabIndex = 4;
            this.GEN001_Btn006.Text = "Aceptar";
            this.GEN001_Btn006.UseVisualStyleBackColor = true;
            this.GEN001_Btn006.Click += new System.EventHandler(this.GEN001_Btn006_Click);
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // RST001_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 201);
            this.Controls.Add(this.RST001_Grp01);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "RST001_Title";
            this.Text = "RST001_Title";
            this.Load += new System.EventHandler(this.RST001_Title_Load);
            this.RST001_Grp01.ResumeLayout(false);
            this.RST001_Grp01.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RST001_NumFiles)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox RST001_Grp01;
        internal System.Windows.Forms.Button GEN001_Btn012;
        internal System.Windows.Forms.TextBox RST001_txtPath;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label RST001_LblText;
        internal System.Windows.Forms.NumericUpDown RST001_NumFiles;
        internal System.Windows.Forms.Label RST001_LblFiles;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button GEN001_Btn007;
        internal System.Windows.Forms.Button GEN001_Btn006;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.ErrorProvider ErrProv;
    }
}