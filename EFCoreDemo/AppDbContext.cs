using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3;Initial Catalog=Group3DB;Integrated Security=True;Trust Server Certificate=True");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
