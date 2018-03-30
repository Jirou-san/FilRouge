namespace FilRouge.Services
{
    using FilRouge.Model.Entities;

    /// <summary>
    /// Cette classe sert uniquement à ajouter des données brutes dans la base de donnée
    /// </summary>
    public sealed class DBFiller
    {
        static Contact Contact = new Contact
        {
            Name = "Admin",
            Prenom = "Nico",
            Tel = "0000000000",
            Email = "test@test.fr",
            Type = "admin"

        };

        static Technology Technologie = new Technology
        {
            TechnoName = "C#",
            Active = true
        };
        static Technology Technologie1 = new Technology
        {
            TechnoName = "Java",
            Active = true
        };

        static Difficulty Difficult1 = new Difficulty
        {
            DifficultyName = "Junior",

        };
        static Difficulty Difficult2 = new Difficulty
        {
            DifficultyName = "Confirmed",

        };
        static Difficulty Difficult3 = new Difficulty
        {
            DifficultyName = "Expert",

        };
        static DifficultyMaster DifficultyMaster1 = new DifficultyMaster
        {
            DiffMasterName = "Junior",

        };
        static DifficultyMaster DifficultyMaster2 = new DifficultyMaster
        {
            DiffMasterName = "Confirmed",

        };
        static DifficultyMaster DifficultyMaster3 = new DifficultyMaster
        {
            DiffMasterName = "Expert",

        };
        static  DifficultyRate DifficultyRate1 = new DifficultyRate
        {
            Difficulty = Difficult1,
            DifficultyId = Difficult1.DifficultyId,
            DifficultyMaster = DifficultyMaster1,
            DifficultyMasterId = DifficultyMaster1.DiffMasterId,
            Rate = 0.70M

        };
        static DifficultyRate DifficultyRate2 = new DifficultyRate
        {
            Difficulty = Difficult2,
            DifficultyId = Difficult2.DifficultyId,
            DifficultyMaster = DifficultyMaster1,
            DifficultyMasterId = DifficultyMaster1.DiffMasterId,
            Rate = 0.20M

        };
        static DifficultyRate DifficultyRate3 = new DifficultyRate
        {
            Difficulty = Difficult3,
            DifficultyId = Difficult3.DifficultyId,
            DifficultyMaster = DifficultyMaster1,
            DifficultyMasterId = DifficultyMaster1.DiffMasterId,
            Rate = 0.10M

        };
        static DifficultyRate DifficultyRate4 = new DifficultyRate
        {
            Difficulty = Difficult1,
            DifficultyId = Difficult1.DifficultyId,
            DifficultyMaster = DifficultyMaster2,
            DifficultyMasterId = DifficultyMaster2.DiffMasterId,
            Rate = 0.25M

        };
        static DifficultyRate DifficultyRate5 = new DifficultyRate
        {
            Difficulty = Difficult2,
            DifficultyId = Difficult2.DifficultyId,
            DifficultyMaster = DifficultyMaster2,
            DifficultyMasterId = DifficultyMaster2.DiffMasterId,
            Rate = 0.50M

        };
        static DifficultyRate DifficultyRate6 = new DifficultyRate
        {
            Difficulty = Difficult3,
            DifficultyId = Difficult3.DifficultyId,
            DifficultyMaster = DifficultyMaster2,
            DifficultyMasterId = DifficultyMaster2.DiffMasterId,
            Rate = 0.25M

        };
        static DifficultyRate DifficultyRate7 = new DifficultyRate
        {
            Difficulty = Difficult1,
            DifficultyId = Difficult1.DifficultyId,
            DifficultyMaster = DifficultyMaster3,
            DifficultyMasterId = DifficultyMaster3.DiffMasterId,
            Rate = 0.10M

        };
        static DifficultyRate DifficultyRate8 = new DifficultyRate
        {
            Difficulty = Difficult2,
            DifficultyId = Difficult2.DifficultyId,
            DifficultyMaster = DifficultyMaster3,
            DifficultyMasterId = DifficultyMaster3.DiffMasterId,
            Rate = 0.40M

        };
        static DifficultyRate DifficultyRate9 = new DifficultyRate
        {
            Difficulty = Difficult3,
            DifficultyId = Difficult3.DifficultyId,
            DifficultyMaster = DifficultyMaster3,
            DifficultyMasterId = DifficultyMaster3.DiffMasterId,
            Rate = 0.50M

        };
        static TypeQuestion TypeQuestion1 = new TypeQuestion
        {
            NameType = "Choix unique"
        };
        static TypeQuestion TypeQuestion2 = new TypeQuestion
        {
            NameType = "Choix multiple"
        };
        static TypeQuestion TypeQuestion3 = new TypeQuestion
        {
            NameType = "Choix libre"
        };
        public static void AddDatas()
        {
            FilRougeDBContext dbContext = new FilRougeDBContext();
            dbContext.Contact.Add(Contact);
            dbContext.Technologies.Add(Technologie1);
            dbContext.Technologies.Add(Technologie);
            dbContext.Difficulties.Add(Difficult1);
            dbContext.Difficulties.Add(Difficult2);
            dbContext.Difficulties.Add(Difficult3);
            dbContext.DifficultyMasters.Add(DifficultyMaster1);
            dbContext.DifficultyMasters.Add(DifficultyMaster2);
            dbContext.DifficultyMasters.Add(DifficultyMaster3);
            dbContext.DifficultyRates.Add(DifficultyRate1);
            dbContext.DifficultyRates.Add(DifficultyRate2);
            dbContext.DifficultyRates.Add(DifficultyRate3);
            dbContext.DifficultyRates.Add(DifficultyRate4);
            dbContext.DifficultyRates.Add(DifficultyRate5);
            dbContext.DifficultyRates.Add(DifficultyRate6);
            dbContext.DifficultyRates.Add(DifficultyRate7);
            dbContext.DifficultyRates.Add(DifficultyRate8);
            dbContext.DifficultyRates.Add(DifficultyRate9);
            dbContext.TypeQuestion.Add(TypeQuestion1);
            dbContext.TypeQuestion.Add(TypeQuestion2);
            dbContext.TypeQuestion.Add(TypeQuestion3);
            dbContext.SaveChanges();
            dbContext.Dispose();
        }
    }
}
