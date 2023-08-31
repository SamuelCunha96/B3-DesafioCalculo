﻿using Microsoft.AspNetCore.Http;
using System.Net;
using FluentValidation;
using B3.DesafioCalculo.Shared.DTO;
using B3.DesafioCalculo.Shared.Extensions;

namespace B3.DesafioCalculo.Shared.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public GlobalExceptionHandlerMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            IEnumerable<string> mensagensErro = null;

            switch (exception)
            {
                case ValidationException ex:
                    mensagensErro = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).AsEnumerable();
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    context.Response.StatusCode = (int)statusCode;

                    mensagensErro = new List<string> { exception.InnerException?.Message ?? exception.Message };
                    break;
            }

            return context.Response.WriteAsync(new BaseResponseDTO<object>(null!, false, (int)statusCode, mensagensErro).ToJsonIgnoringNullValues());
        }
    }
}
