using Tone.LibraryManagement.Core.Entities;

namespace Tone.LibraryManagement.Data.Entities
{
    public class User : BaseEntity
    {
        public Role Role { get; set; }
        public int LocationId { get; set; }
    }
}
