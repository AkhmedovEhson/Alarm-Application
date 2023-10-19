using WebTimer;
using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Diagnostics;
using middlewares = WebTimer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add layers ...
builder.Services.AddWebTimerServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();


var app = builder.Build();

// Middlewares ...
app.UseMiddleware<middlewares::PerformanceMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// AutoMigration ...
using(var scope = app.Services.CreateScope())
{
    Console.WriteLine("Migration started ....");
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await dataContext.InitializeAsync();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
