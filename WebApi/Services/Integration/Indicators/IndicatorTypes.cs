namespace Senegocia.WebApi.Services.Integration.Indicators
{
    // TODO: Add the rest of types available
    public static class IndicatorTypes
    {
        public const string UF = "uf";
        public const string Dolar = "dolar";
        public const string Euro = "euro";

        public static bool IsValidType(string type)
        {
            if (
                type == UF 
                || type == Dolar 
                || type == Euro)
            {
                return true;
            }

            return false;
        }
    }
}