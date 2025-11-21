using System.ComponentModel.DataAnnotations;

namespace Day8MVCDemo.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Code")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Must Enter Name ")]
        [MaxLength(250, ErrorMessage = "Must Enter Name with 250 letters Only")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Must Enter Name with 500 letters Only")]
        public string Description { get; set; }

        //N-Property 
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
