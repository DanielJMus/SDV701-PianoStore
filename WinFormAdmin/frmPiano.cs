using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAdmin
{
	public partial class frmPiano : Form
	{
		private ClsAllPianos _Piano;
		protected ClsAllPianos Piano { get => _Piano; set => _Piano = value; }

		public frmPiano()
		{
			InitializeComponent();
		}

		public void SetDetails (ClsAllPianos prPiano)
		{
			Piano = prPiano;
			UpdateForm();
			Show();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if(txtDescription.Text != _Piano.Description || txtName.Text != _Piano.Name || cbInStock.Checked != _Piano.Instock || nmPrice.Value != _Piano.Price)
			{
				DialogResult result = MessageBox.Show("Settings may not have been saved, are you sure you want to close the form?", "Unsaved settings", MessageBoxButtons.YesNo);
				if (result == DialogResult.No)
				{
					return;
				}
			}
			frmManufacturer.Instance.Show();
			frmManufacturer.Instance.RefreshFormFromDB(Piano.ManufacturerID);
			Hide();
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			if(PushData())
			{
				if(Piano.ID < 0)
				{
					MessageBox.Show(await ServiceClient.InsertPianoAsync(Piano));
				}
				else
				{
					MessageBox.Show(await ServiceClient.UpdatePianoAsync(Piano));
				}
				frmManufacturer.Instance.UpdateDisplay();
			}
		}

		protected virtual bool PushData ()
		{
			try
			{
				Piano.Name = txtName.Text;
				Piano.Description = txtDescription.Text;
				Piano.Price = nmPrice.Value;
				Piano.Instock = cbInStock.Checked;
				Piano.DateModified = DateTime.Now;
				return true;
			} catch (Exception ex)
			{
				MessageBox.Show(ex.GetBaseException().Message, "Error, please check your data values");
				return false;
			}
		}

		protected virtual void UpdateForm()
		{
			txtName.Text = (Piano.Name == null) ? string.Empty : Piano.Name;
			txtDescription.Text = (Piano.Description == null) ? string.Empty : Piano.Description;
			nmPrice.Value = Piano.Price;
			cbInStock.Checked = Piano.Instock;
			lblDateModified.Text = (Piano.DateModified == null) ? string.Empty : "Date Modified: " + Piano.DateModified.ToString();
			lblManufacturer.Text = Piano.ManufacturerID;
		}
	}
}
