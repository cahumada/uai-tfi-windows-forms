
namespace Gabe.Controles
{
    partial class UsuarioControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioControl));
            this.LblUser = new System.Windows.Forms.Label();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.ErrProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(90, 4);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(0, 13);
            this.LblUser.TabIndex = 5;
            // 
            // TxtUser
            // 
            this.TxtUser.Location = new System.Drawing.Point(3, 3);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(46, 20);
            this.TxtUser.TabIndex = 3;
            this.TxtUser.TextChanged += new System.EventHandler(this.TxtUser_TextChanged);
            this.TxtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUser_KeyPress);
            this.TxtUser.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUser_Validating);
            // 
            // ErrProv
            // 
            this.ErrProv.ContainerControl = this;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
            this.BtnSearch.Location = new System.Drawing.Point(53, 1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(26, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // UsuarioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtUser);
            this.Name = "UsuarioControl";
            this.Size = new System.Drawing.Size(236, 26);
            ((System.ComponentModel.ISupportInitialize)(this.ErrProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblUser;
        internal System.Windows.Forms.Button BtnSearch;
        internal System.Windows.Forms.TextBox TxtUser;
        internal System.Windows.Forms.ErrorProvider ErrProv;
    }
}
