using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controller
{
    //[Controller]
    public class HomeController
    {
        [Route("Home")]
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "<h1>Welcome from ASP.NET core application</h1>",
                ContentType = "text/html"
            };
            //return "Welcome from ASP.NET core application";
        }

        [Route("About")]
        public string About()
        {
            return "You are in About Page!";
        }

        [Route("Contact-Us")]
        public string Contact()
        {
            return "You are in About Contact!";
        }

        [Route("/products/{id:int:min(1000):max(9999)}")]
        public string Products()
        {
            return "You are in Products Page!";
        }
    }
}
