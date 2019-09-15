using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Data.Entities
{
    public class Library: BaseEntity
    {
        public int LocationId { get; set; }
    }
}
