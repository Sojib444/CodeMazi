using ComapnyEmployee.Entension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCQRS();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
