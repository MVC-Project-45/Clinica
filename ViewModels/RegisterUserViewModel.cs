<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using MVC_Final.Models;

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
<<<<<<< HEAD
=======
=======
﻿using MVC_Final.Models;

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
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
