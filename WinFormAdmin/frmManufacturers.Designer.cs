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
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lstManufacturers = new System.Windows.Forms.ListBox();
			this.btnOrders = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(273, 60);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(107, 41);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(273, 178);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(107, 37);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(273, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(107, 42);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// lstManufacturers
			// 
			this.lstManufacturers.FormattingEnabled = true;
			this.lstManufacturers.Location = new System.Drawing.Point(12, 12);
			this.lstManufacturers.Name = "lstManufacturers";
			this.lstManufacturers.Size = new System.Drawing.Size(255, 160);
			this.lstManufacturers.TabIndex = 7;
			// 
			// btnOrders
			// 
			this.btnOrders.Location = new System.Drawing.Point(12, 178);
			this.btnOrders.Name = "btnOrders";
			this.btnOrders.Size = new System.Drawing.Size(179, 37);
			this.btnOrders.TabIndex = 8;
			this.btnOrders.Text = "Orders";
			this.btnOrders.UseVisualStyleBackColor = true;
			this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
			// 
			// frmManufacturers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 227);
			this.Controls.Add(this.btnOrders);
			this.Controls.Add(this.lstManufacturers);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDelete);
			this.Name = "frmManufacturers";
			this.Text = "Piano Store";
			this.Load += new System.EventHandler(this.frmManufacturers_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox lstManufacturers;
		private System.Windows.Forms.Button btnOrders;
	}
}

