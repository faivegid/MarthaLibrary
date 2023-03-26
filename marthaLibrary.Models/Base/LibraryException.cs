using FluentValidation.Results;
using System.Net;

namespace marthaLibrary.Models.Base
{
    public class LibraryException : Exception
    {
        private Dictionary<string, string> errorResult = new Dictionary<string, string>();
        public Dictionary<string, string> ErrorDictionary => errorResult ??= new Dictionary<string, string>();
        public HttpStatusCode ErrorStatus { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }

        public LibraryException(
            string message,
            HttpStatusCode status) : base(message)
        {
            ErrorStatus = status;
            errorResult.Add("", message);
        }

        public LibraryException(
            string message,
            HttpResponseMessage responseMessage) : base(message)
        {
            ResponseMessage = responseMessage;
            ErrorStatus = responseMessage.StatusCode;
            errorResult.Add("", message);
        }

        public LibraryException(
            Dictionary<string, string> errors, string message,
            HttpStatusCode status = HttpStatusCode.BadRequest)
            : base(message ?? "One or more errors occurred")
        {
            if (errors == null)
                throw new ArgumentException("Errors can't be null");
            errorResult = errors;
        }

        public LibraryException(
            IList<ValidationFailure> errors,
            string msg = "An invalid field(s) exist in your request",
            HttpStatusCode errorStatus = HttpStatusCode.BadRequest)
            : base(msg)
        {
            foreach (var error in errors)
            {
                if (errorResult.ContainsKey(error.PropertyName))
                    continue;
                errorResult.Add(error.PropertyName, error.ErrorMessage);
            }
            ErrorStatus = errorStatus;
        }
    }
}
