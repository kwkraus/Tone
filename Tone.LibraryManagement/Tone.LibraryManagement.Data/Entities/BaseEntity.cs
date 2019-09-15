namespace Tone.LibraryManagement.Data.Entities
{
    public class BaseEntity
    {
        //don't need the [Key] DataAnnotation because EF convention dictates field named 'Id' are automatically made key 
        public int Id { get; set; }
    }
}
