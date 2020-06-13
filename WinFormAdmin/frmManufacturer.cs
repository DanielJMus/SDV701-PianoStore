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
	public partial class frmManufacturer : Form
	{

		private ClsManufacturer _Manufacturer;
		private static readonly frmManufacturer Instance = new frmManufacturer();

		public  ClsManufacturer Manufacturer
		{
			get { return _Manufacturer; }
			set { _Manufacturer = value;  }
		}

		public frmManufacturer()
		{
			InitializeComponent();
		}

		public static void Run (string prManufacturerName)
		{
			if (string.IsNullOrEmpty(prManufacturerName))
			{
				Instance.SetDetails(new ClsManufacturer());
			} else
			{
				Instance.RefreshFormFromDB(prManufacturerName);
			}
			Instance.Show();
		}

		private async void RefreshFormFromDB (string prManufacturerName)
		{
			SetDetails(await ServiceClient.GetManufacturerAsync(prManufacturerName));
		}

		public void SetDetails (ClsManufacturer prManufacturer)
		{
			Manufacturer = prManufacturer;
			lblManufacturerName.Enabled = string.IsNullOrEmpty(Manufacturer.Name);
			UpdateForm();
			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			lstPianoListings.Items.Clear();
			if(Manufacturer.PianoList != null)
			{
				foreach (ClsAllPianos piano in Manufacturer.PianoList)
				{
					string[] columns = { piano.ID.ToString(), piano.Name, piano.GetTypeName(), "$" + piano.Price.ToString() };
					ListViewItem item = new ListViewItem(columns);
					lstPianoListings.Items.Add(item);
				}
			}
		}

		public void UpdateForm ()
		{
			lblManufacturerName.Text = _Manufacturer.Name;
			txtDescription.Text = _Manufacturer.Description;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Settings may not have been saved, are you sure you want to close the form?", "Unsaved settings", MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				frmManufacturers.Instance.Show();
				frmManufacturer.Instance.Hide();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!lblManufacturerName.Enabled)
			{
				char newPiano = TypeDialog.ShowDialog();
				if(newPiano == 'A')
				{
					// Create Acoustic Form
				} 
				else if (newPiano == 'D')
				{
					// Create Digital Form
				}
			} else
			{
				MessageBox.Show("Please save the manufacturer before adding listings.", "Manufacturer has not been added");
			}
				
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			PushData();
			if(lblManufacturerName.Enabled)
			{
				if(string.IsNullOrEmpty(lblManufacturerName.Text))
				{
					MessageBox.Show("Please enter a name for the manufacturer.", "Manufacturer name cannot be empty");
					return;
				}
				MessageBox.Show(await ServiceClient.InsertManufacturerAsync(Manufacturer));
				frmManufacturers.Instance.UpdateDisplay();
				lblManufacturerName.Enabled = false;
			} else
			{
				MessageBox.Show(await ServiceClient.UpdateManufacturerAsync(Manufacturer));
			}
			// If manufacturer does not exist, INSERT it into the database and add its products, otherwise UPDATE it
		}

		private void PushData ()
		{
			Manufacturer.Name = lblManufacturerName.Text;
			Manufacturer.Description = txtDescription.Text;
		}
	}
}
