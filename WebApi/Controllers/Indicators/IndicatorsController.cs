using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Senegocia.WebApi.Services.Indicator;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/indicators")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly IIndicatorsOutputHandler _indicatorsOutputHandler;

        public IndicatorsController(IIndicatorsOutputHandler indicatorsOutputHandler)
        {
            this._indicatorsOutputHandler = indicatorsOutputHandler;
        }

        // GET indicators
        [Route("{indicatorType}/{date}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]GetIndicatorRequest request)
        {
            var indicator = await this._indicatorsOutputHandler.Handle(request);

            if (indicator == null)
            {
                return NotFound();
            }

            return Ok(indicator);
        }
    }
}
