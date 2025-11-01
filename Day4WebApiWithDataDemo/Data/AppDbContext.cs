using Day4WebApiWithDataDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace Day4WebApiWithDataDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        //Override ConnectionString
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Issue  Hard Code 
        //    //optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3G2;Initial Catalog=WebAPICodeFirstDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        //    // optionsBuilder.
        //    // base.OnConfiguring(optionsBuilder);
        //}
    }
}
