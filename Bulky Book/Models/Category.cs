using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky_Book.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1 and 100 only !!!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedateTime { get; set; } = DateTime.Now;

    }
}
