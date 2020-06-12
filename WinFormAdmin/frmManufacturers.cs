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
		public static frmManufacturers instance
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

		private async void UpdateDisplay ()
		{
			lstManufacturers.DataSource = null;
			lstManufacturers.DataSource = await ServiceClient.GetManufacturerNamesAsync();
		}

		private void lstManufacturers_DoubleClick(object sender, EventArgs e)
		{
			string lcName;
			lcName = Convert.ToString(lstManufacturers.SelectedItem);
			if(lcName != null)
			{
				try
				{
					frmManufacturer.Run(lcName);
					frmManufacturers.instance.Hide();
				} catch (Exception exception)
				{
					MessageBox.Show(exception.Message, "Please selected a manufacturer from the list.");
				}
			}
		}
	}
}
