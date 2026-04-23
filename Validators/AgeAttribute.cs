using System.ComponentModel.DataAnnotations;

namespace LoveCalculatorApp.Validators
{
    public class AgeAttribute : ValidationAttribute
    {
        private readonly int _lower;
        private readonly int _upper;

        public AgeAttribute(int lower = 0, int upper = int.MaxValue)
        {
            _lower = lower;
            _upper = upper;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"Age should be between {_lower} and {_upper}");
            }

            int age = (int)value;

            if (age < _lower || age > _upper)
            {
                return new ValidationResult($"Age should be between {_lower} and {_upper}");
            }

            return ValidationResult.Success;
        }
    }
}