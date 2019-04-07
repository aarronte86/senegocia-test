using System.Threading.Tasks;

using Senegocia.WebApi.Services.Integration.Indicators;

namespace Senegocia.WebApi.Services.Indicator
{
    public interface IIndicatorsOutputHandler
    {
        Task<IndicatorDTO> Handle(GetIndicatorRequest request);
    }

    public sealed class IndicatorsOutputHandler : IIndicatorsOutputHandler
    {
        private readonly IIndicatorsService _indicatorsService;

        public IndicatorsOutputHandler(IIndicatorsService indicatorsService)
        {
            this._indicatorsService = indicatorsService;
        }

        public async Task<IndicatorDTO> Handle(GetIndicatorRequest request)
        {
            return await this._indicatorsService.GetIndicators(request.IndicatorType, request.Date);
        }
    }
}
