using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

/************************************************************************************
 * Modification History:-
 * Date        Who  CodeIDTag  Comments
 * ~~~~~~~~~~  ~~~  ~~~~~~~~~  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * 9/01/2003   PG   <V2.0>     V2.0 Changes. See associated description text.
 *							   Removed PasswordContainer class from this file and 
 *                             placed into a separate class file.
 *  
 * ***********************************************************************************/

namespace Glav.PasswordMgr
{
	/// <summary>
	/// Summary description for AddEntry.
	/// </summary>
	public class frmAddEntry : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.GroupBox grpDetails;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddEntry()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddEntry));
			this.grpDetails = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpDetails
			// 
			this.grpDetails.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label3,
																					 this.label2,
																					 this.label1,
																					 this.txtPwd,
																					 this.txtUserID,
																					 this.txtDesc});
			this.grpDetails.Location = new System.Drawing.Point(8, 8);
			this.grpDetails.Name = "grpDetails";
			this.grpDetails.Size = new System.Drawing.Size(272, 112);
			this.grpDetails.TabIndex = 0;
			this.grpDetails.TabStop = false;
			this.grpDetails.Text = "Enter Details";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 11;
			this.label3.Text = "Password:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "User ID:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Description:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(72, 72);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.Size = new System.Drawing.Size(184, 20);
			this.txtPwd.TabIndex = 8;
			this.txtPwd.Text = "";
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(72, 48);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(184, 20);
			this.txtUserID.TabIndex = 7;
			this.txtUserID.Text = "";
			// 
			// txtDesc
			// 
			this.txtDesc.Location = new System.Drawing.Point(72, 24);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(184, 20);
			this.txtDesc.TabIndex = 6;
			this.txtDesc.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(208, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(128, 128);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmAddEntry
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(286, 156);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnOK,
																		  this.btnCancel,
																		  this.grpDetails});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmAddEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Entry";
			this.grpDetails.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			bool canClose = true;
			string errMsg = "";

			if (txtDesc.Text.Trim() == "")
			{
				canClose = false;
				errMsg = "Description cannot be empty!\n";
			}
			if (txtUserID.Text.Trim() == "")
			{
				canClose = false;
				errMsg += "User ID cannot be empty!\n";
			}
			if (txtPwd.Text.Trim() == "")
			{
				canClose = false;
				errMsg += "Password cannot be empty!";
			}
			
			if (!canClose)
			{
				MessageBox.Show(this,errMsg,"Error!");
				this.DialogResult = DialogResult.Cancel;
			} 
			else
			{
				this.Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		public string Description
		{
			get 
			{
				return txtDesc.Text;
			}
			set // <V2.0>
			{
				txtDesc.Text = value;
			}
		}
		public string UserID
		{
			get 
			{
				return txtUserID.Text;
			}
			set // <V2.0>
			{
				txtUserID.Text = value;
			}
		}
		public string Password
		{
			get 
			{
				return txtPwd.Text;
			}
			set // <V2.0>
			{
				txtPwd.Text = value;
			}
		}
	}
}
