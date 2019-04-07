using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Senegocia.WebApi.Services.Integration
{
    public interface IWebService { }

    public abstract class WebService : IWebService
    {
        private readonly HttpClient _httpClient;

        public WebService()
        {
            // Set up HttpClient instance
            this._httpClient = new HttpClient();

            // TODO: Put this in appsettings.json
            this._httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        protected async Task<string> SendRequest(HttpMethod method, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await this._httpClient.SendAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                return content;
            }                
        }


    }
}
