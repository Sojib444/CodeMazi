using ComapnyEmployee.Entension;
using ComapnyEmployee.Extension;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Serilog Configure
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// This Project AssemblyName
var assemblyName = Assembly.GetExecutingAssembly().FullName;

//Database Configuraton
builder.Services.AddDbContext<RepositoryContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
assembly => assembly.MigrationsAssembly(assemblyName)));

//Register Extension method
builder.Services.RepositoryConfiguration();
builder.Services.ServiceConfiguration();
builder.Services.LoggerConfiguration();

//CQRS configuration
builder.Services.ConfigureCQRS();

//controller Assembly reference
builder.Services.AddControllers()
.AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

//Add Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.ConfigureExceptionHandler(new LoggerManager());

Log.Write(LogEventLevel.Debug, "Application start");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

//Custom Exception Middleware 
 //Handling error globaly with built in middlewar

app.Run();
