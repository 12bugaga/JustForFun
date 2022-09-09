using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using Test.Models;
using Test.Infrastructure.DataModels.Common;
using Test.Infrastructure.Context;

namespace Test.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DatabaseContext _memory;

        public ExceptionMiddleware(RequestDelegate next, DatabaseContext memory)
        {
            _next = next;
            _memory = memory;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await _memory.ExceptionLogs.AddAsync(new ExceptionLog()
            {
                Title = exception.Message,
                StackTrace = exception.StackTrace,
            });

            await _memory.SaveChangesAsync();

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Something went wrong, please contact DevTeam"
            }.ToString());
        }
    }
}
