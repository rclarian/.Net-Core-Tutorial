using Microsoft.AspNetCore.Mvc;
using System.Net;
using ModelBinding.Model;

namespace ModelBinding.Controllers
{
    public class BookController : Controller
    {
        //Form data > request body > route parameter > query string
        //Route parameters will have higher preference over query string key
        //URL query string - /Books?bookid=101&author=steve
        //URL route parameters - /Books/102/RYAN

        [Route("/Books/{BookId?}/{Author?}")]
        public IActionResult Book(Book book)
        {
            if(book.BookID.HasValue == false)
            {
                return Content("Book ID not provided", "text/plain");
            }

            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors) 
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessages = string.Join("\n", errors);
                return BadRequest(errorMessages);
            }
          
            return Content($"Book ID is: {book.BookID} \nAuthor is: {book.Author}\nBook Name = {book.BookName}", "text/plain");
        }
    }
}
