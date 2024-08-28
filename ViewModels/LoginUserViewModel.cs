using System.ComponentModel.DataAnnotations;

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
