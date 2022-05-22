using System.ComponentModel.DataAnnotations;

namespace Ispit.API.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public bool IsComplited { get; set; }
    }
}
