using Microsoft.AspNetCore.Identity;

namespace AspNetCoreWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Nome { get; set; }
    }
}
