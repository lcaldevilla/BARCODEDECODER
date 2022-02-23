using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using WAREHOUSEREADER.LIB;
using Xamarin.Forms;
using ZXing;
using ZXing.Client.Result;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace WAREHOUSEREADER
{
    public partial class MainPage : ContentPage
    {
        GS1 gs1code = new GS1();
        char gs1 = (char)0x29;


        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var restful = new RestService();
            var barcodeObject = new Barcode();

            barcodeObject.Batch = "Test15974F83B7";
            barcodeObject.GTIN = "08470001592873";
            barcodeObject.Serial = "PK0019985501B734147";
            barcodeObject.Expire = "270218";

         
            lbResponse.Text = "Enviando solicitud...";
            var response = await restful.SaveBarcodeAsync(barcodeObject);
            lbResponse.Text = response;
            /*
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions
             {
                 PossibleFormats = new List<ZXing.BarcodeFormat>() {
                     ZXing.BarcodeFormat.DATA_MATRIX,
                     ZXing.BarcodeFormat.CODE_128,
                     ZXing.BarcodeFormat.EAN_13
                 },
                 AssumeGS1 = true,
                 AutoRotate=true,
                 TryHarder=true
             };


             var scanPage = new ZXingScannerPage(options);
             // Navigate to our scanner page
             await Navigation.PushAsync(scanPage);

             scanPage.OnScanResult += (result) =>
             {
                 scanPage.IsScanning = false;

                 Device.BeginInvokeOnMainThread(async () =>
                 {
                     await Navigation.PopAsync();
                     Drkstr.EAN128.EAN128Barcode EAN128 = new Drkstr.EAN128.EAN128Barcode();
                     GS1 ean128 = new GS1();
                     try
                     {
                         string serieTemp = Regex.Replace(result.Text.Remove(0,1), @"[^\u001D\u0020-\u007E]", "");
                         byte[] barcode = Encoding.ASCII.GetBytes(serieTemp);
                         EAN128.AddBarcode(barcode);
                         if (gs1code.ParseGS1(EAN128.ToString()) == true)
                         {
                            // Console.WriteLine("cadena: "+result.NumBits);
                             lbBatch.Text = gs1code.GetLote();
                             lbGtin.Text = gs1code.GetGTIN();
                             lbSerial.Text = gs1code.GetSerie();
                             lbExpire.Text = gs1code.GetCaducidad();

                             barcodeObject.Batch = gs1code.GetLote();
                             barcodeObject.GTIN = gs1code.GetGTIN();
                             barcodeObject.Serial = gs1code.GetSerie();
                             barcodeObject.Expire = gs1code.GetCaducidad();

                         }
                     }
                     catch (Exception ex)
                     {
                        // Console.WriteLine("cadena error: " + Regex.Replace(result.Text, @"[^\u001D\u0020-\u007E]", ""));
                         lbGtin.Text = "error";
                         lbBatch.Text = ex.Message;

                     }


                 });

             };  */          
        }
    }
}
