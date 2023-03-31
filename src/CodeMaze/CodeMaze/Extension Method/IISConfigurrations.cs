namespace CodeMaze.Extension_Method
{
    public static class IISConfigurrations
    {
        public static void AddIISservice(this IServiceCollection services)
        {
             services.Configure<IISOptions>(option =>
            {

            });
        }
    }
}
