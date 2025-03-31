using System.Net;

namespace api.Helpers
{
    public class Result<TValue>
    {
        //Error Message i.e "There was a problem processing your request"
        public string Error { get; protected set; } = "";

        //Success Message i.e "You have successfully ...."
        public string Message { get; protected set; } = "";

        // BadRequest || NotFound || InternalServerError
        public HttpStatusCode StatusCode { get; protected set; }

        //Error Details
        public string Meta { get; protected set; } = "";

        //Object to return as a success
        public TValue? Value { get; protected set; }

        public static Result<TValue> Success(HttpStatusCode statuscode, TValue value, string message) => new()
        {
            StatusCode = statuscode,
            Value = value,
            Message = message
        };

        public static Result<TValue> Failed(HttpStatusCode statusCode, string error, string meta, string message) => new()
        {
            StatusCode = statusCode,
            Error = error,
            Meta = meta,
            Message = message
        };
    }
}
