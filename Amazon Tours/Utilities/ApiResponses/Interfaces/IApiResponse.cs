using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses.Interfaces
{
    public interface IApiResponse<T>
    {
        public bool Success { get; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
