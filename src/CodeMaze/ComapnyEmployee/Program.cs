using ComapnyEmployee.Entension;
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

// AccesAssembly 
var assemblyName = Assembly.GetExecutingAssembly().FullName;

//Database Configuraton
builder.Services.AddDbContext<RepositoryContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
assembly => assembly.MigrationsAssembly(assemblyName)));

//Register Dependency
builder.Services.RepositoryConfiguration();
builder.Services.ServiceConfiguration();
builder.Services.LoggerConfiguration();

//CQRS configuration
builder.Services.ConfigureCQRS();

//controller Assembly reference
builder.Services.AddControllers()
.AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

Log.Write(LogEventLevel.Debug, "Application start");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
