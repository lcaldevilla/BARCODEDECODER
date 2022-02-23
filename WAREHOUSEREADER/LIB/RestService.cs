using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WAREHOUSEREADER.LIB
{
    class RestService
    {
        HttpClient client;
        private const string url = "http://192.168.1.141:55584/api/barcode";

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<string> SaveBarcodeAsync(Barcode barcode)
        {
            Uri uri = new Uri(url);
            string json = JsonConvert.SerializeObject(barcode);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            Console.WriteLine("Waiting Response: " + json.ToString());
            await client.PostAsync(uri, content);
             Console.WriteLine("Response: " + response);
            return "ok";
        }
    }
}
