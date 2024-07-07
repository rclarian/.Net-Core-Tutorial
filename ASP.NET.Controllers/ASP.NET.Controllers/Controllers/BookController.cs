using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controllers
{
    public class BookController : Controller
    {
        // /Books?IsLogged=true&BookId=200
        [Route("/Books")]
        public IActionResult Books()
        {
            if (!Request.Query.ContainsKey("BookId"))
            {
                return BadRequest("Book ID is not Provided!");
            }

            int bookId = Convert.ToInt32(Request.Query["BookId"]);
            if(bookId < 1 || bookId > 1000)
            {
                return NotFound("Book ID is not in Range of 1 to 1000");
            }

            if (!Convert.ToBoolean(Request.Query["IsLogged"]))
            {
                //return Unauthorized("You are not logged in!");
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            }

            return File("/Samples/Sample.pdf", "application/pdf");
        }
    }
}
