using System.ComponentModel.DataAnnotations;

namespace Day8MVCDemo.CustomValidations
{
    public class IsExistAttribute : ValidationAttribute //Attribute
    {
        public string ErrorMessage { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Value 
            string currentName = value.ToString();
            //Check Db 
            AppDbContext _db = (AppDbContext)validationContext.GetService(typeof(AppDbContext));   //new AppDbContext();
            var product = _db.Products.FirstOrDefault(p => p.Name == currentName);
            if (product != null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
