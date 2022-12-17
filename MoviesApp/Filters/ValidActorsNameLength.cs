using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters;

public class ValidActorsNameLength : ValidationAttribute
{
    private int nameLength { get; }

    public ValidActorsNameLength(int length)
    {
        nameLength = length;
    }

    public string GetErrorMessageCausedByNameLength() =>
        $"Length must be more then 4 and less than 99. Introduced nam length is {nameLength} .";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string)
        {
            var len = ((string)value).Length;

            if (len < nameLength)
            {
                return new ValidationResult(GetErrorMessageCausedByNameLength());
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Unsupported type");
    }
}