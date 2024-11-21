using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Factory
{
    public static class ApiResponseFactory<T>
    {
        public static IApiResponse<T> SuccessResponse(T data, HttpStatusCode code, string message)
        {
            return new SuccessResponse<T>() { Data = data, StatusCode = code, Message = message};
        }

        public static IApiResponse<T> FailureResponse(T data, HttpStatusCode code, string message)
        {
            return new FailureResponse<T>() { Data = data, StatusCode = code, Message = message };
        }
    }
}
