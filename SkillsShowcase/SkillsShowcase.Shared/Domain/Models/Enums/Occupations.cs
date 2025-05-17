using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum Occupations
    {
        [Description("")]
        NoOccupation,

        [Description("Software Developer")]
        SoftwareDeveloper,

        [Description("Registered Nurse")]
        RegisteredNurse,

        [Description("Electrician")]
        Electrician,

        [Description("Teacher")]
        Teacher,

        [Description("Plumber")]
        Plumber,

        [Description("Police Officer")]
        PoliceOfficer,

        [Description("Administrative Assistant")]
        AdministrativeAssistant,

        [Description("Construction Worker")]
        ConstructionWorker,

        [Description("Truck Driver")]
        TruckDriver,

        [Description("Marketing Manager")]
        MarketingManager,

        [Description("HVAC Technician")]
        HvacTechnician,

        [Description("Graphic Designer")]
        GraphicDesigner,

        [Description("Financial Analyst")]
        FinancialAnalyst,

        [Description("Customer Service Representative")]
        CustomerServiceRep,

        [Description("Freelance Writer")]
        FreelanceWriter
    }
}
