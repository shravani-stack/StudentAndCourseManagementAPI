using Microsoft.EntityFrameworkCore;
using StudentAndCourseManagementAPI.Model;

namespace StudentAndCourseManagementAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(y => y.StudentCourse)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(z => z.StudentCourse)
                .HasForeignKey(x =>x.CourseId);

            //base.OnModelCreating(modelBuilder);
        }

    }
}
