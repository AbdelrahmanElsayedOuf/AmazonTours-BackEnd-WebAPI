﻿using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<BoolWithString> Register(CreateUserDTO userDTO);
    }
}
