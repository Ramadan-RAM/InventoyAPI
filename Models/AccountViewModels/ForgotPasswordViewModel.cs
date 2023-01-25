using System.ComponentModel.DataAnnotations;

namespace AngularERPApi.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
