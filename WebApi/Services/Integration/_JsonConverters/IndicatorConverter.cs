using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Senegocia.WebApi.Services.Integration.Indicators;

namespace Senegocia.WebApi.Services.Integration
{
    //TODO: Implements base generic abstract class for all custom converters which will encapsulate all common logic
    public sealed class IndicatorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IndicatorDTO).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            IndicatorDTO dto = existingValue as IndicatorDTO ?? new IndicatorDTO();

            dto.Version = (string)jsonObject["version"];
            dto.Author = (string)jsonObject["autor"];
            dto.Name = (string)jsonObject["nombre"];
            dto.Code = (string)jsonObject["codigo"];
            dto.MeasurementUnit = (string)jsonObject["unidad_medida"];

            IList<JToken> serieArray = jsonObject["serie"].Children().ToList();
            dto.Serie = serieArray.Select(
                value => JsonConvert.DeserializeObject<IndicatorValueDTO>(value.ToString(), new IndicatorValueConverter())
            ).ToList();

            return dto;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }        
    }

    public sealed class IndicatorValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IndicatorValueDTO).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            IndicatorValueDTO dto = existingValue as IndicatorValueDTO ?? new IndicatorValueDTO();

            dto.Value = (double)jsonObject["valor"];
            dto.Date = (string)jsonObject["fecha"];

            return dto;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
