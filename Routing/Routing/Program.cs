using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "staticfiles"
});

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
});

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/products/{id:int:range(10, 1000)}", async (context) =>
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

    endpoint.MapGet("/books/author/{authorname:alpha:length(4, 8)}/{bookid?}", async (context) => // or length(8)
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

    endpoint.MapGet("/quaterly-reports/{year:int:min(1999):minlength(4)}/{month}", async (context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "mar" || month == "jun" || month == "sep" || month == "dec")
        {
            await context.Response.WriteAsync($"This is the quaterly report for {year}-{month}");
        }
        else
        {
            await context.Response.WriteAsync($"The month value {month} is not valid");
        }
    });

    endpoint.MapGet("/monthly-reports/{month:regex(^([1-9]|1[012])$)}", async (context) =>
    {
        int monthNumber = Convert.ToInt32(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"This is the monthly report for month number {monthNumber}");
    });

    //YYYY-MM-DD / YYYY.MM.DD / YYYY/MM/DD - 1900-01-01 to 2099-12-31
    endpoint.MapGet("/daily-reports/{date:regex(^(19|20)\\d\\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$)}", async (context) =>
    {
        string? date = Convert.ToString(context.Request.RouteValues["date"]);
        await context.Response.WriteAsync($"This is the daily report for {date}");
    });

    // - /user/manojjha10
    endpoint.MapGet("/user/{username:alphanumeric}", async (context) =>
    {
        string? username = Convert.ToString(context.Request.RouteValues["username"]);
        await context.Response.WriteAsync($"Welcome {username}");
    });

    //Route: /books/category/{bookid}
    endpoint.MapGet("/books/category/{bookid}", async (context) =>
    {
        await context.Response.WriteAsync("Route called - /books/category/{bookid}");
    });

    //Route: /books/category/{bookid:int}
    endpoint.MapGet("/books/category/{bookid:int}", async (context) =>
    {
        await context.Response.WriteAsync("Route called - /books/category/{bookid:int}");
    });
});

//Short circuit middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("The URL which you are looking for is not found!");
});

app.Run();
