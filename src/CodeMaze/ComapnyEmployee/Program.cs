using ComapnyEmployee.Entension;
using ComapnyEmployee.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

//Register Entension method
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

Log.Write(LogEventLevel.Debug, "Application start");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

//Custom Exception Middleware 
//app.ConfigureExceptionHandler(new LoggerManager()); //Handling error globaly with built in middlewar.
app.UseMiddleware<ErrorHandleMiddleWare>();  //using request delegate

app.Run();
