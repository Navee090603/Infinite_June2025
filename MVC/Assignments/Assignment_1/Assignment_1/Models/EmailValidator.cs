using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assignment_1.Models
{
    public class EmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;

            var db = new ContactContext();
            if (db.Contacts.Any(c => c.Email == email))
                return new ValidationResult("Email already exists.");

            return ValidationResult.Success;
        }
    }
}
