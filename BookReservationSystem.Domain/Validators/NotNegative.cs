using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookReservationSystem.Domain.Validators;

public class NotNegative: ValidationAttribute
{
    private const string DefaultErrorMessage = "Number must not be negative";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var number = Convert.ToInt32(value);
        return number >= 0 
            ? ValidationResult.Success 
            : new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
    }
}