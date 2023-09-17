using AddressBook.Infrastructure.Models;
using AddressBook.Infrastructure.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AddressBook.Service
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string username, string password);
        Task<string> Register(RegisterModel registerModel);
     

    }
}