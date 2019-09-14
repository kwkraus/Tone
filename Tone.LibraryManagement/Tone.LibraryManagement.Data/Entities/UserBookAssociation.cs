using System;

namespace Tone.LibraryManagement.Data.Entities
{
    public class UserBookAssociation
    {
        //don't need the [Key] DataAnnotation because EF convention dictates field named 'Id' are automatically made key 
        public int Id { get; set; }
        public User User { get; set; }
        public BookLibraryAssociation BookLibraryAssociation { get; set; }
        public DateTime DueDate { get; set; }
    }
}
