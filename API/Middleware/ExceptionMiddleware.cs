using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Net;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate  _next;
        private readonly  ILogger<ExceptionMiddleware>  _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            //_logger = logger?.CreateLogger<ExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(logger));
            //_next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context){

            try{
                await _next(context);
            }
            catch(Exception ex){

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/jason";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() 
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");


               var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

               var json = JsonSerializer.Serialize(response, options);

               await context.Response.WriteAsync(json);     

            }

        }
    }
}