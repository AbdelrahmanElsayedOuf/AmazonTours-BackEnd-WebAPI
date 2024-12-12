using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.Utilities.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<AuthModel> Register(CreateUserDTO userDTO);
    }
}
