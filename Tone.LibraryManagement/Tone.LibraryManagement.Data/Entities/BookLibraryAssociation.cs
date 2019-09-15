using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Data.Entities
{
    public class BookLibraryAssociation : BaseEntity
    {
        public Book Book { get; set; }
        public Library Library { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
