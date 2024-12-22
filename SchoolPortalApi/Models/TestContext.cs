using Microsoft.EntityFrameworkCore;
    namespace SchoolPortalApi.Models
{
    public class TestContext: DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
    : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; } = default!;  // Admin is call entity while admins is the table name
        public DbSet<Registration> Registrations { get; set; } = default!;
        public DbSet<School> Schools { get; set; } = default!;
        public DbSet<Exam> Exams { get; set; } = default!;
        public DbSet<AdmittedStudent> AdmittedStudents { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet <WaitingList> WaitingLists { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        
    }
}
