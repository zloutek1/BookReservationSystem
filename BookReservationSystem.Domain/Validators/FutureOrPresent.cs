using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain.Validators;

public class FutureOrPresent: ValidationAttribute
{
    private const string DefaultErrorMessage = "Date must be now or in the future";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dateTime = Convert.ToDateTime(value);
        return dateTime >= DateTime.Now 
            ? ValidationResult.Success 
            : new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
    }
}