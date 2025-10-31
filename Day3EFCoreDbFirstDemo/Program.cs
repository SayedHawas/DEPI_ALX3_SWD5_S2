using Day3EFCoreDbFirstDemo.Data;
using Day3EFCoreDbFirstDemo.Models;
namespace Day3EFCoreDbFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            AppDbContext db = new AppDbContext();
            // db.Categories.Add(new Category { CategoryName = "Smart Phone", Description = " Using smart phone ", IsDelete = false });
            db.Categories.Add(new Category { CategoryName = "Labtop", Description = " Using Labtop ", IsDelete = false });

            db.SaveChanges();
            Console.WriteLine("Create Category ...");
        }
    }
}
