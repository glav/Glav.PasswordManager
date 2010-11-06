namespace Glav.PasswordMgr
{
    partial class frmPassphraseEntry
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
            System.Security.SecureString secureString1 = new System.Security.SecureString();
            System.Security.SecureString secureString2 = new System.Security.SecureString();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPassphraseEntry));
            this.txtEntry = new SecurePasswordTextBox.SecureTextBox();
            this.txtReEntry = new SecurePasswordTextBox.SecureTextBox();
            this.lblReEnter = new System.Windows.Forms.Label();
            this.lblEnter = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEntry
            // 
            this.txtEntry.Location = new System.Drawing.Point(15, 25);
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.PasswordChar = '*';
            this.txtEntry.SecureText = secureString1;
            this.txtEntry.Size = new System.Drawing.Size(347, 20);
            this.txtEntry.TabIndex = 0;
            // 
            // txtReEntry
            // 
            this.txtReEntry.Location = new System.Drawing.Point(12, 64);
            this.txtReEntry.Name = "txtReEntry";
            this.txtReEntry.PasswordChar = '*';
            this.txtReEntry.SecureText = secureString2;
            this.txtReEntry.Size = new System.Drawing.Size(350, 20);
            this.txtReEntry.TabIndex = 1;
            // 
            // lblReEnter
            // 
            this.lblReEnter.AutoSize = true;
            this.lblReEnter.Location = new System.Drawing.Point(12, 48);
            this.lblReEnter.Name = "lblReEnter";
            this.lblReEnter.Size = new System.Drawing.Size(109, 13);
            this.lblReEnter.TabIndex = 2;
            this.lblReEnter.Text = "Re-enter Passphrase:";
            // 
            // lblEnter
            // 
            this.lblEnter.AutoSize = true;
            this.lblEnter.Location = new System.Drawing.Point(12, 9);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(93, 13);
            this.lblEnter.TabIndex = 3;
            this.lblEnter.Text = "Enter Passphrase:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(287, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "O&K";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmPassphraseEntry
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(374, 123);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblEnter);
            this.Controls.Add(this.lblReEnter);
            this.Controls.Add(this.txtReEntry);
            this.Controls.Add(this.txtEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassphraseEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passphrase Entry";
            this.Load += new System.EventHandler(this.frmPassphraseEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SecurePasswordTextBox.SecureTextBox txtEntry;
        private SecurePasswordTextBox.SecureTextBox txtReEntry;
        private System.Windows.Forms.Label lblReEnter;
        private System.Windows.Forms.Label lblEnter;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}