using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static UWPClient.DTO;
using static Windows.UI.Popups.MessageDialog;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPClient
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class frmOrder : Page
	{

		private ClsAllPianos _piano;

		public frmOrder()
		{
			this.InitializeComponent();
		}

		protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			int orderID = int.Parse(e.Parameter.ToString());
			_piano = await ServiceClient.GetPianoAsync(orderID);
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		private async void btnOrder_Click(object sender, RoutedEventArgs e)
		{
			var confirmation = new MessageDialog("Are you sure you want to place an order?", "Confirm order");

			confirmation.Commands.Add(new UICommand("Place Order", null));
			confirmation.Commands.Add(new UICommand("Cancel", null));
			confirmation.CancelCommandIndex = 1;


			var result = await confirmation.ShowAsync();
			if(result.Label == "Place Order")
			{
				Debug.WriteLine(result.Label);
				string response = await ServiceClient.InsertOrderAsync(new ClsOrder()
				{
					Name = txtName.Text,
					Email = txtEmail.Text,
					Phone = txtPhone.Text,
					Total = _piano.Price,
					Date = DateTime.Now,
					ProductID = _piano.ID
				});		
				//Frame.Navigate(typeof(MainPage));
			}
		}
	}
}
