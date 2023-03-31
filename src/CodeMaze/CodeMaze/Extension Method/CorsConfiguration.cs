namespace CodeMaze.Extension_Method
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(option => 
                option.AddPolicy("Cors",builder => 
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            ));
        }
    }
}
