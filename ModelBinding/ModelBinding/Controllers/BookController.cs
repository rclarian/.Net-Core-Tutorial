using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ModelBinding.Controllers
{
    public class BookController : Controller
    {
        //URL - /Books?bookid=101&author=steve
        [Route("/Books")]
        public IActionResult Book(int bookid, string author)
        {
          
            return Content($"Book ID is: {bookid} \nAuthor is: {author}", "text/plain");
        }
    }
}
