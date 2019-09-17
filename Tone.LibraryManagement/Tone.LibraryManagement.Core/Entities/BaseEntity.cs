namespace Tone.LibraryManagement.Core.Entities
{
    public abstract class BaseEntity
    {
        //don't need the [Key] DataAnnotation because EF convention dictates field named 'Id' are automatically made key 
        public int Id { get; set; }
    }
}
