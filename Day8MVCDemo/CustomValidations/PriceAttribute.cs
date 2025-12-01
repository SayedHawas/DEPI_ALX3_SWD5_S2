using System.ComponentModel.DataAnnotations;

namespace Day8MVCDemo.CustomValidations
{
    public static class PriceAttribute
    {
        public static string ErrorMessage { get; set; } = "Price must be at greater than 5000.";
        public static ValidationResult ValidatePrice(decimal price, ValidationContext context)
        {
            if (price < 5000)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}
