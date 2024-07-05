var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoint => 
{  
    //Define routes
    
});

app.MapGet("/", () => "Hello World!");

app.Run();
