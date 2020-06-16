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
		private static readonly frmManufacturer _instance = new frmManufacturer();
		public static frmManufacturer Instance
		{
			get { return _instance; }
		}

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

		public async void RefreshFormFromDB (string prManufacturerName)
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

		public void UpdateDisplay()
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
			Instance.Text = _Manufacturer.Name;
			lblManufacturerName.Text = _Manufacturer.Name;
			txtDescription.Text = _Manufacturer.Description;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if(txtDescription.Text != _Manufacturer.Description)
			{
				DialogResult result = MessageBox.Show("Settings may not have been saved, are you sure you want to close the form?", "Unsaved settings", MessageBoxButtons.YesNo);
				if (result == DialogResult.No)
				{
					return;
				}
			}
			frmManufacturers.Instance.Show();
			frmManufacturer.Instance.Hide();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!lblManufacturerName.Enabled)
			{
				char newPiano = TypeDialog.ShowDialog();
				if(newPiano == 'A')
				{
					// Create Acoustic Form
					frmAcoustic.Run(new ClsAllPianos()
					{
						ManufacturerID = lblManufacturerName.Text,
						Type = 'A',
						DateModified = DateTime.Now,
						ID = -1
					}) ;
					
				} 
				else if (newPiano == 'D')
				{
					// Create Digital Form
					frmDigital.Run(new ClsAllPianos()
					{
						ManufacturerID = lblManufacturerName.Text,
						Type = 'D',
						DateModified = DateTime.Now,
						ID = -1
					}) ;
				}
				frmManufacturer.Instance.Hide();
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
				ClsManufacturer _manufacturer = await ServiceClient.GetManufacturerAsync(Manufacturer.Name);
				if(_manufacturer != null)
				{
					MessageBox.Show("This manufacturer already exists.");
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

		private async void lstPianoListings_DoubleClick(object sender, EventArgs e)
		{
			if(lstPianoListings.SelectedItems.Count > 0)
			{
				int lcID = Convert.ToInt32(lstPianoListings.SelectedItems[0].Text);
				OpenPianoListing(await ServiceClient.GetPianoAsync(lcID));
			}
		}

		private void OpenPianoListing (ClsAllPianos prPiano)
		{
			Console.WriteLine(prPiano);
			if (prPiano.Type == 'A')
			{
				// Create Acoustic Form
				frmAcoustic.Run(prPiano);

			}
			else if (prPiano.Type == 'D')
			{
				// Create Digital Form
				frmDigital.Run(prPiano);
			}
			frmManufacturer.Instance.Hide();
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			if (lstPianoListings.SelectedItems.Count > 0)
			{
				int lcID = Convert.ToInt32(lstPianoListings.SelectedItems[0].Text);
				var confirmation = MessageBox.Show("Are you sure you want to delete this listing?", "Confirm Deletion", MessageBoxButtons.YesNo);
				if (confirmation == DialogResult.Yes)
				{
					MessageBox.Show(await ServiceClient.DeletePianoAsync(lcID));
					RefreshFormFromDB(Manufacturer.Name);
				}
			}
		}
	}
}
