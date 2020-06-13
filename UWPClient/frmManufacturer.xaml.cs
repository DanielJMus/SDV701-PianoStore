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
	public sealed partial class frmManufacturer : Page
	{

		private ClsManufacturer _manufacturer;

		public frmManufacturer()
		{
			this.InitializeComponent();
		}

		private void ListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
		{
			
		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			string lcManufacturer = e.Parameter.ToString();
			_manufacturer = await ServiceClient.GetManufacturerAsync(lcManufacturer);
			UpdateForm();
		}

		private async void UpdateForm ()
		{
			List<ClsAllPianos> lcPianoList = await ServiceClient.GetAllPianosAsync(_manufacturer.Name);
			if(lcPianoList != null)
			{
				foreach(ClsAllPianos lcPiano in lcPianoList)
				{
					lstPianos.Items.Add(lcPiano.Name + "   |    " + ((lcPiano.Type == 'A') ? "Acoustic" : "Digital") + "   |    $" + lcPiano.Price.ToString() );
				}
			}
			txtDescription.Text = _manufacturer.Description;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}
	}
}
