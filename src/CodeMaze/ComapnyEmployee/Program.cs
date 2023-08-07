using ComapnyEmployee.Entension;
using Microsoft.EntityFrameworkCore;
using Repository;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Serilog Configure
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

//Database Configuraton
builder.Services.AddDbContext<RepositoryContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
assembly => assembly.MigrationsAssembly("CompanyEmployee")));

//Register Dependency
builder.Services.RepositoryConfiguration();
builder.Services.ServiceConfiguration();

//CQRS configuration
builder.Services.ConfigureCQRS();

//Add controller Assembly reference
builder.Services.AddControllers()
.AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
