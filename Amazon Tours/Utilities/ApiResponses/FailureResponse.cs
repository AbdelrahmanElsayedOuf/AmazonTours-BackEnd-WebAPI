﻿using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using System.Net;

namespace Amazon_Tours.Utilities.ApiResponses
{
    public class FailureResponse<T> : IApiResponse<T>
    {
        public bool Success { get; set; } = false;
        public T Data { get; set; } = default(T);
        public string Message { get; set; }
    }
}
