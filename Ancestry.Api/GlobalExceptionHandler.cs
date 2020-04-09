using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ancestry.Common.Dtos;
using Ancestry.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ancestry.Api
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IJsonService _jsonService;
        public GlobalExceptionHandler(RequestDelegate next, IJsonService jsonService)
        {
            _next = next;
            _jsonService = jsonService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                //log
                await HandleException(e, context);
            }
        }

        private Task HandleException(Exception exception, HttpContext context)
        {
            var payload = _jsonService.SerializeObject<ErrorResponseDto>(new ErrorResponseDto
            {
                Error = "we are sorry. An error occured due to an unexpected turn of events. :D "
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(payload);
        }
    }
}

