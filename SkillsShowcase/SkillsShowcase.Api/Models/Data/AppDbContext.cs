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
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 2,
                FirstName = "John",
                LastName = "Hull",
                Email = "Johnhull@gmail.com",
                PhoneNumber = "8322156676",
                MaritalStatus = MaritalStatus.Married,
                Gender = Gender.Male,
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Robert",
                LastName = "Pyron",
                Email = "RobertPyron@gmail.com",
                PhoneNumber = "8322156675",
                MaritalStatus = MaritalStatus.Single,
                Gender = Gender.Male,
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 4,
                FirstName = "Walter",
                LastName = "Bryant",
                Email = "WalterBryant@gmail.com",
                PhoneNumber = "8322156674",
                MaritalStatus = MaritalStatus.Single,
                Gender = Gender.Male,
            });
        }
    }
}
