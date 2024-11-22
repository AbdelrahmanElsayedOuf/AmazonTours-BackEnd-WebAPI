using Amazon_Tours.Utilities.ApiResponses.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        public IActionResult OkResponse<T>(T data, string message = null)
        {
            return Ok(ApiResponseFactory<T>.SuccessResponse(data, message));
        }

        public IActionResult BadRequest<T>(T data, string message = null)
        {
            return BadRequest(ApiResponseFactory<T>.FailureResponse(message));
        }

        public IActionResult ErrorResponse<T>(T data, string message = null)
        {
            return StatusCode(500, ApiResponseFactory<T>.ErrorResponse(message));
        }
    }
}
