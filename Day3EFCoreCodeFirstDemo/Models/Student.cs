namespace Day3EFCoreCodeFirstDemo.Models
{
    public class Student
    {
        //Primary Key 
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Id : {StudentId} Name : {Name} EnrollmentDate:{EnrollmentDate} ";
        }
    }
}
