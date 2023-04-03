using Autofac;
using Autofac.Extensions.DependencyInjection;
using CodeMaze.Extension_Method;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddCorsConfiguration();
builder.Services.AddRepositoryAndUnitofWork(builder.Configuration);
builder.Services.AddIISservice();

builder.Services.AddControllers()
.AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

builder.Services.AddLoggingServce();

//Autofac Configure
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new WebModule());
    containerBuilder.RegisterModule(new InfrastructureModule(connectionString, assemblyName));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Cors");

app.Run();
