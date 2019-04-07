using System.ComponentModel.DataAnnotations;

using Senegocia.WebApi.Services.Integration.Indicators;

namespace Senegocia.WebApi
{
    public class ValidIndicatorTypeAttribute : ValidationAttribute
    {
        public ValidIndicatorTypeAttribute(string msg) : base(msg)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IndicatorTypes.IsValidType(value.ToString()))
            {
                return new ValidationResult(this.ErrorMessage);

            }

            return ValidationResult.Success;
        }
    }
}
