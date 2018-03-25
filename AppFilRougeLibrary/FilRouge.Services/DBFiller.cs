using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FilRouge.Services;
using FilRouge.Entities.Entity;
using System.Collections;
using System.Collections.Generic;

namespace FilRouge.Services
{
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
            dbContext.DifficultyRates.Add(DifficultyRate1)
            dbContext.SaveChanges();
            dbContext.Dispose();
        }
    }
}
