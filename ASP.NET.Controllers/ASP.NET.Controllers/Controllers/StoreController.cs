using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controllers
{
    public class StoreController : Controller
    {
        [Route("/category/books/{bookid}/{isLogged}")]
        public IActionResult Books()
        {
            if (!Request.RouteValues.ContainsKey("bookid"))
            {
                return BadRequest("Book ID is not Provided!");
            }

            int bookId = Convert.ToInt32(Request.RouteValues["bookid"]);
            if (bookId < 1 || bookId > 1000)
            {
                return NotFound("Book ID is not in Range of 1 to 1000");
            }

            bool isLogged = Convert.ToBoolean(Request.RouteValues["isLogged"]);
            if (!isLogged)
            {
                //return Unauthorized("You are not logged in!");
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }
            //return File("/Samples/Sample.pdf", "application/pdf");
            //return Content("Books page", "text/plain");
            return Content($"User Logged = {isLogged} and BookId = {bookId}", "text/plain");
        }
    }
}
