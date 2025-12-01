using Microsoft.AspNetCore.Mvc;
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
        [IsExist(ErrorMessage = "This Product Already Exist ...")]//(ErrorMessage = "This Product Already Exist ... ")]
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "Must Enter Name With 100 Letters")]
        public string Description { get; set; }
        [Range(typeof(decimal), "0.00", "100000.00", ErrorMessage = "between 0.00 and 100000.00")]

        //[CustomValidation(typeof(PriceAttribute), "ValidatePrice")]
        [Remote("CheckPrice", "Products", ErrorMessage = "Must Enter Price GT 1 $ ...")]
        public decimal Price { get; set; }
        [NotMapped]
        public byte[]? photo { get; set; }
        [StringLength(255, ErrorMessage = "Must Enter Name With 100 Letters")]
        [Display(Name = "Image")]
        public string PhotoPath { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int categoryId { get; set; }
        //N-Property 
        public virtual Category? Category { get; set; }

    }
}
