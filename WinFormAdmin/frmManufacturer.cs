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

		public  ClsManufacturer Manufacturers
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
			Manufacturers = prManufacturer;
			lblManufacturerName.Text = _Manufacturer.Name;
			UpdateForm();
			UpdateDisplay();
		}

		private async void UpdateDisplay()
		{
			_PianoList = await ServiceClient.GetAllPianosAsync(_Manufacturer.Name);
			// Loads all of the items listed for the manufacturer
			lstPianoListings.DataSource = null;
			Console.WriteLine(_PianoList[0].Name);
		}

		public void UpdateForm ()
		{
			lblManufacturerName.Text = _Manufacturer.Name;
		}
	}
}
