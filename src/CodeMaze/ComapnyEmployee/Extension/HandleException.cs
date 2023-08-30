using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

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
                    contex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    contex.Response.ContentType = "application/json";

                    var contexFeature = contex.Features.Get<IExceptionHandlerFeature>();

                    if(contexFeature != null)
                    {
                        loggerManager.LogError($"Something went wrong at {contexFeature.Error}");

                        await contex.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = contex.Response.StatusCode,
                            Message = "Internal Servr Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
