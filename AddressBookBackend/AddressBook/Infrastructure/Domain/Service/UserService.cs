using AddressBook.Helpers;
using AddressBook.Infrastructure.Models;
using AddressBook.Infrastructure.Models.InputModels;
using AddressBook.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSetting;        
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public UserService(IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _appSetting = appSettings.Value;
            _userManager = userManager;
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<ApplicationUser> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            // return null if user not found
            if (user == null)
                return null;
            if (await _userManager.CheckPasswordAsync(user, password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim (ClaimTypes.Name,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;
            }
            return null;
        }


        
        public async Task<string> Register(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            return user.Id;
        }
       
    }
}