using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/{id=101}", async (context) =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"This is product with ID {id}");
    });

    endpoint.MapGet("/books/author/{authorname='John-Smith'}/{bookid=1}", async (context) =>
    {
        var bookId = Convert.ToInt32(context.Request.RouteValues["bookid"]);
        var authorName = Convert.ToString(context.Request.RouteValues["authorname"]);
        await context.Response.WriteAsync($"This is the book authored by {authorName} and book ID is {bookId}");
    });
});

//Short circuit middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core app!");
});

app.Run();
