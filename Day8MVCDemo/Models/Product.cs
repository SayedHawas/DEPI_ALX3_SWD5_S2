using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day8MVCDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Must Enter Product Name ")]
        [StringLength(100, ErrorMessage = "Must Enter Name With 100 Letters")]
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "Must Enter Name With 100 Letters")]
        public string Description { get; set; }
        [Range(typeof(decimal), "0.00", "10000.00", ErrorMessage = "between 0.00 and 10000.00")]
        public decimal Price { get; set; }
        [NotMapped]
        public byte[] photo { get; set; }
        [StringLength(255, ErrorMessage = "Must Enter Name With 100 Letters")]
        public string PhotoPath { get; set; }
        [ForeignKey("Category")]
        public int categoryId { get; set; }
        //N-Property 
        public virtual Category Category { get; set; }

    }
}
