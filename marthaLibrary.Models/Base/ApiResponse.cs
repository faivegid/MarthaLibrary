using System.Net;

namespace marthaLibrary.Models.Base
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Status { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(T data) : this()
        {
            Data = data;
            StatusCode = HttpStatusCode.OK;
            Status = ResultState.Success;
        }
    }

    public static class ApiResponse
    {
        public static ApiResponse<TData> Success<TData>(TData data,
            string message = "Request was processed successfully")
        {
            return new ApiResponse<TData>()
            {
                Data = data,
                Message = message,
                StatusCode = HttpStatusCode.OK,
                Status = ResultState.Success
            };
        }

        public static ApiResponse<object> Ok()
        {
            return new ApiResponse<object>()
            {
                Status = ResultState.Success,
                StatusCode = HttpStatusCode.NoContent
            };
        }

        public static ApiResponse<object> Error(string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<object>
            {
                Status = ResultState.Failed,
                StatusCode = status,
                Message = message
            };
        }

        public static ApiResponse<object> Error(Dictionary<string, string> errors,
            string message = "one or more validation errors occurred", HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<object>
            {
                Data = errors,
                Message = message,
                Status = ResultState.Failed,
                StatusCode = status
            };
        }
    }
}
