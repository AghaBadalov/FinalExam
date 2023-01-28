using Microsoft.AspNetCore.Identity;

namespace Medicio.Models
{
    public class AppUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
