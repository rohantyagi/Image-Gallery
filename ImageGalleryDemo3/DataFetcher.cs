using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;

namespace ImageGalleryDemo3
{
    class DataFetcher
    {
        private async Task<string> GetDatafromServiceAsync(string searchstring)
        {
            string readText = null;
            try
            {
                var azure = @"https://imagefetcher20200529182038.azurewebsites.net";
                    string url = azure + @"/api/fetch_images?query=" + searchstring + "&max_count=5";
                    using (HttpClient c = new HttpClient())
                    {
                        readText = await c.GetStringAsync(url);
                    }
                
            }
            catch
            {
                readText = File.ReadAllText(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\Data.json");
                Console.WriteLine(readText);
            }
            return readText;
        }
        public async Task<List<ImageItem>> GetImageDataAsync(string search)
        {
            string data = await GetDatafromServiceAsync(search);
            return JsonConvert.DeserializeObject<List<ImageItem>>(data);
        }

    }
}
