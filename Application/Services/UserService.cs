using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Utilities.HelperClasses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthModel> Register(CreateUserDTO userDTO)
        {
            if(await _userManager.FindByEmailAsync(userDTO.Email) is not null)
            {
                return new AuthModel { Email = userDTO.Email, Message = "Email already exists!" };
            }

            if (await _userManager.FindByNameAsync(userDTO.UserName) is not null)
            {
                return new AuthModel { UserName = userDTO.UserName, Message = "UserName  already exists!" };
            }


            var user = new IdentityUser()
            {
                Email = userDTO.Email,
                UserName = userDTO.Email
            };

            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                var jwt = await _userManager.CreateSecurityTokenAsync(user);

                return new AuthModel()
                {
                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    IsAuthenticated = true,
                    Message = "Registered Successfully!",
                    Roles = "User",
                    Token = jwt.ToString(),
                };
            }
            else
            {
                var errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errors.Append($"{error.Description}, ");
                }

                return new AuthModel()
                {
                    Message = errors.ToString(),
                };
            }
        }
    }
}
