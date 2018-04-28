using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilRouge.Tests
{
    public class DataSetTest
    {

        public bool IsNull()
        {
            int? id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Difficulty
                    .Where(e => e.Name == "Débutant")
                    .Select(e => e.Id).FirstOrDefault();

            }
            if (id == null)
            {
                return true;
            }
           
            return false;
        }

        public void FillAllTables()
        {
            Console.WriteLine("Ajout des rôles");
            AddRoles();
            Console.WriteLine("Ajout des utilisateurs");
            AddUsers();
            Console.WriteLine("Ajout des technologies");
            AddTechnologies();
            Console.WriteLine("Ajout des entêtes de difficulté");
            AddDifficulty();
            Console.WriteLine("Ajout des ratio de difficulté");
            AddDifficultyRates();
            Console.WriteLine("Ajout des questions libres");
            AddFreeQuestions();
            Console.WriteLine("Ajout des questions de QCM");
            AddQCMQuestions();
            Console.WriteLine("Ajout des réponses possibles de QCM");
            AddQCMAnswersChoice();

            Console.WriteLine("\n\n\n Fin traitements\n");
            Console.ReadKey();
        }

        public void AddRoles()
        {
            using (var db = new FilRougeDBContext())
            {
                IdentityRole role0 = new IdentityRole()
                {
                    Name = "None",
                };
                db.Roles.Add(role0);
                IdentityRole role1 = new IdentityRole()
                {
                    Name = "Admin",
                };
                db.Roles.Add(role1);
                IdentityRole role2 = new IdentityRole()
                {
                    Name = "Agent",
                };
                db.Roles.Add(role2);

                db.SaveChanges();

                
            }
        }

        public IdentityRole GetRoleByName(string name)
        {
            IdentityRole myRole;
            using (var db = new FilRougeDBContext())
            {
                myRole = db.Roles.Where(e => e.Name == name).FirstOrDefault();
            }
            return myRole;
        }

        public void AddUsers()
        {
        
            IdentityRole adminRole = GetRoleByName("Admin");
            //IdentityUserRole userAdminRole = new IdentityUserRole()
            //{
            //    RoleId = adminRole.Id,
            //};

            using (var db = new FilRougeDBContext())
            {
                


                Contact user1 = new Contact()
                {
                    LastName = "B",
                    FirstName = "Marc",
                    //Password = "VeryHardToDecode",
                    UserName = "Marc",
                    
                    //Type = User.type.Admin,
                };
                user1.Roles.Add(new IdentityUserRole()
                {
                    RoleId = adminRole.Id,
                    UserId = user1.Id,
                });
                db.Users.Add(user1);
                Contact user2 = new Contact()
                {
                    LastName = "F",
                    FirstName = "Nicolas",
                    //Password = "VeryHardToDecode",
                    UserName = "Nicolas",
                    //Type = User.type.Admin,
                };
                user2.Roles.Add(new IdentityUserRole()
                {
                    RoleId = adminRole.Id,
                    UserId = user2.Id,
                });
                db.Users.Add(user2);
                Contact user3 = new Contact()
                {
                    LastName = "Z",
                    FirstName = "David",
                    //Password = "VeryHardToDecode",
                    UserName = "David",
                    //Type = User.type.Agent,
                };
                user3.Roles.Add(new IdentityUserRole()
                {
                    RoleId = adminRole.Id,
                    UserId = user3.Id,
                });
                db.Users.Add(user3);

                db.SaveChanges();


            }
        }

        public void AddTechnologies()
        {
            using (var db = new FilRougeDBContext())
            {
                db.Technology.Add(
                    new Technology()
                    {
                        Name = "C",
                        DisplayNum = 10,
                    });
                db.Technology.Add(
                    new Technology()
                    {
                        Name = "C++",
                        DisplayNum = 10,
                    });
                db.Technology.Add(
                    new Technology()
                    {
                        Name = "C#",
                        DisplayNum = 10,
                    });
                db.Technology.Add(
                    new Technology()
                    {
                        Name = "Pascal",
                        DisplayNum = 1,
                    });
                db.Technology.Add(
                    new Technology()
                    {
                        Name = "Java",
                        DisplayNum = 2,
                    });
                db.SaveChanges();
            }
        }

        public void AddDifficulty()
        {
            using (var db = new FilRougeDBContext())
            {
                db.Difficulty.Add(
                    new Difficulty
                    {
                        Name = "Débutant",
                        DisplayNum = 10,
                    });
                db.Difficulty.Add(
                    new Difficulty
                    {
                        Name = "Intermédiaire",
                        DisplayNum = 20,
                    });
                db.Difficulty.Add(
                    new Difficulty
                    {
                        Name = "Expert",
                        DisplayNum = 30,
                    });
                db.Difficulty.Add(
                    new Difficulty
                    {
                        Name = "Expert sénior",
                        DisplayNum = 40,
                    });
                db.SaveChanges();
            }
        }

        public int GetDifficultyDebutant()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Difficulty
                    .Where(e => e.Name == "Débutant")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetDifficultyIntermediaire()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Difficulty
                    .Where(e => e.Name == "Intermédiaire")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetDifficultyExpert()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Difficulty
                    .Where(e => e.Name == "Expert")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetDifficultyExpertSenior()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Difficulty
                    .Where(e => e.Name == "Expert sénior")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetTechnologyCSharp()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == "C#")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetTechnologyC()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == "C")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetTechnologyCPlusPlus()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == "C++")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetTechnologyPascal()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == "Pascal")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }
        public int GetTechnologyJava()
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == "Java")
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }

        /// <summary>
        /// Retourne un utilisateur qui correspond au userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Contact GetUserByUserName(string userName)
        {
            var returnedUser = new Contact();
            using (var db = new FilRougeDBContext())
            {
                returnedUser = db.Users
                                .Where(e => e.UserName == userName)
                                .FirstOrDefault();
            }
            return returnedUser;
        }

        public string GetUserId(string userName)
        {
            var returnedUser = "";
            using (var db = new FilRougeDBContext())
            {
                returnedUser = db.Users
                                .FirstOrDefault(e => e.UserName == userName)
                                .Id;
            }
            return returnedUser;
        }

        public int GetTechnologyIdByName(string name)
        {
            int id = 0;
            using (var db = new FilRougeDBContext())
            {
                id = db.Technology
                    .Where(e => e.Name == name)
                    .Select(e => e.Id).FirstOrDefault();

            }
            return id;
        }

        public string GetTechnologyById(int id)
        {
            String result;
            using (var db = new FilRougeDBContext())
            {
                result = db.Technology
                    .Where(e => e.Id == id)
                    .Select(e => e.Name).FirstOrDefault().ToString();

            }
            return result;
        }
        public string GetDifficultyById(int id)
        {
            String result;
            using (var db = new FilRougeDBContext())
            {
                result = db.Difficulty
                    .Where(e => e.Id == id)
                    .Select(e => e.Name).FirstOrDefault().ToString();

            }
            return result;
        }

        public void AddDifficultyRates()
        {
            using (var db = new FilRougeDBContext())
            {
                //Récupération des Ids
                int debutantId = GetDifficultyDebutant();
                int intemediaireId = GetDifficultyIntermediaire();
                int expertId = GetDifficultyExpert();
                int expertSeniorId = GetDifficultyExpertSenior();

                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = debutantId,
                        DifficultyQuestionId = debutantId,
                        Rate = 0.5m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = debutantId,
                        DifficultyQuestionId = intemediaireId,
                        Rate = 0.25m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = debutantId,
                        DifficultyQuestionId = expertId,
                        Rate = 0.15m,
                    });

                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = intemediaireId,
                        DifficultyQuestionId = debutantId,
                        Rate = 0.15m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = intemediaireId,
                        DifficultyQuestionId = intemediaireId,
                        Rate = 0.5m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = intemediaireId,
                        DifficultyQuestionId = expertId,
                        Rate = 0.25m,
                    });

                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = expertId,
                        DifficultyQuestionId = debutantId,
                        Rate = 0.15m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = expertId,
                        DifficultyQuestionId = intemediaireId,
                        Rate = 0.25m,
                    });
                db.DifficultyRate.Add(
                    new DifficultyRate()
                    {
                        DifficultyQuizzId = expertId,
                        DifficultyQuestionId = expertId,
                        Rate = 0.5m,
                    });

                db.SaveChanges();
            }
        }

        public void AddFreeQuestions()
        {
            using (var db = new FilRougeDBContext())
            {
                int myTechno;
                int myDifficulty;
                bool IsFreeAnswer;

                IsFreeAnswer = true;
                myTechno = GetTechnologyCSharp();
                myDifficulty = GetDifficultyDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }

                myTechno = GetTechnologyPascal();
                myDifficulty = GetDifficultyDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question libre " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }

                db.SaveChanges();
            }
        }

        public void AddQCMQuestions()
        {
            using (var db = new FilRougeDBContext())
            {
                int myTechno;
                int myDifficulty;
                bool IsFreeAnswer;

                IsFreeAnswer = false;
                myTechno = GetTechnologyCSharp();
                myDifficulty = GetDifficultyDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }

                myTechno = GetTechnologyPascal();
                myDifficulty = GetDifficultyDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }
                myDifficulty = GetDifficultyExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Question.Add(
                        new Question()
                        {
                            Content = "Question " + GetDifficultyById(myDifficulty) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            IsFreeAnswer = IsFreeAnswer,
                            TechnologyId = myTechno,
                            DifficultyId = myDifficulty,
                            IsEnable = true,
                        });
                }

                db.SaveChanges();
            }
        }

        public void AddQCMAnswersChoice()
        {
            int y = 1;
            bool isCorrect;
            using (var db = new FilRougeDBContext())
            {
                var myQuestions = db.Question
                                .Where(e => e.IsFreeAnswer == false).ToList();
                foreach (var myQuestion in myQuestions)
                {
                    for (int x = 1; x < 5; x++)
                    {
                        y++;
                        if ((y %= 3) == 1)
                            isCorrect = true;
                        else
                            isCorrect = false;

                        myQuestion.Responses.Add(
                        new Response()
                        {
                            Content = "Question Id=" + myQuestion.Id + " Proposition " + x + " (" + isCorrect + ")",
                            IsTrue = isCorrect,
                        });
                    }

                }
                db.SaveChanges();
            }
        }
    }
}
