using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using NotesApp.API.Models;
using SeedWork.Application.Exceptions;
using SeedWork.Domain.Exceptions;
using System.Net;

namespace NotesApp.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            if (ex is AttributeNotValidException attributeNotValidException)
            {
                await this.Handle(httpContext, attributeNotValidException);
            }
            else if(ex is AuthenticationException authenticationException)
            {
                await this.Handle(httpContext, authenticationException);
            }
            else if(ex is UnauthorizedException unauthorizedException)
            {
                await this.Handle(httpContext, unauthorizedException);
            }
            else if(ex is ItemNotFoundException itemNotFoundException)
            {
                await this.Handle(httpContext, itemNotFoundException);
            }
            else if(ex is WrongAttemptException wrongAttemptException)
            {
                await this.Handle(httpContext, wrongAttemptException);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var error = new ErrorModel
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Detail = "ops something went wrong"
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
        // Domain Layer Exceptions (403 bad request)
        private async Task Handle(HttpContext httpContext, AttributeNotValidException exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var error = new ErrorModel
            {
                Code = (int)HttpStatusCode.BadRequest,
                Detail = exception.Message
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
        //Application Layer Exceptions
        private async Task Handle(HttpContext httpContext, AuthenticationException exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var error = new ErrorModel
            {
                Code = (int)HttpStatusCode.Unauthorized,
                Detail = exception.Message
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
        private async Task Handle(HttpContext httpContext, UnauthorizedException exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var error = new ErrorModel
            {
                Code = (int)HttpStatusCode.Unauthorized,
                Detail = exception.Message
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
        private async Task Handle(HttpContext httpContext, ItemNotFoundException exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            var error = new ErrorModel
            {
                Code = (int)HttpStatusCode.NotFound,
                Detail = exception.Message
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
        private async Task Handle(HttpContext httpContext, WrongAttemptException exception)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var error = new ErrorModel
            {
                Code = (int)HttpStatusCode.BadRequest,
                Detail = exception.Message
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }
}
