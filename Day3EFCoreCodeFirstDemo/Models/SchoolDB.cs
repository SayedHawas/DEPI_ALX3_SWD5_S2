using Microsoft.EntityFrameworkCore;

namespace Day3EFCoreCodeFirstDemo.Models
{
    public class SchoolDB : DbContext
    {
        //Connection string  "Data source =   ; Initial Catalog= ; Integrated security = true"

        public SchoolDB()
        {

        }

        public SchoolDB(DbContextOptions<SchoolDB> options) : base(options)
        {

        }

        //DbSet
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=SAYEDHAWAS\\DEPI2025R3G2;Initial Catalog=EFCoreS2Day3Db;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seedData
            //modelBuilder.Entity<Student>(stu =>
            //{
            //    stu.HasData(new Student
            //    {
            //        Name = "Ali",
            //        Age = 25,
            //        EnrollmentDate = DateTime.Now
            //    });
            //});

            ////base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Student>(stud =>
            //{
            //    stud.Property(x => x.Name).IsRequired().HasMaxLength(50);
            //});
        }
    }
}
