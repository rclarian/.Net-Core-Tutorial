//1. Create an Intance of web application builder
var builder = WebApplication.CreateBuilder(args);

//2. Create an instance of WebApplication
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome from ASP.NET Core App 1!");
    await next(context);
});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\n Welcome from ASP.NET Core App 2!");
    await next(context);
});

//Middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This is my first ASP.NET Core App 3!");
});


app.Run();
