using System;
using System.Net;

namespace GitHubRepos.Utilities
{
    public class HttpRequestExceptionEx : Exception
    {
        public HttpStatusCode HttpCode { get; }

        public HttpRequestExceptionEx(HttpStatusCode httpCode, string message, Exception? innerException = null) : base(
            message, innerException)
        {
            HttpCode = httpCode;
        }
    }
}
