
//Returns an instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
app.MapGet("/", (HttpContext context) => 
    {

        context.Response.Headers["Content-Type"] = "text/html";
        return "<h2>This is a Text response</h2>";
    }
);

//Starting the server
app.Run();
