using MVC_Final.Models;

using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class RegisterUserViewModel
    {
        [UniqueEmail]
        public string Email { get; set; }
        public string UserName { get; set; }

        public int age { get; set; }

        public Gender Gender { get; set; }

        public string? Address { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

       

    }
}
