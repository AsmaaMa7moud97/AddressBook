using Microsoft.AspNetCore.Identity;

namespace AddressBook.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {       
        public string Token { get; set; }
    }
}