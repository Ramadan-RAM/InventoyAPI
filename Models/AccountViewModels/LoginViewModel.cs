using System.ComponentModel.DataAnnotations;

namespace AngularERPApi.Models.AccountViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
