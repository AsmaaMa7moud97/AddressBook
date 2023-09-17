using System.ComponentModel.DataAnnotations;

namespace AddressBook.Infrastructure.Models.InputModels
{
    public class AuthenticateModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}