using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using System.Text.Json;

namespace RahmanyCourses.Persentation.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                ProblemDetails details = new ProblemDetails 
                {
                    Status = (int) HttpStatusCode.InternalServerError,
                    Type = "server error",
                    Title = "Server Error",
                    Detail = $"An intrenal server error has occurred, {ex.Message}"
                };

                string json = JsonSerializer.Serialize(details);

                context.Response.ContentType = "application/json";
                
                await context.Response.WriteAsync(json);

            }
        }
    }
}
