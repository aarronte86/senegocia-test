using System.Collections.Generic;

namespace Senegocia.WebApi.Services.Integration.Indicators
{
    public class IndicatorValueDTO
    {
        public string Date { get; set; }

        public double Value { get; set; }
    }

    public class IndicatorDTO
    {
        public string Version { get; set; }

        public string Author { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string MeasurementUnit { get; set; }

        public List<IndicatorValueDTO> Serie { get; set; }
    }
}
