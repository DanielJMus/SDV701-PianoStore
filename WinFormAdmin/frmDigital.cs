using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormAdmin
{
	public partial class frmDigital : WinFormAdmin.frmPiano
	{

		private static readonly frmDigital _instance = new frmDigital();
		public static frmDigital Instance
		{
			get { return _instance; }
		}

		public frmDigital()
		{
			InitializeComponent();
		}

		public static void Run(ClsAllPianos prPiano)
		{
			Instance.SetDetails( prPiano );
		}

		protected override bool PushData ()
		{
			if(base.PushData())
			{
				Piano.Keys = (int)nmKeys.Value;
				Piano.Voices = (int)nmVoices.Value;
				Piano.Stand = txtStand.Text;
				return true;
			} else
			{
				return false;
			}
		}

		protected override void UpdateForm()
		{
			base.UpdateForm();
			nmKeys.Value = Piano.Keys;
			nmVoices.Value = Piano.Voices;
			txtStand.Text = (string.IsNullOrEmpty(Piano.Stand)) ? string.Empty : Piano.Stand;
		}


	}
}
