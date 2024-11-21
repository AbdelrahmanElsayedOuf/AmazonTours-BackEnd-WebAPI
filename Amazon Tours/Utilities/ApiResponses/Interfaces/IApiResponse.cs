using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Interfaces
{
    public interface IApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
