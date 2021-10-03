namespace Gabe
{
    partial class Gabe_Splash
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
            this.Splash_LblStatus = new System.Windows.Forms.Label();
            this.Splash_BtnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Splash_LblStatus
            // 
            this.Splash_LblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Splash_LblStatus.BackColor = System.Drawing.Color.Transparent;
            this.Splash_LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Splash_LblStatus.Location = new System.Drawing.Point(174, 390);
            this.Splash_LblStatus.Name = "Splash_LblStatus";
            this.Splash_LblStatus.Size = new System.Drawing.Size(297, 51);
            this.Splash_LblStatus.TabIndex = 5;
            this.Splash_LblStatus.Text = "Status";
            this.Splash_LblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Splash_BtnCancel
            // 
            this.Splash_BtnCancel.Location = new System.Drawing.Point(683, 390);
            this.Splash_BtnCancel.Name = "Splash_BtnCancel";
            this.Splash_BtnCancel.Size = new System.Drawing.Size(86, 23);
            this.Splash_BtnCancel.TabIndex = 6;
            this.Splash_BtnCancel.Text = "Button1";
            this.Splash_BtnCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gabe.Properties.Resources.splash;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(811, 441);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Gabe_Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.Splash_BtnCancel);
            this.Controls.Add(this.Splash_LblStatus);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Gabe_Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gabe_Splash_FormClosing);
            this.Shown += new System.EventHandler(this.Gabe_Splash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Splash_LblStatus;
        internal System.Windows.Forms.Button Splash_BtnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}