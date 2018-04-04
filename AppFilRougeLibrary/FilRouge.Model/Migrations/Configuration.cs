namespace FilRouge.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using FilRouge.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<FilRouge.Model.Entities.FilRougeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilRouge.Model.Entities.FilRougeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Difficulty

            var difficult0 = new Difficulty { DifficultyName = "Easy" };
            var difficult1 = new Difficulty { DifficultyName = "Confirmed" };
            var difficult2 = new Difficulty { DifficultyName = "Expert" };
            //Difficulties
            context.Difficulty.AddOrUpdate(x => x.DifficultyId, difficult0, difficult1, difficult2);
            #endregion

            #region Technology
            var technology0 = new Technology { TechnoName = "C#", IsActive = true };
            var technology1 = new Technology { TechnoName = "Java", IsActive = true };
            var technology2 = new Technology { TechnoName = "JavaScript", IsActive = true };
            var technology3 = new Technology { TechnoName = "PhP", IsActive = true };
            var technology4 = new Technology { TechnoName = "F#", IsActive = true };
            var technology5 = new Technology { TechnoName = "VB", IsActive = true };
            var technology6 = new Technology { TechnoName = "Sql", IsActive = true };
            //Technologies
            context.Technology.AddOrUpdate(
                x => x.TechnoId,
                technology0,
                technology1,
                technology2,
                technology3,
                technology4,
                technology5,
                technology6);
            #endregion
            #region Contact

            var contact0 = new Contact
            {
                FirstName = "adminfirstname",
                LastName = "adminlastname",
                Mail = "admin@outlook.fr",
                Phone = "0606060606",
                Type = true
            };
            //Contact
            context.Contact.AddOrUpdate(x => x.UserId, contact0);
            #endregion
            #region TypeQuestion

            var questionType0 = new TypeQuestion { NameType = "Choix Unique" };
            var questionType1 = new TypeQuestion { NameType = "Choix Multiple" };
            var questionType2 = new TypeQuestion { NameType = "Choix Ouvert" };
            //TypeQuestion
            context.TypeQuestion.AddOrUpdate(x => x.TypeQuestionId, questionType0, questionType1, questionType2);
            #endregion

        }
    }
}
