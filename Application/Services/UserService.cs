using AmazonTours.Application.DTOs.AuthDTOs;
using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.ReadDTOs;
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

        public async Task<RegisterResponse> Register(CreateUserDTO userDTO)
        {
            if (await _userManager.FindByEmailAsync(userDTO.Email) is not null)
            {
                return new RegisterResponse { IsSuccess = false, Message = "Email already exists!" };
            }

            if (await _userManager.FindByNameAsync(userDTO.UserName) is not null)
            {
                return new RegisterResponse { IsSuccess = false, Message = "UserName  already exists!" };
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
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //TO DO: Send code in an email

                return new RegisterResponse()
                {
                    IsSuccess = true,
                    Message = $"Confirm Email code:{code}"
                };
            }
            else
            {
                var errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errors.Append($"{error.Description}, ");
                }

                return new RegisterResponse()
                {
                    IsSuccess = false,
                    Message = errors.ToString(),
                };
            }
        }

        public async Task<RegisterResponse> ConfirmEmail(ConfirmEmail confirmEmailDto)
        {
            var user = await _userManager.FindByEmailAsync(confirmEmailDto.Email);
            if (user != null)
            {
                var isConfirmed = await _userManager.ConfirmEmailAsync(user, confirmEmailDto.Code);
                if(isConfirmed.Succeeded)
                {
                    return new RegisterResponse()
                    {
                        IsSuccess = true,
                        Message = "Email Confirmed Successfully!"
                    };
                }

                return new RegisterResponse()
                {
                    IsSuccess = false,
                    Message = "Error occurred in email confirmation!"
                };
            }

            return new RegisterResponse()
            {
                IsSuccess = false,
                Message = "User Not Found!"
            };
        }

        public async Task<AuthModel> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
                var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                if (isEmailConfirmed)
                {
                    var jwt = await _userManager.GenerateUserTokenAsync(user, "Default", "CustomPurpose");
                    return new AuthModel()
                    {
                        Email = loginDTO.Email,
                        IsAuthenticated = true,
                        Message = "Login Successfully!",
                        Token = jwt,
                    };
                }

                return new AuthModel()
                {
                    Email = loginDTO.Email,
                    IsAuthenticated = false,
                    Message = "Email Not Confirmed!",
                };
            }

            return new AuthModel()
            {
                Email = loginDTO.Email,
                IsAuthenticated = false,
                Message = "User Not Found!",
            };
        }
    }
}
