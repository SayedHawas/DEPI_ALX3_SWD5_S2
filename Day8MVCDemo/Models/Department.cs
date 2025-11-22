using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Day8MVCDemo.Models
{
    [Table(name: "TblDepartments")]
    public class Department
    {
        [Key]
        [Display(Name = "Code")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Must Enter Name ...")]
        [MaxLength(100, ErrorMessage = "Must Enter 100 Letters only")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Must Enter 500 Letters only")]
        public string? Description { get; set; } //= null;
        [MaxLength(200, ErrorMessage = "Must Enter 200 Letters only")]
        [Display(Name = "Manager Name")]
        public string? ManagerName { get; set; }
    }
}
