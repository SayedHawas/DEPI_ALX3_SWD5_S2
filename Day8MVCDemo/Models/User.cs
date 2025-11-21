using System.ComponentModel.DataAnnotations;

namespace Day8MVCDemo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Must Entre UserName")]
        [StringLength(100, ErrorMessage = "Enter 100 Letters Only")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must Entre Password")]
        [StringLength(50, ErrorMessage = "Enter 50 Letters Only")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Must Entre Email")]
        [StringLength(100, ErrorMessage = "Enter 200 Letters Only")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
