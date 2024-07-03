
//Returns an instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
app.MapGet("/", (HttpContext context) => 
    {
        string path = context.Request.Path;
        string method = context.Request.Method;

        context.Response.StatusCode = 200;

        return "Request path: " + path + " Http Method: " + method;
    }
);

//Starting the server
app.Run();
