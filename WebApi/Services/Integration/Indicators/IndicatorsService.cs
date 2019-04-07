using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Senegocia.WebApi.Services.Integration.Indicators
{
    public interface IIndicatorsService
    {
        Task<IndicatorDTO> GetIndicators(string type, string date);
    }

    public sealed class IndicatorsService : WebService, IIndicatorsService
    {
        // TODO: Put this in the appsettings.json
        private const string baseUrl = "https://www.mindicador.cl/api";

        public async Task<IndicatorDTO> GetIndicators(string type, string date)
        {
            string url = $"{baseUrl}/{type}/{date}";

            string responseContent = await this.SendRequest(HttpMethod.Get, url);

            if (responseContent == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IndicatorDTO>(responseContent, new IndicatorConverter());
        }
    }
}
