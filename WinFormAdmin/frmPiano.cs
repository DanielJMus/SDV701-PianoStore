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

		private void btnClose_Click(object sender, EventArgs e)
		{
			frmManufacturers.Instance.Show();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if(PushData())
			{

			}
		}

		protected virtual bool PushData ()
		{
			try
			{
				Piano.Name = txtName.Text;
				Piano.Description = txtDescription.Text;
				Piano.Finish = txtFinish.Text;
				Piano.Stand = txtStand.Text;
				Piano.Price = nmPrice.Value;
				Piano.Keys = nmKeys.Value;
				Piano.Voices = nmVoices.Value;
				Piano.Instock = cbInstock.Checked;
				Piano.Style = txtStyle.Text;
			} catch (Exception ex)
			{
				MessageBox.Show(ex.GetBaseException().Message, "Error, please check your data values");
			}
		}

		/*public void SetDetails (ClsAllPianos prPiano)
		{
			_Piano = prPiano;
			UpdateForm();
			ShowDialog
		}*/
	}
}
