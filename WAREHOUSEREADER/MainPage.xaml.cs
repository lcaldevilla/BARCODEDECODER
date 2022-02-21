using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace WAREHOUSEREADER
{
    public partial class MainPage : ContentPage
    {

       public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    lbGtin.Text = result.Text;
                });
            };

        }

    }
}
