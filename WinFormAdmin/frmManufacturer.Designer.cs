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
			this.lstPianoListings = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblManufacturerName
			// 
			this.lblManufacturerName.AutoSize = true;
			this.lblManufacturerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblManufacturerName.Location = new System.Drawing.Point(30, 25);
			this.lblManufacturerName.Name = "lblManufacturerName";
			this.lblManufacturerName.Size = new System.Drawing.Size(143, 18);
			this.lblManufacturerName.TabIndex = 0;
			this.lblManufacturerName.Text = "[ManufacturerName]";
			// 
			// lstPianoListings
			// 
			this.lstPianoListings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lstPianoListings.HideSelection = false;
			this.lstPianoListings.Location = new System.Drawing.Point(33, 59);
			this.lstPianoListings.Name = "lstPianoListings";
			this.lstPianoListings.Size = new System.Drawing.Size(307, 120);
			this.lstPianoListings.TabIndex = 1;
			this.lstPianoListings.UseCompatibleStateImageBehavior = false;
			this.lstPianoListings.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 123;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Type";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Price";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(391, 310);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmManufacturer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 345);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lstPianoListings);
			this.Controls.Add(this.lblManufacturerName);
			this.Name = "frmManufacturer";
			this.Text = "frmManufacturer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblManufacturerName;
		private System.Windows.Forms.ListView lstPianoListings;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button btnClose;
	}
}