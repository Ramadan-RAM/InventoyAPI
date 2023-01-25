using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            PublicMessage = new HashSet<PublicMessage>();
            PrivateMessage = new HashSet<PrivateMessage>();
        }

        // 1 -* AppUser || Messages

        public virtual ICollection<PublicMessage> PublicMessage { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessage { get; set; }
    }
}
