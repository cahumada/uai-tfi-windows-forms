namespace Gabe
{
    partial class Login_Title
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
            this.Login_txtUser = new System.Windows.Forms.TextBox();
            this.Login_LblUser = new System.Windows.Forms.Label();
            this.Login_LblPass = new System.Windows.Forms.Label();
            this.Login_txtPass = new System.Windows.Forms.TextBox();
            this.Login_BtnCancel = new System.Windows.Forms.Button();
            this.Login_BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login_txtUser
            // 
            this.Login_txtUser.Location = new System.Drawing.Point(221, 46);
            this.Login_txtUser.Name = "Login_txtUser";
            this.Login_txtUser.Size = new System.Drawing.Size(208, 20);
            this.Login_txtUser.TabIndex = 0;
            // 
            // Login_LblUser
            // 
            this.Login_LblUser.AutoSize = true;
            this.Login_LblUser.Location = new System.Drawing.Point(218, 30);
            this.Login_LblUser.Name = "Login_LblUser";
            this.Login_LblUser.Size = new System.Drawing.Size(58, 13);
            this.Login_LblUser.TabIndex = 1;
            this.Login_LblUser.Text = "&User name";
            // 
            // Login_LblPass
            // 
            this.Login_LblPass.AutoSize = true;
            this.Login_LblPass.Location = new System.Drawing.Point(218, 81);
            this.Login_LblPass.Name = "Login_LblPass";
            this.Login_LblPass.Size = new System.Drawing.Size(53, 13);
            this.Login_LblPass.TabIndex = 2;
            this.Login_LblPass.Text = "&Password";
            // 
            // Login_txtPass
            // 
            this.Login_txtPass.Location = new System.Drawing.Point(221, 97);
            this.Login_txtPass.Name = "Login_txtPass";
            this.Login_txtPass.Size = new System.Drawing.Size(208, 20);
            this.Login_txtPass.TabIndex = 3;
            this.Login_txtPass.UseSystemPasswordChar = true;
            // 
            // Login_BtnCancel
            // 
            this.Login_BtnCancel.Location = new System.Drawing.Point(334, 150);
            this.Login_BtnCancel.Name = "Login_BtnCancel";
            this.Login_BtnCancel.Size = new System.Drawing.Size(95, 23);
            this.Login_BtnCancel.TabIndex = 4;
            this.Login_BtnCancel.Text = "&Cancel";
            this.Login_BtnCancel.UseVisualStyleBackColor = true;
            this.Login_BtnCancel.Click += new System.EventHandler(this.Login_BtnCancel_Click);
            // 
            // Login_BtnOk
            // 
            this.Login_BtnOk.Location = new System.Drawing.Point(234, 150);
            this.Login_BtnOk.Name = "Login_BtnOk";
            this.Login_BtnOk.Size = new System.Drawing.Size(94, 23);
            this.Login_BtnOk.TabIndex = 5;
            this.Login_BtnOk.Text = "&OK";
            this.Login_BtnOk.UseVisualStyleBackColor = true;
            this.Login_BtnOk.Click += new System.EventHandler(this.Login_BtnOk_Click);
            // 
            // Login_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 185);
            this.Controls.Add(this.Login_BtnOk);
            this.Controls.Add(this.Login_BtnCancel);
            this.Controls.Add(this.Login_txtPass);
            this.Controls.Add(this.Login_LblPass);
            this.Controls.Add(this.Login_LblUser);
            this.Controls.Add(this.Login_txtUser);
            this.Name = "Login_Title";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Title_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Login_txtUser;
        private System.Windows.Forms.Label Login_LblUser;
        private System.Windows.Forms.Label Login_LblPass;
        private System.Windows.Forms.TextBox Login_txtPass;
        private System.Windows.Forms.Button Login_BtnCancel;
        private System.Windows.Forms.Button Login_BtnOk;
    }
}