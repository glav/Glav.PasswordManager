namespace Glav.PasswordMgr
{
    partial class frmConvertOldFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertOldFile));
            this.dlgReadFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgWriteFile = new System.Windows.Forms.SaveFileDialog();
            this.grpFileDetails = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseWrite = new System.Windows.Forms.Button();
            this.btnBrowseRead = new System.Windows.Forms.Button();
            this.txtWriteFile = new System.Windows.Forms.TextBox();
            this.txtReadFile = new System.Windows.Forms.TextBox();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpFileDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgReadFile
            // 
            this.dlgReadFile.DefaultExt = "pgr";
            this.dlgReadFile.Filter = "Password Manager Files|*.pgr|All Files|*.*";
            // 
            // dlgWriteFile
            // 
            this.dlgWriteFile.DefaultExt = "pgr";
            this.dlgWriteFile.Filter = "Password Manager Files|*.pgr|All Files|*.*";
            // 
            // grpFileDetails
            // 
            this.grpFileDetails.Controls.Add(this.label2);
            this.grpFileDetails.Controls.Add(this.label1);
            this.grpFileDetails.Controls.Add(this.btnBrowseWrite);
            this.grpFileDetails.Controls.Add(this.btnBrowseRead);
            this.grpFileDetails.Controls.Add(this.txtWriteFile);
            this.grpFileDetails.Controls.Add(this.txtReadFile);
            this.grpFileDetails.Location = new System.Drawing.Point(4, 12);
            this.grpFileDetails.Name = "grpFileDetails";
            this.grpFileDetails.Size = new System.Drawing.Size(418, 136);
            this.grpFileDetails.TabIndex = 0;
            this.grpFileDetails.TabStop = false;
            this.grpFileDetails.Text = "Enter File Conversion Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File to write to (New/Current format):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File to Read/Convert (Previous Format):";
            // 
            // btnBrowseWrite
            // 
            this.btnBrowseWrite.Location = new System.Drawing.Point(325, 93);
            this.btnBrowseWrite.Name = "btnBrowseWrite";
            this.btnBrowseWrite.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseWrite.TabIndex = 3;
            this.btnBrowseWrite.Text = "Browse";
            this.btnBrowseWrite.UseVisualStyleBackColor = true;
            this.btnBrowseWrite.Click += new System.EventHandler(this.btnBrowseWrite_Click);
            // 
            // btnBrowseRead
            // 
            this.btnBrowseRead.Location = new System.Drawing.Point(325, 48);
            this.btnBrowseRead.Name = "btnBrowseRead";
            this.btnBrowseRead.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseRead.TabIndex = 2;
            this.btnBrowseRead.Text = "Browse";
            this.btnBrowseRead.UseVisualStyleBackColor = true;
            this.btnBrowseRead.Click += new System.EventHandler(this.btnBrowseRead_Click);
            // 
            // txtWriteFile
            // 
            this.txtWriteFile.Location = new System.Drawing.Point(11, 96);
            this.txtWriteFile.Name = "txtWriteFile";
            this.txtWriteFile.Size = new System.Drawing.Size(308, 20);
            this.txtWriteFile.TabIndex = 1;
            // 
            // txtReadFile
            // 
            this.txtReadFile.Location = new System.Drawing.Point(11, 51);
            this.txtReadFile.Name = "txtReadFile";
            this.txtReadFile.Size = new System.Drawing.Size(308, 20);
            this.txtReadFile.TabIndex = 0;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(4, 154);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(418, 23);
            this.progBar.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(347, 241);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Con&vert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 83);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // frmConvertOldFile
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 276);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.grpFileDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvertOldFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert files from previous versions";
            this.grpFileDetails.ResumeLayout(false);
            this.grpFileDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgReadFile;
        private System.Windows.Forms.SaveFileDialog dlgWriteFile;
        private System.Windows.Forms.GroupBox grpFileDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseWrite;
        private System.Windows.Forms.Button btnBrowseRead;
        private System.Windows.Forms.TextBox txtWriteFile;
        private System.Windows.Forms.TextBox txtReadFile;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
    }
}