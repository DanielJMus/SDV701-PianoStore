namespace WinFormAdmin
{
	partial class frmManufacturer
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
			this.lblManufacturerName = new System.Windows.Forms.Label();
			this.lstPianoListings = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lblManufacturerName
			// 
			this.lblManufacturerName.AutoSize = true;
			this.lblManufacturerName.Location = new System.Drawing.Point(63, 29);
			this.lblManufacturerName.Name = "lblManufacturerName";
			this.lblManufacturerName.Size = new System.Drawing.Size(35, 13);
			this.lblManufacturerName.TabIndex = 0;
			this.lblManufacturerName.Text = "label1";
			// 
			// lstPianoListings
			// 
			this.lstPianoListings.FormattingEnabled = true;
			this.lstPianoListings.Location = new System.Drawing.Point(57, 113);
			this.lstPianoListings.Name = "lstPianoListings";
			this.lstPianoListings.Size = new System.Drawing.Size(120, 95);
			this.lstPianoListings.TabIndex = 1;
			// 
			// frmManufacturer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lstPianoListings);
			this.Controls.Add(this.lblManufacturerName);
			this.Name = "frmManufacturer";
			this.Text = "frmManufacturer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblManufacturerName;
		private System.Windows.Forms.ListBox lstPianoListings;
	}
}