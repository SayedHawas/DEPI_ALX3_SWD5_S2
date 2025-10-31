using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day3EfCoreAdvacedDemo.Models
{
    [Table("TblDepartments")]
    public class Department
    {
        [Key]
        public int departmentId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [NotMapped]
        public byte[] Image { get; set; }
        [MaxLength(255)]
        //[StringLength(255)]
        public string ImagePath { get; set; }

        //Navigation Property
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
