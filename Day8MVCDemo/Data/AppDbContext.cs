using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Add DbSet 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed Data 
            //modelBuilder.Entity<Department>().HasData(new Department()
            //{
            //    Name = "HR",
            //    Description = "",
            //    ManagerName = "Ahmed"
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
