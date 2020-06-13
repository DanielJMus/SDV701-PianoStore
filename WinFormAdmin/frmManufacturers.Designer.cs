namespace WinFormAdmin
{
	partial class frmManufacturers
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
			this.lstManufacturers = new System.Windows.Forms.ListBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstManufacturers
			// 
			this.lstManufacturers.FormattingEnabled = true;
			this.lstManufacturers.Location = new System.Drawing.Point(12, 12);
			this.lstManufacturers.Name = "lstManufacturers";
			this.lstManufacturers.Size = new System.Drawing.Size(329, 108);
			this.lstManufacturers.TabIndex = 0;
			this.lstManufacturers.DoubleClick += new System.EventHandler(this.lstManufacturers_DoubleClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(348, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(107, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(348, 42);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(107, 23);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// frmManufacturers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 278);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstManufacturers);
			this.Name = "frmManufacturers";
			this.Text = "Piano Store";
			this.Load += new System.EventHandler(this.frmManufacturers_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstManufacturers;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
	}
}

