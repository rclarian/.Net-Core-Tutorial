using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/{id:int}", async (context) =>
    {
        var id = context.Request.RouteValues["id"];
        if (id != null)
        {
            id = Convert.ToInt32(id);
            await context.Response.WriteAsync($"This is product with ID {id}");
        }
        else 
        {
            await context.Response.WriteAsync("You are in the product page!");
        }
        
    });

    endpoint.MapGet("/books/author/{authorname:alpha:minlength(4):maxlength(8)}/{bookid?}", async (context) =>
    {
        var bookId = context.Request.RouteValues["bookid"];
        var authorName = Convert.ToString(context.Request.RouteValues["authorname"]);

        if (bookId != null)
        {
            bookId = Convert.ToInt32(bookId);
            await context.Response.WriteAsync($"This is the book authored by {authorName} and book ID is {bookId}");
        }
        else 
        {
            await context.Response.WriteAsync($"Following are the book authored by {authorName}.");
        }
        
    });
});

//Short circuit middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core app!");
});

app.Run();
