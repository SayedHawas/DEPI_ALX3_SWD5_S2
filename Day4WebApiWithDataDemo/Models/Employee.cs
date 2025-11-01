using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day4WebApiWithDataDemo.Models
{
    //Data Annotation & Validation 
    [Table("TblEmployees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Must Enter Name")]
        [StringLength(50, ErrorMessage = "Must Enter 50 Letters Only ...")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "999999.99")]
        public decimal Salary { get; set; }

        [StringLength(200)]
        public string JobTitle { get; set; }

        //^01[0 - 2, 5]{1}[0 - 9]{8}$
        [StringLength(11)]
        [RegularExpression("^01[0-2,5]{1}[0-9]{8}$")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
