using BuraksRecordShopHRM.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace BuraksRecordShopHRM.Api.Models
{
    public class AppDbContext
        : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Operations
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Englane" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Turkey" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "Portugal" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Spain" });

            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 1, Name = "Reseach Lab" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 2, Name = "Finance" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 3, Name = "IT" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 4, Name = "Shop Assistant" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 5, Name = "Store Staff" });

            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, FirstName = "Junger", LastName = "Klöp", BirthDate = new DateTime(1967, 4, 12), JoinedDate = new DateTime(1990, 1, 8), Email = "junger.clup@buraksrecords.com", CountryId = 1, JobCategoryId = 1,Latitude= 52.52,Longitude= 13.405 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 2, FirstName = "Aleksa", LastName = "Bröger", BirthDate = new DateTime(1974, 1, 11), JoinedDate = new DateTime(2000, 1, 8), Email = "aleksa.broger@buraksrecords.com", CountryId = 1, JobCategoryId = 3, Latitude = 52.52, Longitude = 13.405 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 3, FirstName = "Burak", LastName = "Selim", BirthDate = new DateTime(1976, 4, 12), JoinedDate = new DateTime(2001, 12, 10), Email = "burak.selim@buraksrecords.com", CountryId = 3, JobCategoryId = 2, Latitude = 32.2480, Longitude = 112.9161 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 4, FirstName = "Camelia Oscar De La", LastName = "Fuante Garcia Velazques", BirthDate = new DateTime(1985, 3, 8), JoinedDate = new DateTime(2010, 9, 9), Email = "camelia.veazques@buraksrecords.com", CountryId = 5, JobCategoryId = 4, Latitude = 66.5667, Longitude = 0.0000 });
        }
    }
}
