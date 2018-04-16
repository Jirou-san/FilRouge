using System;


namespace FilRouge.Model
{
    public class DataTestSet
    {
        public void FillAllTables()
        {
            Console.WriteLine("Ajout des utilisateurs");
            AddUsers();
            Console.WriteLine("Ajout des technologies");
            AddTechnologies();
            Console.WriteLine("Ajout des entêtes de difficulté");
            AddSkills();
            Console.WriteLine("Ajout des ratio de difficulté");
            AddSkillsRates();
            Console.WriteLine("Ajout des questions libres");
            AddFreeQuestions();
            Console.WriteLine("Ajout des questions de QCM");
            AddQCMQuestions();
            Console.WriteLine("Ajout des réponses possibles de QCM");
            AddQCMAnswersChoice();

            Console.WriteLine("\n\n\n Fin traitements\n");
            Console.ReadKey();
        }

        public void AddUsers()
        {
            using (var db = new RedStringDBContext())
            {
                User user1 = new User()
                {
                    LastName = "B",
                    FirstName = "Marc",
                    Password = "VeryHardToDecode",
                    Type = User.type.Admin,
                };
                db.Users.Add(user1);
                User user2 = new User()
                {
                    LastName = "F",
                    FirstName = "Nicolas",
                    Password = "VeryHardToDecode",
                    Type = User.type.Admin,
                };
                db.Users.Add(user2);
                User user3 = new User()
                {
                    LastName = "F",
                    FirstName = "David",
                    Password = "VeryHardToDecode",
                    Type = User.type.Agent,
                };
                db.Users.Add(user3);

                db.SaveChanges();
            }
        }

        public void AddTechnologies()
        {
            using (var db = new RedStringDBContext())
            {
                db.Technologies.Add(
                    new Technology()
                    {
                        Caption = "C",
                        DisplayNum = 10,
                    });
                db.Technologies.Add(
                    new Technology()
                    {
                        Caption = "C++",
                        DisplayNum = 10,
                    });
                db.Technologies.Add(
                    new Technology()
                    {
                        Caption = "C#",
                        DisplayNum = 10,
                    });
                db.Technologies.Add(
                    new Technology()
                    {
                        Caption = "Pascal",
                        DisplayNum = 1,
                    });
                db.Technologies.Add(
                    new Technology()
                    {
                        Caption = "Java",
                        DisplayNum = 2,
                    });
                db.SaveChanges();
            }
        }

        public void AddSkills()
        {
            using (var db = new RedStringDBContext())
            {
                db.Skills.Add(
                    new Skill
                    {
                        Caption = "Débutant",
                        DisplayNum = 10,
                    });
                db.Skills.Add(
                    new Skill
                    {
                        Caption = "Intermédiaire",
                        DisplayNum = 20,
                    });
                db.Skills.Add(
                    new Skill
                    {
                        Caption = "Expert",
                        DisplayNum = 30,
                    });
                db.Skills.Add(
                    new Skill
                    {
                        Caption = "Expert sénior",
                        DisplayNum = 40,
                    });
                db.SaveChanges();
            }
        }

        private int GetSkillDebutant()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Skills
                    .Where(e => e.Caption == "Débutant")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetSkillIntermediaire()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Skills
                    .Where(e => e.Caption == "Intermédiaire")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetSkillExpert()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Skills
                    .Where(e => e.Caption == "Expert")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetSkillExpertSenior()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Skills
                    .Where(e => e.Caption == "Expert sénior")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetTechnologyCSharp()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Technologies
                    .Where(e => e.Caption == "C#")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetTechnologyC()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Technologies
                    .Where(e => e.Caption == "C")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetTechnologyCPlusPlus()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Technologies
                    .Where(e => e.Caption == "C++")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetTechnologyPascal()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Technologies
                    .Where(e => e.Caption == "Pascal")
                    .Select(e => e.Id).First();

            }
            return id;
        }
        private int GetTechnologyJava()
        {
            int id = 0;
            using (var db = new RedStringDBContext())
            {
                id = db.Technologies
                    .Where(e => e.Caption == "Java")
                    .Select(e => e.Id).First();

            }
            return id;
        }

        private string GetTechnologyById(int id)
        {
            String result;
            using (var db = new RedStringDBContext())
            {
                result = db.Technologies
                    .Where(e => e.Id == id)
                    .Select(e => e.Caption).First().ToString();

            }
            return result;
        }
        private string GetSkillById(int id)
        {
            String result;
            using (var db = new RedStringDBContext())
            {
                result = db.Skills
                    .Where(e => e.Id == id)
                    .Select(e => e.Caption).First().ToString();

            }
            return result;
        }

        public void AddSkillsRates()
        {
            using (var db = new RedStringDBContext())
            {
                //Récupération des Ids
                int debutantId = GetSkillDebutant();
                int intemediaireId = GetSkillIntermediaire();
                int expertId = GetSkillExpert();
                int expertSeniorId = GetSkillExpertSenior();

                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = debutantId,
                        SkillQuestionId = debutantId,
                        Rate = 0.5m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = debutantId,
                        SkillQuestionId = intemediaireId,
                        Rate = 0.25m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = debutantId,
                        SkillQuestionId = expertId,
                        Rate = 0.15m,
                    });

                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = intemediaireId,
                        SkillQuestionId = debutantId,
                        Rate = 0.15m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = intemediaireId,
                        SkillQuestionId = intemediaireId,
                        Rate = 0.5m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = intemediaireId,
                        SkillQuestionId = expertId,
                        Rate = 0.25m,
                    });

                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = expertId,
                        SkillQuestionId = debutantId,
                        Rate = 0.15m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = expertId,
                        SkillQuestionId = intemediaireId,
                        Rate = 0.25m,
                    });
                db.SkillsRates.Add(
                    new SkillRate()
                    {
                        SkillQuizId = expertId,
                        SkillQuestionId = expertId,
                        Rate = 0.5m,
                    });

                db.SaveChanges();
            }
        }

        public void AddFreeQuestions()
        {
            using (var db = new RedStringDBContext())
            {
                int myTechno;
                int mySkill;
                bool freeAnswer;

                freeAnswer = true;
                myTechno = GetTechnologyCSharp();
                mySkill = GetSkillDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }

                myTechno = GetTechnologyPascal();
                mySkill = GetSkillDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question libre " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }

                db.SaveChanges();
            }
        }

        public void AddQCMQuestions()
        {
            using (var db = new RedStringDBContext())
            {
                int myTechno;
                int mySkill;
                bool freeAnswer;

                freeAnswer = false;
                myTechno = GetTechnologyCSharp();
                mySkill = GetSkillDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }

                myTechno = GetTechnologyPascal();
                mySkill = GetSkillDebutant();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillIntermediaire();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }
                mySkill = GetSkillExpert();
                for (int x = 0; x < 200; x++)
                {
                    db.Questions.Add(
                        new Question()
                        {
                            Caption = "Question " + GetSkillById(mySkill) + " en " + GetTechnologyById(myTechno) + " numéro " + (x + 1) + " ?",
                            FreeAnswer = freeAnswer,
                            TechnologyId = myTechno,
                            SkillId = mySkill,
                            Enabled = true,
                        });
                }

                db.SaveChanges();
            }
        }

        public void AddQCMAnswersChoice()
        {
            int y = 1;
            bool isCorrect;
            using (var db = new RedStringDBContext())
            {
                var myQuestions = db.Questions
                                .Where(e => e.FreeAnswer == false);
                foreach (var myQuestion in myQuestions)
                {
                    for (int x = 1; x < 5; x++)
                    {
                        y++;
                        if ((y %= 3) == 1)
                            isCorrect = true;
                        else
                            isCorrect = false;

                        myQuestion.AnswerChoices.Add(
                        new AnswerChoice()
                        {
                            Caption = "Question Id=" + myQuestion.Id + " Proposition " + x + " (" + isCorrect + ")",
                            CorrectAnswer = isCorrect,
                        });
                    }

                }
                db.SaveChanges();
            }
        }


    }
}

