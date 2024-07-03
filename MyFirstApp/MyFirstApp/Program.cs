
//Returns an instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
app.MapGet("/", () => "This is my first ASP.NET Core APP!");

//Starting the server
app.Run();
