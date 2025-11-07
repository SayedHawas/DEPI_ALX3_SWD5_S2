using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day4WebApiWithDataDemo.Models
{
    [Table("TblDepartments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string? Description { get; set; }

        //Relation 
        //[JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
