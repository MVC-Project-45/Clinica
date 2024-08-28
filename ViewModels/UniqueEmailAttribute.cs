using Microsoft.AspNetCore.Identity;
using MVC_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class UniqueEmailAttribute : ValidationAttribute

    {

       

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var dbContext = (Context)validationContext.GetService(typeof(Context));


            if (!IsEmailUnique((string)value, dbContext))
            {
                return new ValidationResult("Email is already in use.");
            }

            return ValidationResult.Success;
        }
        private bool IsEmailUnique(string email,Context context)
        {


            return !context.Users.Any(u => u.Email == email);
        }
    }
}
