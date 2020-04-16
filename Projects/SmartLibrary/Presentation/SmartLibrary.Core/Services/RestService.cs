using ModernHttpClient;
using Newtonsoft.Json;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartLibrary.Core.Services
{
    public class RestService : IRestService
    {
        public async Task<T> GetDataAsync<T>(string url) where T : class
        {
            using (var handler = GetHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    try
                    {
                        string json = await client.GetStringAsync(url);
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
        }

        private HttpClientHandler GetHandler()
        {
            return Device.RuntimePlatform == Device.UWP
                ? new HttpClientHandler()
                : new NativeMessageHandler();
        }

        public async Task<T> PostDataAsync<T>(string url, T payload) where T : class
        {
            using (var handler = GetHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    try
                    {
                        var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
        }
    }
}
