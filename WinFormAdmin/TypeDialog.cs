using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAdmin
{
	public static class TypeDialog
	{
        public static char ShowDialog()
        {
            Form prompt = new Form();
            prompt.Width = 200;
            prompt.Height = 180;
            prompt.Text = "";
            prompt.StartPosition = FormStartPosition.CenterParent;
            Label textLabel = new Label() { Left = 20, Top = 20, AutoSize=true, TextAlign=System.Drawing.ContentAlignment.MiddleCenter, MaximumSize=new System.Drawing.Size(160, 100), Text = "Which type of piano would you like to add?" };
            RadioButton btnAcoustic = new RadioButton() { Left = 50, Top = 60, Checked=true, Text = "Acoustic" };
            RadioButton btnDigital = new RadioButton() { Left = 50, Top = 80, Text = "Digital" };
            Button confirmation = new Button() { Text = "Ok", Left = 60, Width = 60, Top = 110 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(btnAcoustic);
            prompt.Controls.Add(btnDigital);
            prompt.ShowDialog();
            if (btnAcoustic.Checked)
            {
                return 'A';
            } else
            {
                return 'D';
            }
        }
    }
}
