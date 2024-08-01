using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSecretKey> EmployeeSecretKeys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Devon",
                LastName = "Rismay",
                Email = "Devonpaniccia@gmail.com",
                PhoneNumber = "8322156677",
                MaritalStatus = MaritalStatus.Married,
                Gender = Gender.Male,
            });
            modelBuilder.Entity<EmployeeSecretKey>().HasData(new EmployeeSecretKey 
            { 
                Id = 1,
                EmployeeName = "Devon Rismay",
                SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5555",
            });
            modelBuilder.Entity<EmployeeSecretKey>().HasData(new EmployeeSecretKey
            {
                Id = 2,
                EmployeeName = "John Hull",
                SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5554",
            });
            modelBuilder.Entity<EmployeeSecretKey>().HasData(new EmployeeSecretKey
            {
                Id = 3,
                EmployeeName = "Quinshae Hopkins",
                SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5553",
            });
            modelBuilder.Entity<EmployeeSecretKey>().HasData(new EmployeeSecretKey
            {
                Id = 4,
                EmployeeName = "Robert Pyron",
                SecretKey = "Auth-234252-rgsdfg4553-234dsdf-5552",
            });
        }
    }
}
