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
	public sealed partial class frmManufacturers : Form
	{

		private static readonly frmManufacturers _instance = new frmManufacturers();
		public static frmManufacturers Instance
		{
			get { return _instance; }
		}

		public frmManufacturers()
		{
			InitializeComponent();
		}

		private void frmManufacturers_Load(object sender, EventArgs e)
		{
			UpdateDisplay();
		}

		public async void UpdateDisplay ()
		{
			lstManufacturers.DataSource = null;
			lstManufacturers.DataSource = await ServiceClient.GetManufacturerNamesAsync();
		}

		private void lstManufacturers_DoubleClick(object sender, EventArgs e)
		{
			string lcName;
			lcName = Convert.ToString(lstManufacturers.SelectedItem);
			if(!string.IsNullOrEmpty(lcName))
			{
				try
				{
					frmManufacturer.Run(lcName);
					frmManufacturers.Instance.Hide();
				} catch (Exception exception)
				{
					MessageBox.Show(exception.Message, "Please selected a manufacturer from the list.");
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				frmManufacturer.Run(null);
				frmManufacturers.Instance.Hide();
			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error adding new manufacturer");
			}
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			string lcName;
			lcName = Convert.ToString(lstManufacturers.SelectedItem);
			if (!string.IsNullOrEmpty(lcName))
			{
				var confirmation = MessageBox.Show("Are you sure you want to delete this manufacturer?", "Confirm Deletion", MessageBoxButtons.YesNo);
				if(confirmation == DialogResult.Yes)
				{
					MessageBox.Show(await ServiceClient.DeleteManufacturerAsync(lcName));
					UpdateDisplay();
				}
				
			}
		}

		private void btnOrders_Click(object sender, EventArgs e)
		{
			frmOrders.Run();
			frmManufacturers.Instance.Hide();
		}
	}
}
