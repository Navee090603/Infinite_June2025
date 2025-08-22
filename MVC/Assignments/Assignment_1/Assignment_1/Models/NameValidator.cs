using System.ComponentModel.DataAnnotations;
using System.Linq;
using Assignment_1.Models;

public class NameValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var name = value as string;

        var db = new ContactContext();
        if (db.Contacts.Any(c => c.FirstName == name))
            return new ValidationResult("Name already exists.");

        return ValidationResult.Success;
    }
}