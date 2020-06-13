using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormAdmin
{
	public partial class frmAcoustic : WinFormAdmin.frmPiano
	{
		private static readonly frmAcoustic _instance = new frmAcoustic();
		public static frmAcoustic Instance
		{
			get { return _instance; }
		}

		public frmAcoustic()
		{
			InitializeComponent();
		}

		public static void Run(ClsAllPianos prPiano)
		{
			Instance.SetDetails(prPiano);
		}

		protected override bool PushData()
		{
			if (base.PushData())
			{
				Piano.Finish = txtFinish.Text;
				Piano.Style = txtStyle.Text;
				return true;
			}
			else
			{
				return false;
			}
		}

		protected override void UpdateForm()
		{
			base.UpdateForm();
			txtFinish.Text = Piano.Finish;
			txtStyle.Text = Piano.Style;
		}
	}
}
