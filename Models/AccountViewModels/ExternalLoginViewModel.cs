using System.ComponentModel.DataAnnotations;

namespace AngularERPApi.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
