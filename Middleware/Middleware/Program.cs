//1. Create an Intance of web application builder
var builder = WebApplication.CreateBuilder(args);

//2. Create an instance of WebApplication
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome from ASP.NET Core App!");
});


app.Run();
