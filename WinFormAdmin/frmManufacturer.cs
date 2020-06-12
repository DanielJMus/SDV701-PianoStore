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

		private List<ClsAllPianos> _PianoList;
		public List<ClsAllPianos> PianoList { get => _PianoList; set => _PianoList = value; }

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
			lblManufacturerName.Text = _Manufacturer.Name;
			UpdateForm();
			UpdateDisplay();
		}

		private async void UpdateDisplay()
		{
			_PianoList = await ServiceClient.GetAllPianosAsync(_Manufacturer.Name);
			lstPianoListings.Items.Clear();
			if(_PianoList != null)
			{
				foreach (ClsAllPianos piano in _PianoList)
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
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			frmManufacturers.Instance.Show();
			frmManufacturer.Instance.Hide();
		}
	}
}
