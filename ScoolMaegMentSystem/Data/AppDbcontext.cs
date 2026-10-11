using Microsoft.EntityFrameworkCore;
using ScoolMaegMentSystem.Model;

namespace ScoolMaegMentSystem.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentProfile> studentProfiles { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(a => a.enrollments).WithOne(a => a.Course).HasForeignKey(a => a.CourceId);
            modelBuilder.Entity<Student>().HasMany(a => a.enrollments).WithOne(a => a.Student).HasForeignKey(a => a.StudentId);
            modelBuilder.Entity<Teacher>().HasMany(a => a.courses).WithOne(a => a.Teacher).HasForeignKey(a => a.TeatcherId);
            modelBuilder.Entity<Student>().HasOne(a => a.StudentProfile).WithOne(a => a.Student).HasForeignKey<StudentProfile>(a => a.StudentId);
            modelBuilder.Entity<Enrollment>().HasIndex(a => new { a.StudentId, a.CourceId }).IsUnique();

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FullName = "Rofaida Hamada",
                Email = "Rofa@gmail.com",
                Phone = "01005605262",
                BirthDate = new DateTime(2023, 5, 1),
                Gender = "Femal"
            },
            new Student
            {
                Id = 2,
                FullName = "Retaj Hany",
                Email = "Retaa@gmail.com",
                Phone = "0107545262",
                BirthDate = new DateTime(2027, 7, 27),
                Gender = "Femal"

            });


            modelBuilder.Entity<StudentProfile>().HasData(new StudentProfile
            {
                Id = 1,
                Address = "Ciyro",
                ParentPhone = "265764764",
                EmergencyContact = "65356788",
                StudentId = 1
            },
            new StudentProfile
            {
                Id = 2,
                Address = "Giza",
                ParentPhone = "7777764764",
                EmergencyContact = "55556788",
                StudentId = 2
            }

            );
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 1,
                FullName = "Dina El-Sayed",
                Email = "Dena@gmail.com",
                Phone = "0100567892",
                HireDate = new DateTime(2024, 7, 6)
            },
            new Teacher
            {
                Id = 2,
                FullName = "Fady El-Hosseny",
                Email = "Fady@gmail.com",
                Phone = "096657892",
                HireDate = new DateTime(2023, 9, 1)
            }

            );

            modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Title = "Cs",
                CreditHours = 6,
                TeatcherId = 1
            },
            new Course
            {
                Id = 2,
                Title = "Es",
                CreditHours = 5,
                TeatcherId = 2
            });


            modelBuilder.Entity<Enrollment>().HasData(new Enrollment
            {
                Id = 1,
                StudentId = 1,
                CourceId = 1,
                EnrollmentDate = new DateTime(2024, 7, 6),
                Grade = 90.12
            },
            new Enrollment
            {
                Id = 2,
                StudentId = 1,
                CourceId = 2,
                EnrollmentDate = new DateTime(2023, 9, 1),
                Grade = null
            }

                );

            } 
    }
}
