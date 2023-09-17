using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Infrastructure.Models.InputModels
{
    public class RegisterModel
    {

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}