using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Data.Entities
{
    public class BookLibraryAssociation
    {
        [Key]
        public int BookLibraryAssociationId { get; set; }
        public Book Book { get; set; }
        public Library Library { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
