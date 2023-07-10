namespace ComapnyEmployee.Entension
{
    public static  class ServiceExtension
    {
        public static void ConfigureCQRS(this IServiceCollection service)
        {
            service.AddCors(action => action.AddPolicy("poliicy", builder =>
                                   builder.AllowAnyOrigin().
                                   AllowAnyHeader()));
        }

        public static void ConfigureCQRS1(this IServiceCollection service)
        {
            service.AddCors(action => action.AddPolicy("poliicy", builder =>
                                   builder.AllowAnyOrigin().
                                   AllowAnyHeader()));
        }

    }
}
