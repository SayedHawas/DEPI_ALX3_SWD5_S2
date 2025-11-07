using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Day4WebApiWithDataDemo.DTOs.DepartmentDto
{
    public class DepartmentPostDto
    {
        [JsonIgnore]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
