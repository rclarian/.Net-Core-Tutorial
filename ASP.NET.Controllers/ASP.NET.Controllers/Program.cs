using ASP.NET.Controllers.Controller;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<HomeController>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();
