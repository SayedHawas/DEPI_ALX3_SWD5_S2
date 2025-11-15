using System.ComponentModel.DataAnnotations;

namespace Day8MVCDemo.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Must Enter Name ")]
        [MaxLength(250, ErrorMessage = "Must Enter Name with 250 letters Only")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Must Enter Name with 500 letters Only")]
        public string Description { get; set; }
    }
}
