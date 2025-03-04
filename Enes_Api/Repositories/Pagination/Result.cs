using System.Net;

namespace Enes_Api.Repositories.Pagination
{
    public class Result : IResult
    {
        public Result(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        public Result(HttpStatusCode statusCode, string message) : this(statusCode)
        {
            Message = message;
        }

        public int StatusCode { get; }
        public string Message { get; set; }
    }
}
