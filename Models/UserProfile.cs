using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("UserProfile", Schema = "dbo")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Profile")]
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public string ProfilePicture { get; set; } = "/upload/blank-person.png";

        public string ApplicationUserId { get; set; }


        public  bool? DelFlage { get; set; } = false;
    }
}
