using Day3EfCoreWizardDemo.Models;

namespace Day3EfCoreWizardDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            AppDbContext db = new AppDbContext();
            // db.Categories.Add(new Category { CategoryName = "Smart Phone", Description = " Using smart phone ", IsDelete = false });
            db.Categories.Add(new Category { CategoryName = "Printer", Description = " Using Printer ", IsDelete = false });

            db.SaveChanges();
            Console.WriteLine("Create Category ...");
        }
    }
}
