using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Factory
{
    public static class ApiResponseFactory<T>
    {
        public static IApiResponse<T> SuccessResponse(T data, string message)
        {
            return new SuccessResponse<T>() { Data = data, Message = message ?? "Successfull Request!" };
        }

        public static IApiResponse<T> FailureResponse(string message)
        {
            return new FailureResponse<T>() { Message = message ??  "Bad Request From Client Side" };
        }

        public static IApiResponse<T> ErrorResponse(string message)
        {
            return new ErrorResponse<T>() { Message = message ??  "An Error Occurred" };
        }
    }
}
