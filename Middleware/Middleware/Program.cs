using Middleware.CustomMiddleware;

//1. Create an Intance of web application builder
var builder = WebApplication.CreateBuilder(args);

//Register custom middleware as a service
builder.Services.AddTransient<MyMiddleware>(); //error here

//2. Create an instance of WebApplication
var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1 called");
    await next(context);
});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\n");
    await next(context);
});

//Middleware 3 - Using custome middleware class
//app.UseMiddleware<MyMiddleware>();
//app.MyMiddleware();
app.UseAnotherCustomMiddleware();

//Middleware 4
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 4 called \n\n");
});


app.Run();
