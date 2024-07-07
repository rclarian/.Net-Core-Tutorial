using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ModelBinding.Controllers
{
    public class BookController : Controller
    {
        //URL query string - /Books?bookid=101&author=steve
        //URL route parameters - /Books/102/RYAN
        [Route("/Books/{BookId}/{Author}")]
        public IActionResult Book(int? bookid, string author)
        {
          
            return Content($"Book ID is: {bookid} \nAuthor is: {author}", "text/plain");
        }
    }
}
