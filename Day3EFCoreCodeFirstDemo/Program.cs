using Day3EFCoreCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3EFCoreCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region Old Code Code First 
            ////1- Create Object From : Dbcontext

            //using (SchoolDB db = new SchoolDB())
            //{
            //    //Read All
            //    IQueryable<Student> studentsList = db.Students.Where(s => s.StudentId >= 1);
            //    foreach (var item in studentsList)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //    Console.WriteLine("-------------------------");
            //    //read by ID 
            //    var studentById = db.Students.Find(3);
            //    if (studentById != null)
            //    {
            //        Console.WriteLine(studentById.ToString());
            //    }
            //    else
            //    {
            //        Console.WriteLine("Student Not Found ...");
            //    }

            //    Student newStrudent = new Student { Name = "Ali", Age = 25, EnrollmentDate = DateTime.Now };

            //    //Add 
            //    db.Students.Add(newStrudent);
            //    db.SaveChanges();
            //    Console.WriteLine("Save ....");
            //    //Read All
            //    IQueryable<Student> studentsList2 = db.Students.Where(s => s.StudentId >= 1);
            //    foreach (var item in studentsList2)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //    //Update 
            //    var x = db.Students.Find(1);
            //    //var studentUpdate = db.Students.First(s => s.StudentId == 3 && s.Name.Contains("a"));
            //    //var studentUpdate = db.Students.FirstOrDefault(s => s.StudentId == 3 && s.Name.Contains("a"));
            //    // var studentUpdate = db.Students.Last(s => s.StudentId == 3 && s.Name.Contains("a"));
            //    //var studentUpdate = db.Students.LastOrDefault(s => s.StudentId == 3 && s.Name.Contains("a"));
            //    var studentUpdate = db.Students.SingleOrDefault(s => s.Name.Contains("t"));

            //    studentUpdate.Name = "Ahmed Ali ";

            //    db.SaveChanges();
            //    Console.WriteLine("Student With Id 3 Modified ...");
            //    //Read All
            //    IQueryable<Student> studentsList3 = db.Students.Where(s => s.StudentId >= 1);
            //    foreach (var item in studentsList3)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //    //Delete 

            //    var studentDelete = db.Students.FirstOrDefault(s => s.StudentId == 3);
            //    //db.Students.Remove(studentDelete);
            //    //db.SaveChanges();
            //    Console.WriteLine("Deleted Done ");
            //    //Read All
            //    IQueryable<Student> studentsList4 = db.Students.Where(s => s.StudentId >= 1);
            //    foreach (var item in studentsList4)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //} 
            #endregion

            #region Trancking 
            using (SchoolDB db = new SchoolDB())
            {
                //1)Read All
                // var students = db.Students.ToList();
                var students = db.Students.AsNoTracking().ToList();
                foreach (var item in students)
                {
                    Console.WriteLine($" ID {item.StudentId} Name {item.Name} ");
                }
                //2)Edit 
                var selectstudent = db.Students.FirstOrDefault(e => e.StudentId == 5);
                Console.WriteLine(db.Entry<Student>(selectstudent).State);
                selectstudent.Name = "Sayed Hawas 2";
                Console.WriteLine(db.Entry<Student>(selectstudent).State);

                //3)To ADD
                Student NewStudent = new Student { Name = "Mariem ElSayed", Age = 19, EnrollmentDate = DateTime.Now };
                Console.WriteLine(db.Entry<Student>(NewStudent).State);
                db.Students.Add(NewStudent);
                Console.WriteLine(db.Entry<Student>(NewStudent).State);

                //4)To Remove
                var deleteStudent = db.Students.FirstOrDefault(e => e.StudentId == 13);
                Console.WriteLine(db.Entry<Student>(deleteStudent).State);
                db.Remove(deleteStudent);
                Console.WriteLine(db.Entry<Student>(deleteStudent).State);


                Console.WriteLine(db.ChangeTracker.ToDebugString());


                db.SaveChanges();
                Console.WriteLine("Saving ....");
            }
            #endregion
            Console.ReadLine();
        }
    }
}
