using Application.Common.Interfaces;
using System.Net.Mime;
using System.Net;
using System.Text.Json;

namespace couriernowapi.Middleware
{
    public class ApplicationErrorLogs : IMiddleware
    {
        private readonly IApplicationDBContext _applicationDBContext;
        public ApplicationErrorLogs(IApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await context.Response.WriteAsync("Hellow from Custom Middleware");
                await next(context);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                await HandleCustomExceptionResponseAsync(context, ex);
            }
            
        }

        private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ErrorModel(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
