using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum  CarModels
    {
        [Description("Infinity Q60")]
        InfinityQ60 = 60,
        [Description("Ford Mustang Dark Horse")]
        FordMustangDarkHorse = 350,
        [Description("Chevrolet Camaro")]
        ChevroletCamaro = 400,
        [Description("Dodge Challenger")]
        DodgeChallenger = 90,
        [Description("Toyota Supra")]
        ToyotaSupra = 100,
        [Description("Nissan 370Z")]
        Nissan370Z = 120,
        [Description("Aston Martin DB12")]
        AstonMartinDB12 = 80,
        [Description("Porsche 911")]
        Porsche911 = 150,
        [Description("BMW M4")]
        BMWM4 = 200,
        [Description("Mercedes Benz AMG GT")]
        MercedesBenzAMGGT = 250,
        [Description("Audi R8")]
        AudiR8 = 300,
        [Description("Lamborghini Huracan")]
        LamborghiniHuracan = 500,
        [Description("Ferrari 488 GTB")]
        Ferrari488GTB = 600,
    }
}
