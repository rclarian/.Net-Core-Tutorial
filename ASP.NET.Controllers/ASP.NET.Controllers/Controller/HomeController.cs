using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controller
{
    public class HomeController
    {
        [Route("Home")]
        public string Index()
        {
            return "Welcome from ASP.NET core application";
        }
    }
}
