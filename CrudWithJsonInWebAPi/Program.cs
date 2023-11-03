
using CrudWithJsonInWebAPi.Models;
using CrudWithJsonInWebAPi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration for reading the JSON file path
builder.Services.Configure<JsonFilePathOptions>(builder.Configuration.GetSection("JsonFilePathOptions"));
builder.Services.AddScoped<IEmployee, EmployeeJson>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
