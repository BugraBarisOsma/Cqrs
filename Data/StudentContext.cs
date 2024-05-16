using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {


        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student() {Name="Bugra",Age = 25,Surname = "Osma",Id=1},
                new Student() {Name="Baris",Age = 24,Surname = "Osma",Id=2}

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
