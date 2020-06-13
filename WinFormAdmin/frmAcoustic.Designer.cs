namespace WinFormAdmin
{
	partial class frmAcoustic
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
			this.lblFinish = new System.Windows.Forms.Label();
			this.txtFinish = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtStyle = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblFinish
			// 
			this.lblFinish.AutoSize = true;
			this.lblFinish.Location = new System.Drawing.Point(19, 272);
			this.lblFinish.Name = "lblFinish";
			this.lblFinish.Size = new System.Drawing.Size(34, 13);
			this.lblFinish.TabIndex = 18;
			this.lblFinish.Text = "Finish";
			// 
			// txtFinish
			// 
			this.txtFinish.Location = new System.Drawing.Point(64, 269);
			this.txtFinish.Name = "txtFinish";
			this.txtFinish.Size = new System.Drawing.Size(100, 20);
			this.txtFinish.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 297);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Style";
			// 
			// txtStyle
			// 
			this.txtStyle.Location = new System.Drawing.Point(64, 294);
			this.txtStyle.Name = "txtStyle";
			this.txtStyle.Size = new System.Drawing.Size(100, 20);
			this.txtStyle.TabIndex = 19;
			// 
			// frmAcoustic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(295, 381);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtStyle);
			this.Controls.Add(this.lblFinish);
			this.Controls.Add(this.txtFinish);
			this.Name = "frmAcoustic";
			this.Controls.SetChildIndex(this.txtFinish, 0);
			this.Controls.SetChildIndex(this.lblFinish, 0);
			this.Controls.SetChildIndex(this.txtStyle, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFinish;
		private System.Windows.Forms.TextBox txtFinish;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtStyle;
	}
}
