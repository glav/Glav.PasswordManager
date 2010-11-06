namespace Glav.PasswordMgr
{
    partial class frmPeekWindow
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
            this.pnlPeekDisplay = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlPeekDisplay
            // 
            this.pnlPeekDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPeekDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlPeekDisplay.Name = "pnlPeekDisplay";
            this.pnlPeekDisplay.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlPeekDisplay.Size = new System.Drawing.Size(495, 65);
            this.pnlPeekDisplay.TabIndex = 0;
            // 
            // frmPeekWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 65);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPeekDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPeekWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Peeking at the password";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPeekDisplay;
    }
}