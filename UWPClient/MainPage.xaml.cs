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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDisplay();
        }

        private async void UpdateDisplay ()
        {
            lstManufacturers.ItemsSource = null;
            try
            {
                lstManufacturers.ItemsSource = await ServiceClient.GetManufacturerNamesAsync();
            }
            catch (Exception ex)
            {
                
            }
        }

        private async void lstManufacturers_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ClsManufacturer lcManufacturer = await ServiceClient.GetManufacturerAsync(lstManufacturers.SelectedItem.ToString());
            if(lcManufacturer != null)
            {
                Frame.Navigate(typeof(frmManufacturer), lstManufacturers.SelectedItem);
            } else
            {
                var error = new MessageDialog("Sorry, this manufacturer is unavailable", "Error");
                await error.ShowAsync();
                UpdateDisplay();
            }
            
        }
    }
}
