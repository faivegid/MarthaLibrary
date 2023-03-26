using marthaLibrary.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;

namespace marthaLibrary.Config.Middlewares
{
    public class ApiKeyMiddleware : IMiddleware
    {
        private readonly IConfiguration _config;

        public ApiKeyMiddleware(IConfiguration config)
        {
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var apiKey = _config.GetSection("X-Api-Key").Get<string>();
            var isGuid = Guid.TryParse(apiKey, out var keyId);

            var requestApiKey = context.Request.Headers["X-Api-Key"].ToString();

            if (requestApiKey != apiKey || !isGuid)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var response = ApiResponse.Error("Invalid Api Key", HttpStatusCode.Unauthorized);

                // Serialize the response data to JSON format
                var json = JsonConvert.SerializeObject(response);

                // Write the serialized JSON data to the response body
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);

                return;
            }

            await next(context);
        }
    }
}
