using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Model
{
    public class Book
    {
        public int? BookID { get; set; }

        [Required(ErrorMessage = "{0} is a required field")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        public string? Author { get; set; }
    }
}
