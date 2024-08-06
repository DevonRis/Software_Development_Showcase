using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Api.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSecretKey> EmployeeSecretKeys { get; set; }
        public DbSet<DcVillains> DcVillains { get; set; }
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
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 1,
                VillanName = "Joker",
                VillanPower = "None/Cunning",
                VillanAge = 43,
                Weaknesses = "None",
                CityLocation = "Gotham",
                ThreatLevel = ThreatLevel.SEVERE,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 2,
                VillanName = "Darkseid",
                VillanPower = "SuperStrength/CosmicPowers",
                VillanAge = 1000,
                Weaknesses = "None/Superman",
                CityLocation = "Apokolips",
                ThreatLevel = ThreatLevel.CRITICAL,
                PlacedInArkham = ArkhamAsylum.NotPossible,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 3,
                VillanName = "Lex Luthor",
                VillanPower = "Genius Intellect",
                VillanAge = 44,
                Weaknesses = "None/Regular Human/Superman",
                CityLocation = "Metropolis",
                ThreatLevel = ThreatLevel.SUBSTANTIAL,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 4,
                VillanName = "DeathStroke",
                VillanPower = "Enhanced Human",
                VillanAge = 58,
                Weaknesses = "None",
                CityLocation = "Gothom",
                ThreatLevel = ThreatLevel.SURVEILLANCE,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 5,
                VillanName = "Two-Face",
                VillanPower = "None",
                VillanAge = 49,
                Weaknesses = "None",
                CityLocation = "Gothom",
                ThreatLevel = ThreatLevel.SURVEILLANCE,
                PlacedInArkham = ArkhamAsylum.Stationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 6,
                VillanName = "Braniac",
                VillanPower = "Genius Intellect/Cosmic Powers",
                VillanAge = 1000,
                Weaknesses = "None/Superman",
                CityLocation = "Unknown",
                ThreatLevel = ThreatLevel.CRITICAL,
                PlacedInArkham = ArkhamAsylum.NotPossible,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 7,
                VillanName = "Riddler",
                VillanPower = "None",
                VillanAge = 37,
                Weaknesses = "None",
                CityLocation = "Gothom",
                ThreatLevel = ThreatLevel.SURVEILLANCE,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 8,
                VillanName = "Sinestro",
                VillanPower = "Yellow Lantern Ring",
                VillanAge = 59,
                Weaknesses = "Removal of Ring",
                CityLocation = "Space",
                ThreatLevel = ThreatLevel.SUBSTANTIAL,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 9,
                VillanName = "Doomsday",
                VillanPower = "SuperStrength/Invulnerable",
                VillanAge = 1000,
                Weaknesses = "None/Superman",
                CityLocation = "Unknown",
                ThreatLevel = ThreatLevel.CRITICAL,
                PlacedInArkham = ArkhamAsylum.NotPossible,
                SupermanLevelVillan = null,
            });
            modelBuilder.Entity<DcVillains>().HasData(new DcVillains
            {
                DcVillanId = 10,
                VillanName = "Professor Zoom",
                VillanPower = "Reverse Speed Force",
                VillanAge = 40,
                Weaknesses = "None/Superman",
                CityLocation = "Star City",
                ThreatLevel = ThreatLevel.CRITICAL,
                PlacedInArkham = ArkhamAsylum.NotStationed,
                SupermanLevelVillan = null,
            });
        }
    }
}
