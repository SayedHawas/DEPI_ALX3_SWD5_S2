namespace EFCoreDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            AppDbContext db = new AppDbContext();

            var employees = db.Employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine($" Name {item.Name} ID {item.Id} Salary {item.Salary.ToString("C")} ");
            }
            Console.WriteLine("------------------------");

            var GtSalary = db.Employees.Where(e => e.Salary > 20000).ToList();
            foreach (var item in GtSalary)
            {
                Console.WriteLine($" Name {item.Name} ID {item.Id} Salary {item.Salary.ToString("C")} ");
            }
            Console.ReadLine();
        }
    }
}
