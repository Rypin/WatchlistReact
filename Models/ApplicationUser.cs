using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WatchlistReact.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  ICollection<Followers> Followers { get; set; }
        public  ICollection<Followers> FollowedAccounts { get; set; }
    }

}