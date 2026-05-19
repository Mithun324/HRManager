using Microsoft.EntityFrameworkCore;
using HRManager.Models;

namespace HRManager.Data
{
    public class HRManagerDbContext : DbContext
    {
        public HRManagerDbContext(DbContextOptions<HRManagerDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParentInformation> ParentInformations { get; set; }
        public DbSet<SocialMediaInformation> SocialMediaInformations { get; set; }
        public DbSet<EmploymentDetails> EmploymentDetails { get; set; }
        public DbSet<AddressInformation> AddressInformations { get; set; }
        public DbSet<TaxInformation> TaxInformations { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }


        // FIX: Add this line so the DbContext recognizes your Education table!
        public DbSet<EducationInformation> EducationInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Existing relationship mappings...
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
                .HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}