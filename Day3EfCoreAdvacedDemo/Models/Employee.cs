using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day3EfCoreAdvacedDemo.Models
{
    [Table("TblEmployees")]
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "999999.99")]
        public decimal Salary { get; set; }
        [StringLength(200)]
        public string Jobtitle { get; set; }
        [StringLength(500)]
        public string Jobdescription { get; set; }
        //^01[0 - 2, 5]{1}[0 - 9]{8}$
        [StringLength(11)]
        [RegularExpression("^01[0-2,5]{1}[0-9]{8}$")]
        public string Mobile { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        //Navigation Property
        public virtual Department Department { get; set; }
    }
}
