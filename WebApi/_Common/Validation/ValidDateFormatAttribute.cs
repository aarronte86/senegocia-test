using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Senegocia.WebApi
{
    public class ValidDateFormatAttribute : ValidationAttribute
    {
        private readonly string _dateFormat;

        public ValidDateFormatAttribute(string format, string msg) : base(msg)
        {
            this._dateFormat = format;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime theDateTime;

            if (!DateTime.TryParseExact(value.ToString(), this._dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out theDateTime))
            {
                return new ValidationResult(this.ErrorMessage);

            }

            return ValidationResult.Success;
        }
    }
}
