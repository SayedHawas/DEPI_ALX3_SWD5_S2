using Microsoft.EntityFrameworkCore;

namespace Day2EFCoreCodeFirstDemo.Models
{
    public class AppDbContext : DbContext
    {
        //Default CTOR
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3G2;Initial Catalog=EFCodeFirstGs2DB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            // base.OnConfiguring(optionsBuilder);
        }

    }
}
