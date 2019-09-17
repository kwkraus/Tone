using System.ComponentModel.DataAnnotations;
using Tone.LibraryManagement.Core.Entities;

namespace Tone.LibraryManagement.Data.Entities
{
    public class Book : BaseEntity
    {
        //Used DataAnnotations to define the entity validation rules
        //https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
