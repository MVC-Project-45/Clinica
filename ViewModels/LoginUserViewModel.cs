<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
      
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me !!")]
        public bool RememberMe { get; set; }
    }
}
<<<<<<< HEAD
=======
=======
﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Final.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
      
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me !!")]
        public bool RememberMe { get; set; }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
