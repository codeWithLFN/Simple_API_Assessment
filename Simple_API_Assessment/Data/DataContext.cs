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

        // Seed data to the database when the application starts
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().HasData(
                new Applicant { Id = 1, Name = "Lufuno Nemudivhadi" },
                new Applicant { Id = 2, Name = "Ofentse Sithole" }
            );

            
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "Java" },
                new Skill { Id = 3, Name = "Python" }
            );

            // Configure the relationship between Applicant and Skill
            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Applicant)
                .WithMany(a => a.Skills)
                .HasForeignKey(s => s.ApplicantId);

        }
    }
}