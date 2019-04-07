using System.ComponentModel.DataAnnotations;

namespace Senegocia.WebApi.Services.Indicator
{
    public sealed class GetIndicatorRequest
    {
        [Required]
        [ValidIndicatorType("IndicatorType is invalid")]
        public string IndicatorType { get; set; }

        [Required]
        [ValidDateFormat("dd-MM-yyyy", "Date has not a valid format")]
        public string Date { get; set; }
    }
}