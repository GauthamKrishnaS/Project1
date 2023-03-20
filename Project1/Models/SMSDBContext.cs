using Microsoft.EntityFrameworkCore;

namespace Project1.Models {
    public class SMSDBContext : DbContext {

        public SMSDBContext(DbContextOptions<SMSDBContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}