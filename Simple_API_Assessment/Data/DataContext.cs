using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }

        // define the relationship between the Applicant and Skill entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
              .HasMany(a => a.Skills)
              .WithOne(s => s.Applicant)
              .HasForeignKey(s => s.ApplicantId);
        }
    }
}