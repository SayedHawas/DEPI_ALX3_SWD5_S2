using Day2EFCoreCodeFirstDemo.Models;

namespace Day2EFCoreCodeFirstDemo
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    #region Old Code 
        //    //Console.WriteLine("Hello, Entity framework Core CRUD");

        //    //using (AppDbContext db = new AppDbContext())
        //    //{
        //    //    //Read All Rows (LINQ)
        //    //    //Console.WriteLine("Read All");
        //    //    //var students = db.Students.ToList();
        //    //    //foreach (var item in students)
        //    //    //{
        //    //    //    Console.WriteLine(item.ToString());
        //    //    //}
        //    //    //Console.WriteLine("-------------------------");

        //    //    //Console.WriteLine("Read By ID ");
        //    //    //Console.Write("Enter Id To Get : ");
        //    //    //int id;
        //    //    //int.TryParse(Console.ReadLine(), out id);

        //    //    //// var studentById = db.Students.Find(id);
        //    //    //// var studentById = db.Students.Where(s => s.StudentId == id).First(); Error With NULL
        //    //    ////var studentById = db.Students.Where(s => s.StudentId == id).FirstOrDefault();
        //    //    ////var studentById = db.Students.FirstOrDefault(s => s.StudentId == id);
        //    //    ///*var studentById = db.Students.Last(s => s.StudentId == id);*/ //Error With Null
        //    //    ////var studentById = db.Students.LastOrDefault(s => s.StudentId == id);
        //    //    //// var studentById = db.Students.Single(s => s.StudentId == id);
        //    //    //// Error in Two Cases 1) Null 
        //    //    ////                     2) Deplication
        //    //    ////var studentById = db.Students.SingleOrDefault(s => s.StudentId == id);
        //    //    //var studentById = db.Students.Find(id);
        //    //    //if (studentById == null)
        //    //    //    Console.WriteLine("Student Not Found ...");
        //    //    //else
        //    //    //    Console.WriteLine(studentById.ToString());
        //    //    //Console.WriteLine("-------------------------");

        //    //    ////Create 
        //    //    //Console.WriteLine("Create Student ");
        //    //    //Console.Write("Enter Student Name ");
        //    //    //string name = Console.ReadLine();
        //    //    //Student newStudent = new Student();
        //    //    //newStudent.Name = name;
        //    //    //newStudent.JoinDate = DateTime.Now;
        //    //    ////Add
        //    //    //db.Students.Add(newStudent);
        //    //    ////Save in Db
        //    //    //db.SaveChanges();
        //    //    //Console.WriteLine("Saving .....");


        //    //    ////Update 
        //    //    //Console.WriteLine("update Student ");
        //    //    //Console.Write("Enter Student ID ");
        //    //    //int selectid;
        //    //    //int.TryParse(Console.ReadLine(), out selectid);
        //    //    //var studentEdit = db.Students.Find(selectid);
        //    //    //Console.Write("Enter Student New Name ");
        //    //    //string newName = Console.ReadLine();
        //    //    //studentEdit.Name = newName;
        //    //    ////Save in Db
        //    //    //db.SaveChanges();
        //    //    //Console.WriteLine("Update .....");

        //    //    //Delete 
        //    //    //Console.WriteLine("Delete Student ");
        //    //    //Console.Write("Enter Student ID ");
        //    //    //int deleteid;
        //    //    //int.TryParse(Console.ReadLine(), out deleteid);
        //    //    //var studentDelete = db.Students.Find(deleteid);
        //    //    ////Delete 
        //    //    //db.Students.Remove(studentDelete);
        //    //    ////Save in Db
        //    //    //db.SaveChanges();
        //    //    //Console.WriteLine("Delete .....");


        //    //    //SaveChange -- Create , Update , delete 
        //    //}

        //    //Console.ReadLine(); 
        //    #endregion




        //}

        public enum Operations
        {
            ReadAll = 1,
            ReadByID,
            Create,
            Update,
            Delete
        }
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.WriteLine("Hello To Entity Framework !!!");
                using (var context = new AppDbContext())
                {
                    Console.WriteLine("To Create CRUD Operators For Student ...");
                    Console.WriteLine("ReadAll Press 1\nRead By ID Press 2\nCreate Press 3\nUpdate press 4 \nDelete press 5 \n  ");
                    Console.WriteLine("=====================================================");
                    Console.Write("Enter Operator ... : ");
                    int operators;
                    int.TryParse(Console.ReadLine(), out operators);
                    switch ((Operations)operators)
                    {
                        case Operations.ReadAll:
                            // Read
                            Console.WriteLine("List Of Students");
                            var students = context.Students.ToList();
                            foreach (var item in students)
                            {
                                Console.WriteLine(item.ToString());

                            }
                            Console.WriteLine("-------------- End ------------");
                            break;
                        case Operations.ReadByID:
                            // Read
                            Console.WriteLine("Get Student By Id ");
                            Console.Write("Enter ID to Find ");
                            int id;
                            int.TryParse(Console.ReadLine(), out id);
                            var studentById = context.Students.Find(id);
                            if (studentById != null)
                                Console.WriteLine(studentById.ToString());
                            else
                                Console.WriteLine("Not Found");
                            Console.WriteLine("-------------- End ------------");
                            break;
                        case Operations.Create:
                            // Create
                            Console.WriteLine("Inserting a new student");
                            Student newStaudent = new Student();
                            Console.Write("Enter Student Name : ");
                            newStaudent.Name = Console.ReadLine();
                            newStaudent.JoinDate = DateTime.Now;
                            context.Students.Add(newStaudent);
                            context.SaveChanges();
                            Console.WriteLine("Saving");
                            Console.WriteLine("-------------- End ------------");
                            break;
                        case Operations.Update:
                            // Update
                            Console.WriteLine("Updating the Student ");
                            Console.Write("Enter ID To Edit :  ");
                            int selectId;
                            int.TryParse(Console.ReadLine(), out selectId);
                            var studentUpdate = context.Students.Where(s => s.StudentId == selectId).FirstOrDefault();
                            Console.Write("Enter New Name :  ");
                            studentUpdate.Name = Console.ReadLine();
                            context.SaveChanges();
                            Console.WriteLine("-------------- End ------------");
                            break;
                        case Operations.Delete:
                            // Delete
                            Console.WriteLine("Delete the student");
                            Console.Write("Enter ID To Delete :  ");
                            int deleteId;
                            int.TryParse(Console.ReadLine(), out deleteId);
                            var studentDelete = context.Students.FirstOrDefault(s => s.StudentId == deleteId);
                            context.Students.Remove(studentDelete);
                            context.SaveChanges();
                            Console.WriteLine("-------------- End ------------");
                            break;
                        default:
                            Console.WriteLine("Invalid Operator ....");
                            break;
                    }
                }
                Console.ReadLine();
            } while (true);

        }
    }
}
