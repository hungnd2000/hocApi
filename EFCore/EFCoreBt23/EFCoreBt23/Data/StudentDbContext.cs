using EFCoreBt23.Data.EntityTypeConfigurations;
using EFCoreBt23.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBt23.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Mark> marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MarkEntityTypeConfiguration());
        }
    }


}
