using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controllers
{
    public class StoreController : Controller
    {
        [Route("/category/books")]
        public IActionResult Books()
        {
            return Content("Books page", "text/plain");
        }
    }
}
