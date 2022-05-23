using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Validations
{
    public class PrezzoMaggioreDi0Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double prezzo = (double)value;
            if (prezzo <= 0)
            {
                return new ValidationResult("Il prezzo deve essere maggiore di 0");
            }
            return ValidationResult.Success;
        }
    }
}
