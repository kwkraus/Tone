using System.ComponentModel.DataAnnotations;

namespace Tone.LibraryManagement.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int LocationId { get; set; }
    }
}
