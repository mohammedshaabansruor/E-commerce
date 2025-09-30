using Domain.Exceptions;
using Org.BouncyCastle.Security;
using Shared.ErrorModels;
using System.Net;

namespace WebApplication1.Middelware
{
    public class GlobaleEroorHandlingMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobaleEroorHandlingMiddlware> _logger;

        public GlobaleEroorHandlingMiddlware(RequestDelegate next, ILogger<GlobaleEroorHandlingMiddlware> logger)
        {
            _next = next;
            _logger = logger;
        }
        // response {statuscode , erromsg}
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                    await HandleNotFoundAsync(httpContext);
            }
            catch (Exception ex) 
            {
                // log exception
                _logger.LogError($"something went wrong : {ex}");
                // handle exception 
                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleNotFoundAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            var response = new ErrorDetails
            {
                StatusCode = (int) HttpStatusCode.NotFound,
                ErrorMessages = $" the end point {httpContext.Request.Path}not found"
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            // set context type [application/json]
            // set status code to 500 
            // return standared response
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500 
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,//404 
                _ => (int)HttpStatusCode.InternalServerError
            };
            var response = new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessages = ex.Message
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }

    }
}
