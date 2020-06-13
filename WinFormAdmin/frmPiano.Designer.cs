namespace WinFormAdmin
{
	partial class frmPiano
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblManufacturer = new System.Windows.Forms.Label();
			this.cbInStock = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(24, 346);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(115, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(156, 346);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(114, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(24, 48);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(140, 20);
			this.txtName.TabIndex = 2;
			this.txtName.Text = "Name";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(24, 74);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(246, 156);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Text = "Description";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Location = new System.Drawing.Point(204, 48);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.numericUpDown1.Size = new System.Drawing.Size(66, 20);
			this.numericUpDown1.TabIndex = 4;
			// 
			// lblManufacturer
			// 
			this.lblManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblManufacturer.Location = new System.Drawing.Point(24, 9);
			this.lblManufacturer.Name = "lblManufacturer";
			this.lblManufacturer.Size = new System.Drawing.Size(246, 36);
			this.lblManufacturer.TabIndex = 5;
			this.lblManufacturer.Text = "[ManufacturerName]";
			this.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbInStock
			// 
			this.cbInStock.AutoSize = true;
			this.cbInStock.Location = new System.Drawing.Point(24, 236);
			this.cbInStock.Name = "cbInStock";
			this.cbInStock.Size = new System.Drawing.Size(66, 17);
			this.cbInStock.TabIndex = 6;
			this.cbInStock.Text = "In Stock";
			this.cbInStock.UseVisualStyleBackColor = true;
			// 
			// frmPiano
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 381);
			this.Controls.Add(this.cbInStock);
			this.Controls.Add(this.lblManufacturer);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Name = "frmPiano";
			this.Text = "frmPiano";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label lblManufacturer;
		private System.Windows.Forms.CheckBox cbInStock;
	}
}