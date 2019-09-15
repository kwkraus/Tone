using System;

namespace Tone.LibraryManagement.Data.Entities
{
    public class UserBookAssociation : BaseEntity
    {
        public User User { get; set; }
        public BookLibraryAssociation BookLibraryAssociation { get; set; }
        public DateTime DueDate { get; set; }
    }
}
