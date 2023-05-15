using Microsoft.EntityFrameworkCore;


namespace student_status_server.Models
{
    public class StudentStatusDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public StudentStatusDbContext(DbContextOptions<StudentStatusDbContext> options) : base(options) { }
    }
}
