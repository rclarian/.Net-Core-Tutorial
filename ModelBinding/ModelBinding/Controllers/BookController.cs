using Microsoft.AspNetCore.Mvc;
using System.Net;
using ModelBinding.Model;

namespace ModelBinding.Controllers
{
    public class BookController : Controller
    {
        //URL query string - /Books?bookid=101&author=steve
        //URL route parameters - /Books/102/RYAN
        [Route("/Books/{BookId?}/{Author?}")]
        public IActionResult Book(Book book)
        {
            if(book.BookID.HasValue == false)
            {
                return Content("Book ID not provided", "text/plain");
            }
          
            return Content($"Book ID is: {book.BookID} \nAuthor is: {book.Author}", "text/plain");
        }
    }
}
