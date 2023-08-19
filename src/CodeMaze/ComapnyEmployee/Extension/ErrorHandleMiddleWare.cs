using Entities.ErrorModel;
using System.Net;

namespace ComapnyEmployee.Extension
{
    public class ErrorHandleMiddleWare
    {
        private readonly RequestDelegate requestDelegate;
        public ErrorHandleMiddleWare(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch(Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";


                switch(ex)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                       break;

                    case AppException e:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;

                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(new ErrorDetails()
                {
                    Message = ex.Message,
                    StatusCode = response.StatusCode
                 }.ToString());
            }
        }
    }
}
