using ASP.NET.Controllers.Controller;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>(); //Register individual controller
builder.Services.AddControllers(); //Register all controllers

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => 
{ 
    endpoints.MapControllers();
});

app.Run();
