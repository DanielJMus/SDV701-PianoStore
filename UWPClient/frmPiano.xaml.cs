using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static UWPClient.DTO;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPClient
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class frmPiano : Page
	{
		public frmPiano()
		{
			this.InitializeComponent();
		}

		private ClsAllPianos _piano;

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{

		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			_piano = await ServiceClient.GetPianoAsync(int.Parse(e.Parameter.ToString()));
			UpdateForm();
		}

		private void UpdateForm ()
		{
			txtName.Text = _piano.Name;
			txtDescription.Text = _piano.Description;
			txtPrice.Text = _piano.Price.ToString();
			if(_piano.Type == 'A')
			{
				txtDetails.Text = "Finish: " + _piano.Finish + "\n" +
									"Style: " + _piano.Style;
			} else if (_piano.Type == 'D')
			{
				txtDetails.Text = "Stand: " + _piano.Stand + "\n" +
									"Keys: " + _piano.Keys + "\n" +
									"Voices: " + _piano.Voices;
			}
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		private void btnOrder_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(frmOrder), _piano.ID);
		}
	}
}
