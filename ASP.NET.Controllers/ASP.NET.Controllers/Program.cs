using ASP.NET.Controllers.Controllers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>(); //Register individual controller
builder.Services.AddControllers(); //Register all controllers

var app = builder.Build();

app.MapControllers();

//app.UseRouting();
//app.UseEndpoints(endpoints => 
//{ 
//    endpoints.MapControllers();
//});

app.Run();
