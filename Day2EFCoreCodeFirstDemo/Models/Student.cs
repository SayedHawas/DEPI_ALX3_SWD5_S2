using System.ComponentModel.DataAnnotations;

namespace Day2EFCoreCodeFirstDemo.Models
{
    public class Student
    {
        //Data Annontation  Attributes --> Configuration Database 
        [Key]
        public int StudentId { get; set; }  //Primary Key + Identity (1,1)
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }
        public int? Mark { get; set; }

        public override string ToString()
        {
            return $"student Id : {StudentId} Name : {Name} Date : {JoinDate}";
        }
    }
}
