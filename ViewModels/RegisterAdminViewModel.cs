<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class RegisterAdminViewModel
    {
        public string UserName { get; set; }

        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
=======
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class RegisterAdminViewModel
    {
        public string UserName { get; set; }

        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
