using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Api.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() 
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSecretKey> EmployeeSecretKeys { get; set; }
        public DbSet<DcVillains> DcVillains { get; set; }
        public DbSet<Guitars> Guitars { get; set; }
        public DbSet<SessionLogs> SessionLogs { get; set; }
        public DbSet<CarPurchaseEventTypes> CarPurchaseEventTypes { get; set; }
        public DbSet<CarPurchaseInfoLog> CarPurchaseInfoLogs { get; set; }
        public DbSet<FirstQuarterRevenue> FirstQuarterRevenue { get; set; }
        public DbSet<MarvelVillains> MarvelVillains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarPurchaseEventTypes>()
                .Property(e => e.CarPurchaseEventTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<CarPurchaseInfoLog>()
                .HasOne<CarPurchaseEventTypes>()
                .WithMany()
                .HasForeignKey(log => log.CarPurchaseStatus)
                .HasPrincipalKey(e => e.CarPurchaseEventTypeId);

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
                Email = "JohnHull@gmail.com",
                PhoneNumber = "8322156676",
                MaritalStatus = MaritalStatus.Married,
                Gender = Gender.Male,
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Quinshae",
                LastName = "Hopkins",
                Email = "QuinshaeHopkins@gmail.com",
                PhoneNumber = "8322156674",
                MaritalStatus = MaritalStatus.Married,
                Gender = Gender.Female,
            });
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 4,
                FirstName = "Robert",
                LastName = "Pyron",
                Email = "RobertPyron@gmail.com",
                PhoneNumber = "8322156675",
                MaritalStatus = MaritalStatus.Single,
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
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 1,
                GuitarManufacturer = GuitarOptions.Fender,
                GuitarModel = "Custom Shop American Stratocaster",
                GuitarPrice = 5000.23,
                BuildYear = new DateTime(2024, 3, 10)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 2,
                GuitarManufacturer = GuitarOptions.Fender,
                GuitarModel = "Custom Shop American Telecaster",
                GuitarPrice = 4000.45,
                BuildYear = new DateTime(2023, 4, 11)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 3,
                GuitarManufacturer = GuitarOptions.Fender,
                GuitarModel = "Special Edition Telecaster FMT HH",
                GuitarPrice = 1000.55,
                BuildYear = new DateTime(2022, 5, 10)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 4,
                GuitarManufacturer = GuitarOptions.Fender,
                GuitarModel = "Acoustasonic Telecaster",
                GuitarPrice = 1998.63,
                BuildYear = new DateTime(2024, 5, 9)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 5,
                GuitarManufacturer = GuitarOptions.Gibson,
                GuitarModel = "ES-339 Figured Semi-hollowbody",
                GuitarPrice = 3500.89,
                BuildYear = new DateTime(2024, 1, 10)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 6,
                GuitarManufacturer = GuitarOptions.Gibson,
                GuitarModel = "SG Standard 61 Maestro Vibrola",
                GuitarPrice = 2300.23,
                BuildYear = new DateTime(2024, 3, 10)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 7,
                GuitarManufacturer = GuitarOptions.PaulReedSmith,
                GuitarModel = "Silver Sky",
                GuitarPrice = 2749.23,
                BuildYear = new DateTime(2020, 3, 2)
            });
            modelBuilder.Entity<Guitars>().HasData(new Guitars
            {
                GuitarId = 8,
                GuitarManufacturer = GuitarOptions.Ibanez,
                GuitarModel = "Artstar AS2000",
                GuitarPrice = 2600.23,
                BuildYear = new DateTime(2000, 10, 15)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs 
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "01.6.0.20",
                UserAgent = "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 1,
                CreatedTime = new DateTime(2024, 1, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "02.6.0.20",
                UserAgent = "Safari\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 15,
                CreatedTime = new DateTime(2024, 2, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "03.6.0.20",
                UserAgent = "FireFox\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 30,
                CreatedTime = new DateTime(2024, 3, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "04.6.0.20",
                UserAgent = "EnterExplorer\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 23,
                CreatedTime = new DateTime(2024, 4, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "05.6.0.20",
                UserAgent = "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 43,
                CreatedTime = new DateTime(2024, 5, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "06.6.0.20",
                UserAgent = "Windows\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 2,
                CreatedTime = new DateTime(2024, 6, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "07.6.0.20",
                UserAgent = "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 6,
                CreatedTime = new DateTime(2024, 7, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "08.6.0.20",
                UserAgent = "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 33,
                CreatedTime = new DateTime(2024, 8, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "09.6.0.20",
                UserAgent = "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 20,
                CreatedTime = new DateTime(2024, 9, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "10.6.0.20",
                UserAgent = "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 52,
                CreatedTime = new DateTime(2024, 10, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "11.6.0.20",
                UserAgent = "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 10,
                CreatedTime = new DateTime(2024, 11, 10)
            });
            modelBuilder.Entity<SessionLogs>().HasData(new SessionLogs
            {
                SessionId = Guid.NewGuid(),
                IpAddress = "12.6.0.20",
                UserAgent = "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36",
                SessionCountsPerDate = 49,
                CreatedTime = new DateTime(2024, 12, 10)
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CarPurchaseInProcess,
                CarPurchaseEventTypeName = "CarPurchaseInProcess",
                CarPurchaseEventTypeDescription = "Car In process of getting bought but not sold yet."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CreditCheckInReview,
                CarPurchaseEventTypeName = "CreditCheckInReview",
                CarPurchaseEventTypeDescription = "Credit check in review but approved yet."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CreditDeclined,
                CarPurchaseEventTypeName = "CreditDeclined",
                CarPurchaseEventTypeDescription = "Credit has been declined. Customer must purchase in cash."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CreditAccepted,
                CarPurchaseEventTypeName = "CreditAccepted",
                CarPurchaseEventTypeDescription = "Credit has been accepted. Customer can purchase in credit."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CarSold,
                CarPurchaseEventTypeName = "CarsSold",
                CarPurchaseEventTypeDescription = "Car has been sold."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CarPurchaseHold,
                CarPurchaseEventTypeName = "CarsPurchaseHold",
                CarPurchaseEventTypeDescription = "Car cannot be given to customer without full down payment."
            });
            modelBuilder.Entity<CarPurchaseEventTypes>().HasData(new CarPurchaseEventTypes
            {
                CarPurchaseEventTypeId = CarPurchaseEventTypeOption.CarsInRouteForPurchase,
                CarPurchaseEventTypeName = "CarsInRouteForPurchase",
                CarPurchaseEventTypeDescription = "Customer bought car but not yet in physical store."
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 1,
                CarModel = CarModels.InfinityQ60,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2023, 1, 10),
                CarPurchaseDate = new DateTime(2024, 1, 10),
                CarModelPrice = 40000,
                CarModelQuantityLeft = 10,
                CustomerName = "Devon Rismay",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 2,
                CarModel = CarModels.FordMustangDarkHorse,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2023, 2, 10),
                CarPurchaseDate = new DateTime(2024, 2, 10),
                CarModelPrice = 123000,
                CarModelQuantityLeft = 5,
                CustomerName = "John Hull",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 3,
                CarModel = CarModels.AudiR8,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2023, 3, 10),
                CarPurchaseDate = new DateTime(2024, 3, 10),
                CarModelPrice = 92000,
                CarModelQuantityLeft = 2,
                CustomerName = "Quinshae Hopkins",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 4,
                CarModel = CarModels.ChevroletCamaro,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2023, 4, 10),
                CarPurchaseDate = new DateTime(2024, 4, 10),
                CarModelPrice = 65000,
                CarModelQuantityLeft = 3,
                CustomerName = "Robert Pyron",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 5,
                CarModel = CarModels.AstonMartinDB12,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarPurchaseInProcess,
                CarArrivalInDealership = new DateTime(2022, 5, 10),
                CarPurchaseDate = new DateTime(2024, 5, 10),
                CarModelPrice = 236000,
                CarModelQuantityLeft = 2,
                CustomerName = "John Goldeen",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditCheckInReview
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 6,
                CarModel = CarModels.BMWM4,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarPurchaseInProcess,
                CarArrivalInDealership = new DateTime(2020, 2, 10),
                CarPurchaseDate = new DateTime(2024, 2, 10),
                CarModelPrice = 101000,
                CarModelQuantityLeft = 7,
                CustomerName = "Crystal Myrondeen",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 7,
                CarModel = CarModels.Nissan370Z,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarPurchaseHold,
                CarArrivalInDealership = new DateTime(2018, 6, 11),
                CarPurchaseDate = new DateTime(2024, 1, 15),
                CarModelPrice = 95000,
                CarModelQuantityLeft = 9,
                CustomerName = "James Mayfield",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 8,
                CarModel = CarModels.ToyotaSupra,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarsInRouteForPurchase,
                CarArrivalInDealership = new DateTime(2024, 1, 20),
                CarPurchaseDate = new DateTime(2024, 3, 10),
                CarModelPrice = 80000,
                CarModelQuantityLeft = 1,
                CustomerName = "Chris Mayson",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 9,
                CarModel = CarModels.Porsche911,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2024, 1, 5),
                CarPurchaseDate = new DateTime(2024, 1, 10),
                CarModelPrice = 120000,
                CarModelQuantityLeft = 5,
                CustomerName = "Barack Husaine",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 10,
                CarModel = CarModels.MercedesBenzAMGGT,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarPurchaseInProcess,
                CarArrivalInDealership = new DateTime(2016, 1, 10),
                CarPurchaseDate = new DateTime(2024, 10, 12),
                CarModelPrice = 150000,
                CarModelQuantityLeft = 1,
                CustomerName = "Johnson Crayfield",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditCheckInReview
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 11,
                CarModel = CarModels.LamborghiniHuracan,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2019, 1, 10),
                CarPurchaseDate = new DateTime(2024, 10, 12),
                CarModelPrice = 250000,
                CarModelQuantityLeft = 1,
                CustomerName = "Johnson Jones",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 12,
                CarModel = CarModels.Ferrari488GTB,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarSold,
                CarArrivalInDealership = new DateTime(2017, 1, 10),
                CarPurchaseDate = new DateTime(2024, 10, 12),
                CarModelPrice = 300000,
                CarModelQuantityLeft = 1,
                CustomerName = "Eugene Paniccia",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditAccepted
            });
            modelBuilder.Entity<CarPurchaseInfoLog>().HasData(new CarPurchaseInfoLog
            {
                CarPurchaseInfoLogId = 13,
                CarModel = CarModels.DodgeChallenger,
                CarPurchaseStatus = CarPurchaseEventTypeOption.CarPurchaseInProcess,
                CarArrivalInDealership = new DateTime(2015, 1, 10),
                CarPurchaseDate = new DateTime(2023, 1, 12),
                CarModelPrice = 80000,
                CarModelQuantityLeft = 13,
                CustomerName = "Natalie Cyris",
                CustomerCreditStatus = CarPurchaseEventTypeOption.CreditCheckInReview
            });
            modelBuilder.Entity<FirstQuarterRevenue>().HasData(new FirstQuarterRevenue
            {
                FirstQuarterRevenueId = 1,
                MonthRevenue = 4015,
                Month = FirstQuarterRevenueOptions.January,
            });
            modelBuilder.Entity<FirstQuarterRevenue>().HasData(new FirstQuarterRevenue
            {
                FirstQuarterRevenueId = 2,
                MonthRevenue = 10043,
                Month = FirstQuarterRevenueOptions.February,
            });
            modelBuilder.Entity<FirstQuarterRevenue>().HasData(new FirstQuarterRevenue
            {
                FirstQuarterRevenueId = 3,
                MonthRevenue = 7023,
                Month = FirstQuarterRevenueOptions.March,
            });
            modelBuilder.Entity<FirstQuarterRevenue>().HasData(new FirstQuarterRevenue
            {
                FirstQuarterRevenueId = 4,
                MonthRevenue = 9052,
                Month = FirstQuarterRevenueOptions.April,
            });
            modelBuilder.Entity<MarvelVillains>().HasData(new MarvelVillains
            {
                MarvelVillanId = 1,
                VillainName = MarvelVillainsOptions.DoctorDoom,
                VillainConfirmedKills = 1053,
            });
            modelBuilder.Entity<MarvelVillains>().HasData(new MarvelVillains
            {
                MarvelVillanId = 2,
                VillainName = MarvelVillainsOptions.RedSkull,
                VillainConfirmedKills = 850,
            });
            modelBuilder.Entity<MarvelVillains>().HasData(new MarvelVillains
            {
                MarvelVillanId = 3,
                VillainName = MarvelVillainsOptions.Thanos,
                VillainConfirmedKills = 6021,
            });
            modelBuilder.Entity<MarvelVillains>().HasData(new MarvelVillains
            {
                MarvelVillanId = 4,
                VillainName = MarvelVillainsOptions.Loki,
                VillainConfirmedKills = 2022,
            });
            modelBuilder.Entity<MarvelVillains>().HasData(new MarvelVillains
            {
                MarvelVillanId = 5,
                VillainName = MarvelVillainsOptions.GreenGoblin,
                VillainConfirmedKills = 721,
            });
        }
    }
}
