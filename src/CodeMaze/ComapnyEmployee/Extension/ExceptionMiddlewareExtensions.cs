using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ComapnyEmployee.Extension
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager loggerManager)
        {
            /// <summary>
            //adds a middlewaer that will catch the exception and log them and
            //re-execute the the request in alternate pipeline 
            /// <summary>
            app.UseExceptionHandler(buider => buider.Run(
                    async contex =>
                    {
                        contex.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        contex.Response.ContentType = "application/json";

                        var contextFeature = contex.Features.Get<IExceptionHandlerFeature>();

                        if(contex != null)
                        {
                            loggerManager.LogError($"Somethings went wrong {contextFeature.Error}");

                            await contex.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = contex.Response.StatusCode,
                                Message = "Internal Server Error"
                            }.ToString());
                        }
                    }
                ));                
        }
    }
}
