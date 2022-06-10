using Microsoft.AspNetCore.Mvc;
using RobotAttempt.Controllers;

//using RobotAttempt.Services;
//using RobotAttempt.Model;
//using ASPWebAPI.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("LocalDB"));

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<RobotAttempt.LocationService>();

WebApplication app = builder.Build();

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

