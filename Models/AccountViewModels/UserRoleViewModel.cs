

namespace AngularERPApi.Models.AccountViewModels
{
    public class UserRoleViewModel
    {
        public static string Admin = "Admin";

        public static string User = "User";

        public int CounterId { get; set; }
        public string ApplicationUserId { get; set; }
        public string RoleName { get; set; }
        public bool IsHaveAccess { get; set; }
    }
}
