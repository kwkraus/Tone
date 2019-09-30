using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Web.Models.Books
{
    public class NewBookViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string CoverPicture { get; set; }
        public IFormFile CoverPictureImage{ get; set; }
    }
}
