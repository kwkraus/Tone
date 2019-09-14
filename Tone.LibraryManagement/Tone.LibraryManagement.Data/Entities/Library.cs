using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Data.Entities
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public int LocationId { get; set; }
    }
}
