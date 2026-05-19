using Microsoft.EntityFrameworkCore; // <-- Crucial using directive
using HRManager.Models;

namespace HRManager.Data
{
    public class HRManagerDbContext : DbContext
    {
        // Modern .NET 9 constructor
        public HRManagerDbContext(DbContextOptions<HRManagerDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParentInformation> ParentInformations { get; set; }
        public DbSet<SocialMediaInformation> SocialMediaInformations { get; set; }
        public DbSet<EmploymentDetails> EmploymentDetails { get; set; }
        public DbSet<AddressInformation> AddressInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure 1-to-1 relationships and disable cascade delete
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ParentInformation)
                .WithOne(p => p.Employee)
                .HasForeignKey<ParentInformation>(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.SocialMediaInformation)
                .WithOne(s => s.Employee)
                .HasForeignKey<SocialMediaInformation>(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmploymentDetails)
                .WithOne(em => em.Employee)
                .HasForeignKey<EmploymentDetails>(em => em.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.AddressInformation)
                .WithOne(a => a.Employee)
                .HasForeignKey<AddressInformation>(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}