<<<<<<< HEAD
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
