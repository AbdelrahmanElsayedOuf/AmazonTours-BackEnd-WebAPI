using Amazon_Tours.Utilities.ApiResponses.Factory;
using Amazon_Tours.Utilities.HelperClasses;
using AmazonTours.Application.Interfaces.Services.Base;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;
using System.Net;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController<T> : ControllerBase where T : class, IEntity, new()
    {
        private readonly IBaseService<T> _baseService;

        public AppBaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        public IActionResult OkResponse<T>(T data, string message = null)
        {
            return Ok(ApiResponseFactory<T>.SuccessResponse(data, message));
        }

        public IActionResult BadRequestResponse<T>(string message = null)
        {
            return BadRequest(ApiResponseFactory<T>.FailureResponse(message));
        }

        public IActionResult NotFoundResponse<T>(string message = null)
        {
            return NotFound(ApiResponseFactory<T>.NotFoundResponse(message));
        }

        public IActionResult ErrorResponse<T>(T data, string message = null)
        {
            return StatusCode(500, ApiResponseFactory<T>.ErrorResponse(message));
        }


        protected async Task<EntityExistence> CheckExistedId(Guid id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            return new EntityExistence()
            {
                Entity = entity,
                IsExisted = entity != null
            };
        }

        protected IActionResult InValidModelState()
        {
            var stringifiedError = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequestResponse<T>(stringifiedError);
        }
    }
}
