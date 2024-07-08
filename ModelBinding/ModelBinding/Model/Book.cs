using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Model
{
    public class Book
    {
        [FromRoute]
        public int? BookID { get; set; }

        [FromQuery]
        public string? Author { get; set; }
    }
}
