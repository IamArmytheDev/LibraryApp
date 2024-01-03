using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
