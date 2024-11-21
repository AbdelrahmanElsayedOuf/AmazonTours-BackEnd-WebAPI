using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using AmazonTours.Application.DTOs.CreateDTOs;
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateUserDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                var validationErrors = String.Join("; ", ModelState.Values
                    .SelectMany(val => val.Errors).Select(err => err.ErrorMessage));
                return BadRequest(ApiResponseFactory<string>.FailureResponse(null, System.Net.HttpStatusCode.BadRequest, validationErrors));
            }
            var result = await _userService.Register(userDTO);
            if(result.IsSuccess)
            {
                return Ok(ApiResponseFactory<string>.SuccessResponse(null, System.Net.HttpStatusCode.Created, result.StrBuildMessage.ToString()));
            }
            return BadRequest(ApiResponseFactory<string>.FailureResponse(null, System.Net.HttpStatusCode.BadRequest, result.StrBuildMessage.ToString()));
        }
    }
}
