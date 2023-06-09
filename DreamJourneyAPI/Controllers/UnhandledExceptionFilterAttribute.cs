﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DreamJourneyAPI.Controllers
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;

        public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            // Customize this object to fit your needs
            var result = new ObjectResult(new
            {
                context.Exception.Message, // Or a different generic message
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().FullName,
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Log the exception
            _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);

            // Set the result
            context.Result = result;
        }
    }
}
