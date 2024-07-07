using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASP.NET.Controllers.Controllers
{
    public class BookController : Controller
    {
        // /Books?IsLogged=true&BookId=200
        [Route("/Books")]
        public IActionResult Books()
        {
            int bookid = Convert.ToInt32(Request.Query["bookid"]);
            bool islogged = Convert.ToBoolean(Request.Query["isLogged"]);

            //if (!Request.Query.ContainsKey("BookId"))
            //{
            //    return BadRequest("Book ID is not Provided!");
            //}

            //int bookId = Convert.ToInt32(Request.Query["BookId"]);
            //if(bookId < 1 || bookId > 1000)
            //{
            //    return NotFound("Book ID is not in Range of 1 to 1000");
            //}

            //if (!Convert.ToBoolean(Request.Query["IsLogged"]))
            //{
            //    //return Unauthorized("You are not logged in!");
            //    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized);
            //}
            //return File("/Samples/Sample.pdf", "application/pdf");

            //return RedirectToAction("Books", "Store", new {});
            //301 - Moved permanently
            //302 - Found(Moved temporarily)
            //return new RedirectToActionResult("Books", "Store", new { }, true);
            //return RedirectToActionPermanent("Books", "Store", new { });

            //return new LocalRedirectResult($"/category/books/{bookid}/{islogged}", true);
            //return LocalRedirect($"/category/books/{bookid}/{islogged}");
            //return LocalRedirectPermanent($"/category/books/{bookid}/{islogged}");

            //return new RedirectResult("https://www.google.com"); //redirect to external site
            return new RedirectResult($"/category/books/{bookid}/{islogged}");
        }
    }
}
