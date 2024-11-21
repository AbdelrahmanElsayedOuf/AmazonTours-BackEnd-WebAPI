using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Utilities;
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

        public async Task<BoolWithString> Register(CreateUserDTO userDTO)
        {
            var registerResponse = new BoolWithString();

            var user = new IdentityUser()
            {
                Email = userDTO.Email,
                UserName = userDTO.Email
            };

            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if(result.Succeeded)
            {
                registerResponse.IsSuccess = true;
                registerResponse.StrBuildMessage = new StringBuilder("User Created Successfully!");
            }
            else
            {
                registerResponse.IsSuccess = false;
                foreach (var error in result.Errors)
                {
                    registerResponse.StrBuildMessage.Append($"{error.Description}, ");
                }
            }
            return registerResponse;
        }
    }
}
