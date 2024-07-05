var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint => 
{
    //Define routes
    endpoint.Map("/Home", async (context) =>
    {
        await context.Response.WriteAsync("Your are in the Home page");
    });

    endpoint.MapGet("/Product", async (context) =>
    {
        await context.Response.WriteAsync("Your are in the Products page");
    });

    endpoint.MapPost("/Product", async (context) =>
    {
        await context.Response.WriteAsync("A new Product created");
    });
});

//Short circuit middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("The URL which you are looking for is not found!");
});

app.Run();
