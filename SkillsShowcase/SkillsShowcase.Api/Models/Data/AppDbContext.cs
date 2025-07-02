using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;

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
        public DbSet<FavoriteMusicians> FavoriteMusicians { get; set; }
        public DbSet<NarutoCharacters> NarutoCharacters { get; set; }
        public DbSet<NarutoCharacterDetails> NarutoCharacterDetails { get; set; }
        public DbSet<GuitarManufactureDetails> GuitarManufactureDetails { get; set; }
        public DbSet<Assassins> Assassins { get; set; }
        public DbSet<AssassinsDetails> AssassinsDetails { get; set; }
        public DbSet<UsDemographics> UsDemographics { get; set; }

        public async Task<List<AssassinsDetails>> AssignAssassinAsync(GetAssassinRequest request)
        {
            var parameters = new[]
            {
                new SqlParameter("@FirstName", request.FirstName),
                new SqlParameter("@LastName", request.LastName),
                new SqlParameter("@Age", request.Age),
                new SqlParameter("@Height", request.Height),
                new SqlParameter("@RegisteredDate", request.RegisterDate),
                new SqlParameter("@State", request.State),
                new SqlParameter("@MartialArt", request.PerferedMartialArt),
                new SqlParameter("@Weapon", request.PerferedWeapon)
            };
            return await AssassinsDetails.FromSqlRaw("EXEC [dbo].[AssignAssassin] @FirstName, @LastName, @Age, @Height, @RegisteredDate, @State, @MartialArt, @Weapon", parameters).ToListAsync();
        }
        public async Task<List<SearchRatesWithEFLDetails_Result>> SearchRatesWithEFLDetailsAsync(int? tDSPId, int? rEPId, decimal? averagePricePer500kWh, decimal? averagePricePer1000kWh, decimal? averagePricePer2000kWh, int? lengthOfTerm, string eFLTypeProduct, decimal? averagePricePerKwhTolerance)
        {
            var parameters = new[]
            {
                new SqlParameter("@TDSPId", tDSPId ?? (object)DBNull.Value),
                new SqlParameter("@REPId", rEPId ?? (object)DBNull.Value),
                new SqlParameter("@AveragePricePer500kWh", averagePricePer500kWh ?? (object)DBNull.Value),
                new SqlParameter("@AveragePricePer1000kWh", averagePricePer1000kWh ?? (object)DBNull.Value),
                new SqlParameter("@AveragePricePer2000kWh", averagePricePer2000kWh ?? (object)DBNull.Value),
                new SqlParameter("@LengthOfTerm", lengthOfTerm ?? (object)DBNull.Value),
                new SqlParameter("@EFLTypeProduct", eFLTypeProduct ?? (object)DBNull.Value),
                new SqlParameter("@AveragePricePerKwhTolerance", averagePricePerKwhTolerance ?? (object)DBNull.Value)
            };

            return await this.Set<SearchRatesWithEFLDetails_Result>()
                .FromSqlRaw("EXEC [dbo].[SearchRatesWithEFLDetails] @TDSPId, @REPId, @AveragePricePer500kWh, @AveragePricePer1000kWh, @AveragePricePer2000kWh, @LengthOfTerm, @EFLTypeProduct, @AveragePricePerKwhTolerance", parameters)
                .ToListAsync();
        }
        public async Task<InvestmentResultsFromApi[]?> GetInvestmentResults(InvestmentResultsRequest request)
        {
            var parameters = new[]
            {
                new SqlParameter("@CurrentAge", request.CurrentAge),
                new SqlParameter("@RetirementAge", request.RetirementAge),
                new SqlParameter("@Salary", request.Salary),
                new SqlParameter("@SalaryGrowthRate", request.SalaryGrowthRate),
                new SqlParameter("@InitialInvestment", request.InitialInvestment),
                new SqlParameter("@MonthlyContribution", request.MonthlyContribution),
                new SqlParameter("@AnnualReturn", request.AnnualReturn),
                new SqlParameter("@MonthlyLivingExpenses", request.MonthlyLivingExpenses),
                new SqlParameter("@GoalAmount", request.GoalAmount)
            };

            return await this.Set<InvestmentResultsFromApi>()
                .FromSqlRaw("EXEC [dbo].[InvestmentsCalculator] @CurrentAge, @RetirementAge, @Salary, @SalaryGrowthRate, @InitialInvestment, @MonthlyContribution, @AnnualReturn, @MonthlyLivingExpenses, @GoalAmount", parameters)
                .ToArrayAsync();
        }
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
            modelBuilder.Entity<NarutoCharacterDetails>()
                .HasOne<NarutoCharacters>()
                .WithMany(c => c.NarutoCharacterDetails)
                .HasForeignKey(d => d.NarutoCharacterId)
                .HasConstraintName("FK_NarutoCharacters_NarutoCharacterDetails");
            modelBuilder.Entity<InvestmentResultsFromApi>().HasNoKey();

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
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 1,
                CharacterName = "Naruto Uzumaki",
                ClanBloodline = "Uzumaki",
                Age = 35,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 2,
                CharacterName = "Sasuke Uchiha",
                ClanBloodline = "Uchiha",
                Age = 36,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 3,
                CharacterName = "Sakura Haruno",
                ClanBloodline = "None",
                Age = 33,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 4,
                CharacterName = "Kakashi Hatake",
                ClanBloodline = "Hatake",
                Age = 50,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 5,
                CharacterName = "Minato Namikaze",
                ClanBloodline = "None",
                Age = 34,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 6,
                CharacterName = "Madara Uchiha",
                ClanBloodline = "Uchiha",
                Age = 41,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 7,
                CharacterName = "Jiraiya",
                ClanBloodline = "None",
                Age = 55,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 8,
                CharacterName = "Onoki",
                ClanBloodline = "None",
                Age = 93,
                Village = NarutoVillages.HiddenStoneVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 9,
                CharacterName = "Zabuza Momochi",
                ClanBloodline = "None",
                Age = 29,
                Village = NarutoVillages.HiddenMistVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 10,
                CharacterName = "Killer Bee",
                ClanBloodline = "None",
                Age = 47,
                Village = NarutoVillages.HiddenCloudVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 11,
                CharacterName = "Gaara",
                ClanBloodline = "None",
                Age = 37,
                Village = NarutoVillages.HiddenSandVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 12,
                CharacterName = "Pain",
                ClanBloodline = "None",
                Age = 40,
                Village = NarutoVillages.HiddenRainVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 13,
                CharacterName = "Orochimaru",
                ClanBloodline = "None",
                Age = 79,
                Village = NarutoVillages.HiddenSoundVillage,
            });
            modelBuilder.Entity<NarutoCharacters>().HasData(new NarutoCharacters
            {
                NarutoCharacterId = 14,
                CharacterName = "Kurama",
                ClanBloodline = "None",
                Age = 200,
                Village = NarutoVillages.HiddenLeafVillage,
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 1,
                Status = NarutoCharacterStatus.Hokage,
                CharacterBio = "Naruto Uzumaki is the main character of the Naruto series. He is a ninja from the Hidden Leaf Village and current Hokage.",
                KillCount = 50
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 2,
                Status = NarutoCharacterStatus.Akatsuki,
                CharacterBio = "Sasuke Uchiha is a rogue ninja from the Hidden Leaf Village. He is a former member of Team 7 and is known for his Sharingan.",
                KillCount = 100
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 3,
                Status = NarutoCharacterStatus.Jonin,
                CharacterBio = "Sakura Haruno is a ninja from the Hidden Leaf Village. She is a medical ninja and a member of Team 7.",
                KillCount = 10
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 4,
                Status = NarutoCharacterStatus.Hokage,
                CharacterBio = "Kakashi Hatake is a former Hokage of the Hidden Leaf Village. He is known as the Copy Ninja.",
                KillCount = 200
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 5,
                Status = NarutoCharacterStatus.Hokage,
                CharacterBio = "Minato Namikaze is the Fourth Hokage of the Hidden Leaf Village. He is known as the Yellow Flash.",
                KillCount = 300
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 6,
                Status = NarutoCharacterStatus.Akatsuki,
                CharacterBio = "Madara Uchiha is a rogue ninja from the Hidden Leaf Village. He is known as the founder of the Uchiha clan.",
                KillCount = 1000
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 7,
                Status = NarutoCharacterStatus.LegendarySanin,
                CharacterBio = "Jiraiya is one of the Legendary Sannin of the Hidden Leaf Village. He is known as the Toad Sage.",
                KillCount = 500
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 8,
                Status = NarutoCharacterStatus.Tsuchikage,
                CharacterBio = "Onoki is the Third Tsuchikage of the Hidden Stone Village. He is known as the Dust Release user.",
                KillCount = 400
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 9,
                Status = NarutoCharacterStatus.Jonin,
                CharacterBio = "Zabuza Momochi is a rogue ninja from the Hidden Mist Village. He is known as the Demon of the Hidden Mist.",
                KillCount = 300
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 10,
                Status = NarutoCharacterStatus.Jinchuriki,
                CharacterBio = "Killer Bee is the Eight Tails Jinchuriki of the Hidden Cloud Village. He is known as the Eight Tails Host.",
                KillCount = 200
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 11,
                Status = NarutoCharacterStatus.Kazekage,
                CharacterBio = "Gaara is the Fifth Kazekage of the Hidden Sand Village. He is known as the One-Tail Jinchuriki.",
                KillCount = 150
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 12,
                Status = NarutoCharacterStatus.Akatsuki,
                CharacterBio = "Pain is the leader of the Akatsuki organization. He is known as the Deva Path.",
                KillCount = 900
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 13,
                Status = NarutoCharacterStatus.LegendarySanin,
                CharacterBio = "Orochimaru is a rogue ninja from the Hidden Sound Village. He is known as the Snake Sannin.",
                KillCount = 700
            });
            modelBuilder.Entity<NarutoCharacterDetails>().HasData(new NarutoCharacterDetails
            {
                NarutoCharacterId = 14,
                Status = NarutoCharacterStatus.Jinchuriki,
                CharacterBio = "Kurama is the Nine Tails Bijuu of the Hidden Leaf Village. He is known as the Nine Tails Fox.",
                KillCount = 5000
            });
            modelBuilder.Entity<GuitarManufactureDetails>().HasData(new GuitarManufactureDetails
            {
                GuitarManufacturerId = 1,
                ManufacturerName = "Fender",
                Location = "Los Angeles, CA",
                ContactNumber = "718-536-9997",
                Email = "contact@Fender.com",
                Website = "www.fender.com",
                DateEstablished = new DateTime(1946, 1, 10)
            });
            modelBuilder.Entity<GuitarManufactureDetails>().HasData(new GuitarManufactureDetails
            {
                GuitarManufacturerId = 2,
                ManufacturerName = "Gibson",
                Location = "Nashville, TN",
                ContactNumber = "1-800-444-2766",
                Email = "service@gibson.com",
                Website = "www.gibson.com",
                DateEstablished = new DateTime(1902, 6, 10)
            });
            modelBuilder.Entity<GuitarManufactureDetails>().HasData(new GuitarManufactureDetails
            {
                GuitarManufacturerId = 3,
                ManufacturerName = "PaulReedSmith",
                Location = "Stevensville, MD",
                ContactNumber = "410-643-9970",
                Email = "info@prsguitars.com",
                Website = "www.prsguitars.com",
                DateEstablished = new DateTime(1985, 4, 13)
            });
            modelBuilder.Entity<GuitarManufactureDetails>().HasData(new GuitarManufactureDetails
            {
                GuitarManufacturerId = 4,
                ManufacturerName = "Ibanez",
                Location = "Nagoya, Japan",
                ContactNumber = "81-52-211-9611",
                Email = "contact@ibanez.com",
                Website = "www.ibanez.com",
                DateEstablished = new DateTime(1957, 2, 15)
            });
            modelBuilder.Entity<Assassins>().HasData(new Assassins
            {
                AssassinId = 1,
                FirstName = "Ezio",
                LastName = "Lorenzo",
                Age = ContinentalAgeRange.Forty,
                Height = "5'10",
                RegisteredDate = new DateTime(2024, 1, 10),
                State = AllFiftyStates.NY,
                MartialArt = MartialArts.MixedMartialArts,
                Weapon = Weapons.Glock19,
            });
            modelBuilder.Entity<AssassinsDetails>().HasData(new AssassinsDetails
            {
                AssignableAssassinId = 1,
                AssassinName = "John Wick",
                MartialArtKnowledge = "Brazilian Jiu-Jitsu, Karate",
                WeaponsKnowledge = "Pistol, Revolver",
                DesignatedRegion = "AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA"
            });
            modelBuilder.Entity<AssassinsDetails>().HasData(new AssassinsDetails
            {
                AssignableAssassinId = 2,
                AssassinName = "Common Jones",
                MartialArtKnowledge = "Taekwondo, Boxing",
                WeaponsKnowledge = "Knife, Battle axe",
                DesignatedRegion = "HI, ID, IL, IN, IA, KS, KY, LA, ME, MD"
            });
            modelBuilder.Entity<AssassinsDetails>().HasData(new AssassinsDetails
            {
                AssignableAssassinId = 3,
                AssassinName = "Cain Chow",
                MartialArtKnowledge = "Muay Thai, Krav Maga",
                WeaponsKnowledge = "Katana, Longsword",
                DesignatedRegion = "MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ"
            });
            modelBuilder.Entity<AssassinsDetails>().HasData(new AssassinsDetails
            {
                AssignableAssassinId = 4,
                AssassinName = "Ares",
                MartialArtKnowledge = "Eskrima, Capoeira",
                WeaponsKnowledge = "Recurve bow, Crossbow",
                DesignatedRegion = "NM, NY, NC, ND, OH, OK, OR, PA, RI, SC"
            });
            modelBuilder.Entity<AssassinsDetails>().HasData(new AssassinsDetails
            {
                AssignableAssassinId = 5,
                AssassinName = "Mr Nobody",
                MartialArtKnowledge = "Mixed Martial Arts, Judo",
                WeaponsKnowledge = "Sniper rifle, Shotgun",
                DesignatedRegion = "SD, TN, TX, UT, VT, VA, WA, WV, WI, WY"
            });
            modelBuilder.Entity<UsDemographics>().HasData(new UsDemographics
            {
                Id = 1,
                TotalPopulation = 347000000,
                WhitesPopulation = 0.577m,
                HispanicsPopulation = 0.191m,
                AsiansPopulation = 0.058m,
                AfricanAmericanPopulation = 0.121m,
                BlackMenPopulation = 0.0585m,
                BlackWomenPopulation = 0.0634m,
                BlackMenWithBachelors = 0.236m,
                BlackWomenWithBachelors = 0.301m,
                BlackMenWithGradDegrees = 0.083m,
                BlackWomenWithGradDegrees = 0.112m,
                WhitesWithBachelors = 0.420m,
                WhitesWithGradDegrees = 0.170m,
                HispanicsWithBachelors = 0.220m,
                HispanicsWithGradDegrees = 0.080m,
                AsiansWithBachelors = 0.710m,
                AsiansWithGradDegrees = 0.300m,
                WhiteHouseHoldsThatsMarried = 0.525m,
                BlackHouseHoldsThatsMarried = 0.307m,
                HispanicHouseHoldsThatsMarried = 0.465m,
                AsianHouseHoldsThatsMarried = 0.610m,
                WhiteUpperMiddleClassPercentage = 0.265m,
                BlackUpperMiddleClassPercentage = 0.074m,
                HispanicUpperMiddleClassPercentage = 0.065m,
                AsianUpperMiddleClassPercentage = 0.285m,
                WhiteLowerMiddleClassPercentage = 0.320m,
                BlackLowerMiddleClassPercentage = 0.280m,
                HispanicLowerMiddleClassPercentage = 0.300m,
                AsianLowerMiddleClassPercentage = 0.230m
            });
        }
    }
}