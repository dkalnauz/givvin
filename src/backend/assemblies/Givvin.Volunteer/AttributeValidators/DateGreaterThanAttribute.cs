using System.ComponentModel.DataAnnotations;

namespace Givvin.Volunteer.AttributeValidators
{
    /// <summary>
    /// Represents a custom validation attribute for date comparison.
    /// </summary>
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}.");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (!(value is DateTime) || !(comparisonValue is DateTime))
            {
                return new ValidationResult("The property types must be DateTime.");
            }

            if ((DateTime)value <= (DateTime)comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
