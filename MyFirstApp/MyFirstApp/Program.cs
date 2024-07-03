
//Returns an instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
app.MapGet("/", (HttpContext context) => 
    {
        //string path = context.Request.Path;
        //string method = context.Request.Method;
        var userAgent = "";
        if (context.Request.Headers.ContainsKey("User-Agent"))
        {
            userAgent = context.Request.Headers["User-Agent"];
        }

        context.Response.StatusCode = 200;

        return "User Agent: " + userAgent;
    }
);

//Starting the server
app.Run();
