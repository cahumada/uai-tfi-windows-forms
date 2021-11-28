
namespace Gabe
{
    partial class DVI001_Title
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DVI001_Grp01 = new System.Windows.Forms.GroupBox();
            this.DVI001_DgrDVI = new System.Windows.Forms.DataGridView();
            this.GEN001_Btn004 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.DVI001_Btn001 = new System.Windows.Forms.Button();
            this.DVI001_Grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVI001_DgrDVI)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DVI001_Grp01
            // 
            this.DVI001_Grp01.Controls.Add(this.DVI001_DgrDVI);
            this.DVI001_Grp01.Location = new System.Drawing.Point(12, 12);
            this.DVI001_Grp01.Name = "DVI001_Grp01";
            this.DVI001_Grp01.Size = new System.Drawing.Size(311, 295);
            this.DVI001_Grp01.TabIndex = 4;
            this.DVI001_Grp01.TabStop = false;
            this.DVI001_Grp01.Text = "Verificar Integridad";
            // 
            // DVI001_DgrDVI
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVI001_DgrDVI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DVI001_DgrDVI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DVI001_DgrDVI.DefaultCellStyle = dataGridViewCellStyle14;
            this.DVI001_DgrDVI.Location = new System.Drawing.Point(13, 19);
            this.DVI001_DgrDVI.Name = "DVI001_DgrDVI";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVI001_DgrDVI.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DVI001_DgrDVI.Size = new System.Drawing.Size(284, 258);
            this.DVI001_DgrDVI.TabIndex = 0;
            // 
            // GEN001_Btn004
            // 
            this.GEN001_Btn004.Location = new System.Drawing.Point(222, 13);
            this.GEN001_Btn004.Name = "GEN001_Btn004";
            this.GEN001_Btn004.Size = new System.Drawing.Size(75, 23);
            this.GEN001_Btn004.TabIndex = 1;
            this.GEN001_Btn004.Text = "Cerrar";
            this.GEN001_Btn004.UseVisualStyleBackColor = true;
            this.GEN001_Btn004.Click += new System.EventHandler(this.GEN001_Btn004_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.DVI001_Btn001);
            this.GroupBox1.Controls.Add(this.GEN001_Btn004);
            this.GroupBox1.Location = new System.Drawing.Point(12, 300);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(311, 54);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            // 
            // DVI001_Btn001
            // 
            this.DVI001_Btn001.Location = new System.Drawing.Point(141, 13);
            this.DVI001_Btn001.Name = "DVI001_Btn001";
            this.DVI001_Btn001.Size = new System.Drawing.Size(75, 23);
            this.DVI001_Btn001.TabIndex = 2;
            this.DVI001_Btn001.Text = "Recalcular";
            this.DVI001_Btn001.UseVisualStyleBackColor = true;
            this.DVI001_Btn001.Click += new System.EventHandler(this.DVI001_Btn001_Click);
            // 
            // DVI001_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 363);
            this.Controls.Add(this.DVI001_Grp01);
            this.Controls.Add(this.GroupBox1);
            this.Name = "DVI001_Title";
            this.Text = "DVI001_Title";
            this.Load += new System.EventHandler(this.DVI001_Title_Load);
            this.DVI001_Grp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DVI001_DgrDVI)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox DVI001_Grp01;
        internal System.Windows.Forms.DataGridView DVI001_DgrDVI;
        internal System.Windows.Forms.Button GEN001_Btn004;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button DVI001_Btn001;
    }
}