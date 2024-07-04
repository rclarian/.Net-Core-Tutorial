using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Xml.Linq;

//Returns an instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
//app.MapGet("/", (HttpContext context) => 
//    {
//        context.Response.Headers["Content-Type"] = "text/html";
//        context.Response.Headers["MyHeader"] = "Hello World";
//        return "<h2>This is a Text response</h2>";
//    }
//);

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;

    if(path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in the Home page");
    }
    else if(path == "/Contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in the Contact page");
    }
    else if (method == "GET" && path == "/Product")
    {
        context.Response.StatusCode = 200;
        if (context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync($"You selected the Product with ID {id} and Name {name}");
            return;
        }
        
        await context.Response.WriteAsync("You are in the Product page");
    }
    else if (method == "POST" && path == "/Product")
    {
        string id = "";
        string name = "";
        StreamReader reader = new StreamReader(context.Request.Body);
        string data = await reader.ReadToEndAsync();
        Dictionary<string, StringValues> dict = QueryHelpers.ParseQuery(data);

        if (dict.ContainsKey("id") && dict.ContainsKey("name"))
        {
            id = dict["id"];
        }

        if (dict.ContainsKey("name"))
        {
            name = dict["name"][0];
        }

        await context.Response.WriteAsync($"Id is: {id} \nName is: {name}");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Page not found!");
    }
    
});

//Starting the server
app.Run();
