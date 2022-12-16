using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookReservationSystem.Domain.Validators;

public class After: ValidationAttribute
{
    private string OtherProperty { get; }

    public After(string otherProperty)
    {
        OtherProperty = otherProperty ?? throw new ArgumentNullException(nameof(otherProperty));
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult($"Unknown property {OtherProperty}");
        }
        if (otherPropertyInfo.GetIndexParameters().Length > 0)
        {
            throw new ArgumentException($"Property not found {OtherProperty}");
        }
        var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

        var dateTime = Convert.ToDateTime(value);
        var otherDateTime = Convert.ToDateTime(otherValue);        
        
        return dateTime > otherDateTime 
            ? ValidationResult.Success 
            : new ValidationResult($"{validationContext.DisplayName} must be after {GetDisplayNameForProperty(otherPropertyInfo)}");
    }
    
    private string? GetDisplayNameForProperty(MemberInfo property)
    {
        var attributes = CustomAttributeExtensions.GetCustomAttributes(property, true);
        foreach (var attribute in attributes)
        {
            if (attribute is DisplayAttribute display)
            {
                return display.GetName();
            }
        }

        return OtherProperty;
    }
}