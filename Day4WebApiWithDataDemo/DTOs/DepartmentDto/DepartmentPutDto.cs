using System.ComponentModel.DataAnnotations;

namespace Day4WebApiWithDataDemo.DTOs.DepartmentDto
{
    public class DepartmentPutDto
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
