using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Validations
{
    public class GiorniMaggioreDi0Validation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int giorniDiViaggio = (int)value;
            if (giorniDiViaggio <= 0)
            {
                return new ValidationResult("I giorni di viaggio devono essere maggiore di 0");
            }
            return ValidationResult.Success;
        }
    }
}
