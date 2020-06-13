namespace WinFormAdmin
{
	partial class frmDigital
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
			this.nmKeys = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nmVoices = new System.Windows.Forms.NumericUpDown();
			this.lblVoices = new System.Windows.Forms.Label();
			this.txtStand = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nmKeys)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmVoices)).BeginInit();
			this.SuspendLayout();
			// 
			// nmKeys
			// 
			this.nmKeys.Location = new System.Drawing.Point(69, 252);
			this.nmKeys.Name = "nmKeys";
			this.nmKeys.Size = new System.Drawing.Size(61, 20);
			this.nmKeys.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 254);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Keys";
			// 
			// nmVoices
			// 
			this.nmVoices.Location = new System.Drawing.Point(69, 277);
			this.nmVoices.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nmVoices.Name = "nmVoices";
			this.nmVoices.Size = new System.Drawing.Size(61, 20);
			this.nmVoices.TabIndex = 13;
			this.nmVoices.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
			// 
			// lblVoices
			// 
			this.lblVoices.AutoSize = true;
			this.lblVoices.Location = new System.Drawing.Point(24, 279);
			this.lblVoices.Name = "lblVoices";
			this.lblVoices.Size = new System.Drawing.Size(39, 13);
			this.lblVoices.TabIndex = 14;
			this.lblVoices.Text = "Voices";
			// 
			// txtStand
			// 
			this.txtStand.Location = new System.Drawing.Point(69, 304);
			this.txtStand.Name = "txtStand";
			this.txtStand.Size = new System.Drawing.Size(100, 20);
			this.txtStand.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 307);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Stand";
			// 
			// frmDigital
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(295, 381);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtStand);
			this.Controls.Add(this.lblVoices);
			this.Controls.Add(this.nmVoices);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nmKeys);
			this.Name = "frmDigital";
			this.Controls.SetChildIndex(this.nmKeys, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.nmVoices, 0);
			this.Controls.SetChildIndex(this.lblVoices, 0);
			this.Controls.SetChildIndex(this.txtStand, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			((System.ComponentModel.ISupportInitialize)(this.nmKeys)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmVoices)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown nmKeys;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nmVoices;
		private System.Windows.Forms.Label lblVoices;
		private System.Windows.Forms.TextBox txtStand;
		private System.Windows.Forms.Label label5;
	}
}
