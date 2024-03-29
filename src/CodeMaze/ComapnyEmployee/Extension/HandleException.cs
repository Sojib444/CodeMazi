﻿using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ComapnyEmployee.Extension
{
    public static class HandleException
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager loggerManager)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async contex =>
                {
                    contex.Response.ContentType = "application/json";

                    var contexFeature = contex.Features.Get<IExceptionHandlerFeature>();

                    if (contexFeature != null)
                    {
                        var error = contexFeature.Error;

                        switch (error)
                        {
                            case NotFoundException foundException:
                                contex.Response.StatusCode = StatusCodes.Status404NotFound;
                                break;

                            case BadRequestException badRequestException:
                                contex.Response.StatusCode = StatusCodes.Status404NotFound;
                                break;

                            default:
                                contex.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                break;

                        }

                        loggerManager.LogError($"Something went wrong at {contexFeature.Error.Message}");

                        await contex.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = contex.Response.StatusCode,
                            Message = contexFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
