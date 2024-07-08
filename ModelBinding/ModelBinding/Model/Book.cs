using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Model
{
    public class Book
    {
        public int? BookID { get; set; }

        [Required(ErrorMessage = "{0} is a required field")]
        [Display(Name = "Book Name")]
        [StringLength(100, MinimumLength = 4, ErrorMessage ="{0} must have characters between {2} and {1}")]
        [RegularExpression("^[a-zA-Z ]$", ErrorMessage ="{0} is not valid")]
        public string BookName { get; set; }

        [ValidateNever]
        public string? Author { get; set; }

        [Range(0, 999.99, ErrorMessage ="{0} must be between {1} and {2}")]
        public Decimal Price { get; set; }

        [EmailAddress(ErrorMessage ="Email format is not valid")]
        public string AuthorEmail { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password does not match ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
