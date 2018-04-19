namespace FilRouge.Service
{
    using FilRouge.Model.Entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Services liés au quizz, pdf, gestion, mails, CRUD...
    /// </summary>
    public class QuizzService : IQuizzService
    {
        #region Properties

        #endregion

        /// <summary>
        /// Constructeur de la classe de QuizzService
        /// </summary>
        public QuizzService()
        {
        } //Constructeur

        /// <summary>
        /// Méthode pour crééer un Quiz
        /// </summary>
        /// <param name="userId"></param> // Id de la personne qui a généré le quiz
        /// <param name="technologyId"></param> // Technologie du quiz
        /// <param name="difficultyId"></param> // Difficulté du quiz
        /// <param name="userLastName"></param> // Nom du candidant
        /// <param name="userFirstName"></param> // Prénom du candidant
        /// <param name="externalNum"></param> // Identifaint du candidat fonctionnellement optionnel provenant d'un outil de gestion des RH 
        /// <param name="numberQuestions"></param> // Nombre de questions du quiz
        /// <param name="freeAnswerMax"></param> // Nombre maximum de questions libres à poser (0 par défaut) 
        /// <param name="freeAnswerMin"></param> // Nombre minimum de questions libres à poser (0 par défaut)
        /// <returns>Id du quizz créé</returns>
        public int CreateQuizz(
            string userId,
            int technologyId,
            int difficultyId,
            string userLastName,
            string userFirstName,
            string externalNum,
            int numberQuestions,
            int freeAnswerMax = 0,
            int freeAnswerMin = 0)
        {
            // Reste à faire : Gestion des erreurs (ex : pas d'enregistrement trouvé)

            List<int> listQuestions = new List<int>();

            Random myRandom = new Random();
            int nbFreeQuestions, nbQCMQuestions, nbQuestions;
            int myReturnedID = 0;


            // Traitement du cas de figure où oon s'est trompé entre Min et Max.
            // On remet les choses dans l'ordre

            if (freeAnswerMax < freeAnswerMin)
            {
                var tmpMax = freeAnswerMax;
                freeAnswerMax = freeAnswerMin;
                freeAnswerMin = tmpMax;
            }

            if (freeAnswerMax < freeAnswerMin)
                throw new Exception(nameof(CreateQuizz) + "freeAnswerMax < freeAnswerMin");

            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var myDifficulties = db.DifficultyRate.Where(e => e.DifficultyQuizzId == difficultyId);


                        int myCount = 0; // Stock le total de questions
                        int tempNbQuestions;
                        Dictionary<int, int> difficulties = new Dictionary<int, int>();

                        foreach (var myDifficulty in myDifficulties)
                        {

                            tempNbQuestions = (int)Math.Ceiling(myDifficulty.Rate * numberQuestions);
                            myCount += tempNbQuestions;

                            //Gestion du nombre de questions effectives qui dépasse le nombre de questions demandées
                            if (myCount > numberQuestions)
                            {
                                tempNbQuestions -= myCount - numberQuestions;
                            }

                            difficulties.Add(myDifficulty.DifficultyQuestionId, tempNbQuestions);
                        }

                        // A faire :
                        // Récupérer l'erreur d'arrondi sur le dernier enregistrement 
                        // EcartACombler = numberQuestions - myCount;
                        // 
                        // Ici on récupère le nombre de questions manquantes et on répertie ces questions entre les différents niveaux de difficultées
                        List<int> listKeys = new List<int>();
                        foreach (var diff in difficulties)
                        {
                            listKeys.Add(diff.Key);
                        }

                        while (myCount < numberQuestions)
                        {
                            foreach (var key in listKeys)
                            {
                                //int key = entry.Key;
                                difficulties[key] += 1;
                                myCount++;
                                if (myCount >= numberQuestions) break;
                            }
                        }



                        // difficulties stocke le nombre de questions à poser pour chaque pour chaque difficultée
                        foreach (var difficulty in difficulties)
                        {
                            nbFreeQuestions = myRandom.Next(freeAnswerMin, freeAnswerMax);
                            nbQCMQuestions = difficulty.Value - nbFreeQuestions;

                            // Questions libres
                            listQuestions = listQuestions.Concat(
                                AddQuestions(
                                    userLastName,
                                    userFirstName,
                                    externalNum,
                                    technologyId,
                                    difficulty.Key,
                                    nbFreeQuestions,
                                    true)).ToList();
                            //Questions QCM
                            listQuestions = listQuestions.Concat(
                                AddQuestions(
                                    userLastName,
                                    userFirstName,
                                    externalNum,
                                    technologyId,
                                    difficulty.Key,
                                    nbQCMQuestions,
                                    false)).ToList();

                        }

                        bool hasFreeQuestion = false;
                        if (freeAnswerMax > 0) hasFreeQuestion = true;


                        //Création de l'entête => Quizz
                        var myQuizz = new Quizz()
                                          {
                                              ContactId = userId,
                                              TechnologyId = technologyId,
                                              DifficultyId = difficultyId,
                                              UserLastName = userLastName,
                                              UserFirstName = userFirstName,
                                              ExternalNum = externalNum,
                                              ActiveQuestionNum = 0,
                                              QuizzState = QuizzStateEnum.NotStarted,
                                              HasFreeQuestion = hasFreeQuestion,
                                              QuestionCount = numberQuestions,
                                          };
                        db.Quizz.Add(myQuizz);
                        db.SaveChanges();
                        nbQuestions = listQuestions.Count();
                        int rndDisplayNum; //Nombre aléatoire
                        //Création des questions
                        foreach (var questionId in listQuestions)
                        {
                            // On rend l'ordre d'affichage aléatoire grâce au DisplayNum
                            rndDisplayNum = myRandom.Next(100);
                            db.QuestionQuizz.Add(
                                new QuestionQuizz()
                                    {
                                        QuizzId = myQuizz.Id,
                                        QuestionId = questionId,
                                        DisplayNum = rndDisplayNum,
                                    });
                        }

                        db.SaveChanges();

                        //Tout c'est bien passé, on valide la transaction
                        dbContextTransaction.Commit();
                        myReturnedID = myQuizz.Id;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Une erreur est survenue\n" + e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }

            return myReturnedID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLastName"></param>
        /// <param name="userFirstName"></param>
        /// <param name="externalNum"></param>
        /// <param name="technologyId"></param>
        /// <param name="difficultyId"></param>
        /// <param name="numberQuestions"></param>
        /// <param name="isFreeAnswer"></param>
        /// <returns></returns>
        private List<int> AddQuestions(
            string userLastName,
            string userFirstName,
            string externalNum,
            int technologyId,
            int difficultyId,
            int numberQuestions,
            bool isFreeAnswer = false)
        {
            List<int> questionsARetourner = new List<int>();

            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                List<int> questionsPossibles = db.Question
                    .Where(
                        e => ((e.TechnologyId == technologyId) && (e.DifficultyId == difficultyId)
                                                               && (e.IsFreeAnswer == isFreeAnswer))).Select(e => e.Id)
                    .ToList();

                List<int> questionsDejaPosees = db.QuestionQuizz.Where(
                        e => ((e.Question.TechnologyId == technologyId) && (e.Question.DifficultyId == difficultyId)
                                                                        && (e.Question.IsFreeAnswer == isFreeAnswer)
                                                                        && (e.Quizz.UserFirstName == userFirstName)
                                                                        && (e.Quizz.UserLastName == userLastName)
                                                                        && (e.Quizz.ExternalNum == externalNum)))
                    .Select(e => e.QuestionId).ToList();

                var questionsPossiblesUtilisateur =
                    questionsPossibles.Where(e => !(questionsDejaPosees.Contains(e))).ToList();

                var myRandom = new System.Random();
                int index = 0;

                if (questionsPossiblesUtilisateur.Count() >= numberQuestions)
                {
                    // La liste des questions disponible est suffisante, 
                    // il ne sera pas nécessaire de repiocher dans les questions déjà passées

                    //for (int x = 0; x < questionsARetourner.Count(); x++)
                    while (questionsARetourner.Count() < numberQuestions)
                    {
                        // On va piocher au hasard dans les questions
                        index = myRandom.Next(0, questionsPossiblesUtilisateur.Count() - 1);
                        // On affecte 
                        questionsARetourner.Add(questionsPossiblesUtilisateur[index]);
                        // On supprimme de la liste d'origine
                        questionsPossiblesUtilisateur.RemoveAt(index);
                    }


                }
                else
                {
                    // La liste des questions disponible est insuffisante, 
                    // il sera nécessaire de repiocher dans les questions déjà passées

                    // On prend toutes les questions possibles
                    foreach (var question in questionsPossiblesUtilisateur)
                    {
                        questionsARetourner.Add(question);
                    }

                    // On pioche au hasard dans les questions déjà passées
                    // On s'assure d'avoir suffisamment de questions pour réaliser l'action
                    if ((questionsARetourner.Count() + questionsDejaPosees.Count()) < numberQuestions)
                    {
                        throw new Exception(
                            "Impossible d'aller au bout de la génération ! \nPas assez de questions pour générer le quiz.");
                    }
                    else
                    {
                        // On va piocher au hasard dans les questions
                        index = myRandom.Next(0, questionsDejaPosees.Count() - 1);
                        // On affecte 
                        questionsARetourner.Add(questionsDejaPosees[index]);
                        // On supprimme de la liste d'origine
                        questionsDejaPosees.RemoveAt(index);
                    }
                }
            }

            return questionsARetourner;
        }

        public Quizz GetQuizById(int id)
        {
            //throw new Exception("Méthode non implémentée");
            Quizz returnedQuiz = null;
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                returnedQuiz = db.Quizz.Where(e => e.Id == id).FirstOrDefault();
            }

            return returnedQuiz;
        }

        /// <summary>
        /// Récupère tous les quiz de la base
        /// </summary>
        /// <returns>Liste de quizz</returns>
        public List<Quizz> GetAllQuizz()
        {
            //throw new Exception("Méthode non implémentée");
            List<Quizz> returnedQuizz = new List<Quizz>();
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                returnedQuizz = db.Quizz.ToList();
            }

            return returnedQuizz;
        }

        /// <summary>
        /// Récupère tous les quizz pour un agent donné
        /// </summary>
        /// <param name="agent"></param>
        /// <returns>Liste de quizz</returns>
        public List<Quizz> GetAllQuizz(Contact agent)
        {
            throw new Exception("Méthode non implémentée");
            List<Quizz> returnedQuizz = new List<Quizz>();
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                returnedQuizz = db.Quizz.Where(e => e.Contact == agent).ToList();
            }

            return returnedQuizz;
        }

        public List<Quizz> GetQuizz(Quizz quizzFilter)
        {
            List<Quizz> returnedQuizz = new List<Quizz>();
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                returnedQuizz = db.Quizz.ToList();
                if (quizzFilter.DifficultyId != 0)
                    returnedQuizz = returnedQuizz.Where(e => e.DifficultyId == quizzFilter.DifficultyId).ToList();
                if (quizzFilter.TechnologyId != 0)
                    returnedQuizz = returnedQuizz.Where(e => e.TechnologyId == quizzFilter.TechnologyId).ToList();
                if (quizzFilter.ContactId != "")
                    returnedQuizz = returnedQuizz.Where(e => e.ContactId == quizzFilter.ContactId).ToList();
                if (quizzFilter.UserLastName != "")
                    returnedQuizz = returnedQuizz.Where(e => e.UserLastName == quizzFilter.UserLastName).ToList();
                if (quizzFilter.UserFirstName != "")
                    returnedQuizz = returnedQuizz.Where(e => e.UserFirstName == quizzFilter.UserFirstName).ToList();
                if (quizzFilter.ExternalNum != "")
                    returnedQuizz = returnedQuizz.Where(e => e.ExternalNum == quizzFilter.ExternalNum).ToList();
            }

            return returnedQuizz;
        }



        public void UpdateQuizzAnswer(int QuestionQuizzId, UserResponse userAnswer)
        {
            throw new Exception("Méthode non implémentée");
        }

        public void UpdateQuizzAnswers(Quizz quiz)
        {
            throw new Exception("Méthode non implémentée");
        }

    }
    //        #region Methods

    //        /// <summary>
    //        /// Méthode permettant d'obtenir un quizz en fonction de son id
    //        /// Fonctionne avec une fluentQuerry
    //        /// </summary>
    //        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
    //        /// <returns>Retourne un objet Quizz</returns>
    //        public Quizz GetQuizz(int id)
    //        {
    //            Quizz fluentQuery = new Quizz();
    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                fluentQuery = db.Quizz.Single(e => e.QuizzId == id);
    //                if(fluentQuery == null)
    //                {
    //                    throw new WrongIdQuizz("L'id saisie n'existe pas");
    //                }
    //                db.Dispose();                
    //            }
    //            catch(FormatException)
    //            {
    //                db.Dispose();
    //                Console.WriteLine("Veuillez saisir un id valide");
    //            }
    //            return fluentQuery;
    //        }
    //        /// <summary>
    //        /// Fonction retournant tous les quizz dans une liste de Quizz
    //        /// Fonctionne avec une fluentQuerry
    //        /// </summary>
    //        /// <returns>Retourne tous les quizz</returns>
    //        public List<Quizz> GetAllQuizz()
    //        {
    //            List<Quizz> desQuizz = new List<Quizz>();
    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {   
    //                IQueryable<Quizz> fluentQuery = db.Quizz.Select(e => e);
    //                if(fluentQuery.Count() == 0)
    //                {
    //                    throw new ListQuizzEmpty("La liste des quizz est vide");
    //                }
    //                foreach (var item in fluentQuery)
    //                {
    //                    desQuizz.Add(item);
    //                }
    //                db.Dispose();
    //            }
    //            catch (ListQuizzEmpty)
    //            {
    //                db.Dispose();
    //            }

    //            return desQuizz;
    //        }
    //        /// <summary>
    //        /// 
    //        /// </summary>
    //        /// <param name="questionsQuizz"></param>
    //        /// <param name="lesQuestions"></param>
    //        /// <param name="questionlibre"></param>
    //        /// <param name="nombrequestions"></param>
    //        /// <returns></returns>
    //        ///

    //        public static List<Question> AddQuestionToQuizz(bool questionlibre, int nombrequestions, int technoid, int difficultymasterid)
    //        {
    //            Random rand = new Random();
    //            List<Question> sortedQuestionsQuizz = new List<Question>();

    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                //Requêtes Linq
    //                int nbrTotalQuestions = db.Question.Select(e => e).Count();
    //                IQueryable<Question> AllQuestionsByTechno = db.Question.Where(e => e.TechnologyId == technoid);
    //               // IQueryable<DifficultyRate> RatesQuizz = db.DifficultyRate.Where(e => e.DifficultyMasterId == difficultymasterid);
    //                IQueryable<TypeQuestion> TypesQuestions = db.TypeQuestion.Select(e => e); 

    //                //Génération de la liste de questions en fonction des paramètres
    //                foreach (var rate in RatesQuizz)
    //                {//Pour gérer la répartition des questions dans le quizz

    //                    for (int i = 0; i < Math.Floor(nombrequestions * rate.Rate); i++)
    //                    {           
    //                        //pas encore utilisé
    //                            IQueryable<Questions> QuestionByType = AllQuestionsByTechno.Where(e => e.TypeQuestion.NameType == "Question libre");
    //                        foreach (var question in QuestionByType)
    //                        {//Vérification par id de la présence d'une question
    //                            if (question.QuestionId == rand.Next(0, nbrTotalQuestions))
    //                            {
    //                                foreach (var newQuestion in sortedQuestionsQuizz)
    //                                {
    //                                    //Gestion des doublons
    //                                    if (question.QuestionId != newQuestion.QuestionId)
    //                                    {

    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }


    //            return sortedQuestionsQuizz;
    //        }
    //        /// <summary>
    //        /// 
    //        /// </summary>
    //        /// <param name="difficultyid"></param>
    //        /// <param name="technoid"></param>
    //        /// <param name="userid"></param>
    //        /// <param name="nomuser"></param>
    //        /// <param name="prenomuser"></param>
    //        /// <param name="questionlibre"></param>
    //        /// <param name="nombrequestions"></param>
    //        public static void CreateQuizz(int userid, int difficultymasterid, int technoid,string nomuser, string prenomuser, bool questionlibre, int nombrequestions)
    //        {
    //            List<Questions> questionsQuizz = AddQuestionToQuizz(questionlibre,nombrequestions, technoid, difficultymasterid);
    //            int timer = 0;
    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                Contact creatingQuizzContact = db.Contact.Single(e => e.UserId == userid);
    //                DifficultyMaster difficultyQuizz = db.DifficultyMaster.Single(e => e.DiffMasterId == difficultymasterid);
    //                Technology technoQuizz = db.Technology.Single(e => e.TechnoId == technoid);

    //                Quizz unQuizz = new Quizz
    //                {
    //                    ContactId = userid,
    //                    DifficultyMasterId = difficultymasterid,
    //                    TechnologyId = technoid,
    //                    Timer = timer,
    //                    PrenomUser = prenomuser,
    //                    NomUser = nomuser,
    //                    NombreQuestion = nombrequestions,
    //                    EtatQuizz = 0,
    //                    QuestionLibre = questionlibre,
    //                    Contact = creatingQuizzContact,
    //                    DifficultyMaster = difficultyQuizz,
    //                    Questions = questionsQuizz,
    //                    Technology = technoQuizz
    //                };
    //                db.SaveChanges();
    //                db.Dispose();
    //            }
    //            catch (AlreadyInTheQuestionsList e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //            catch (NoQuestionsForYou e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //        }
    //        #endregion
    //    }
    //}





















    // To delete

    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //namespace FilRouge.Services
    //{
    //    using FilRouge.Model.Entities;

    //    /// <summary>
    //    /// Services liés au quizz, pdf, gestion, mails, CRUD...
    //    /// </summary>
    //    public class QuizzService
    //    {
    //        #region Properties

    //        #endregion
    //        /// <summary>
    //        /// Constructeur de la classe de QuizzService
    //        /// </summary>
    //        public QuizzService() { } //Constructeur
    //        #region Methods

    //        public Question GetLastQuestion(int idQuizz)
    //        {
    //            //var lastAnswerId = quizz.Questions.Where(question => question.Active == true).Select(p=>p.QuestionId).FirstOrDefault();
    //            using (var db = new FilRougeDBContext())
    //            {

    //                var last = db.Quizz
    //                    .FirstOrDefault(q => q.QuizzId == idQuizz)
    //                    .UserReponse.FirstOrDefault().Quizz.Questions.FirstOrDefault();



    //                return last;




    //                //db.UserReponse.Join(db.Quizz,
    //                //                        userReponse => userReponse.QuizzId,
    //                //                        quizz=>quizz.QuizzId,
    //                //                        (userReponse, quizz) => new { userReponse, quizz })
    //                //                        .Join(db.Question,
    //                //                            question=> question.quizz.Questions.Select(q=>q.QuestionId).FirstOrDefault(),
    //                //                            quizz=>quizz.QuestionId,
    //                //                             (userReponse, quizz) => new { userReponse, quizz }).




    //                //    db.Question.Select(q => q.Content != null).FirstOrDefault();

    //                //         var UserInRole = db.Question.
    //                //                Join(db.Quizz, 
    //                //                        u => u.QuestionId,
    //                //                        uir => uir.Questions.Select(q=>q.QuestionId),
    //                //                        (u, uir) => new { u, uir }).
    //                //                        return db.Quizz.Find(idQuizz)
    //                //        //.Questions.Where(question => question.Active == true).FirstOrDefault();
    //            }





    //        }

    //        /// <summary>
    //        /// Méthode permettant d'obtenir un quizz en fonction de son id
    //        /// Fonctionne avec une fluentQuerry
    //        /// </summary>
    //        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
    //        /// <returns>Retourne un objet Quizz</returns>
    //        public Quizz GetQuizz(int id)
    //        {
    //            Quizz fluentQuery = new Quizz();
    //            //FilRougeDBContext db = new FilRougeDBContext();
    //            //try
    //            //{
    //            //    fluentQuery = db.Quizz.Single(e => e.QuizzId == id);
    //            //    if (fluentQuery == null)
    //            //    {
    //            //        throw new WrongIdQuizz(id);
    //            //    }
    //            //    db.Dispose();
    //            //}
    //            //catch (FormatException e)
    //            //{
    //            //    db.Dispose();
    //            //    Console.WriteLine(e.Message);
    //            //}
    //            return fluentQuery;
    //        }
    //        /// <summary>
    //        /// Fonction retournant tous les quizz dans une liste de Quizz
    //        /// Fonctionne avec une fluentQuerry
    //        /// </summary>
    //        /// <returns>Retourne tous les quizz</returns>
    //        public List<Quizz> GetAllQuizz()
    //        {
    //            List<Quizz> allQuizz = new List<Quizz>();
    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                allQuizz = db.Quizz.Select(e => e).ToList();
    //                if (allQuizz.Count() == 0)
    //                {
    //                    throw new ListQuizzEmpty("La liste des quizz est vide");
    //                }
    //                foreach (var quizz in allQuizz)
    //                {
    //                    allQuizz.Add(quizz);
    //                }
    //                db.Dispose();
    //            }
    //            catch (ListQuizzEmpty)
    //            {
    //                db.Dispose();
    //            }

    //            return allQuizz;
    //        }
    //        /// <summary>
    //        /// 
    //        /// </summary>
    //        /// <param name="questionsQuizz"></param>
    //        /// <param name="lesQuestions"></param>
    //        /// <param name="questionlibre"></param>
    //        /// <param name="nombrequestions"></param>
    //        /// <returns></returns>
    //        ///

    //        public static List<Question> AddQuestionToQuizz(bool questionlibre, int nombrequestions, int technoid, int difficultymasterid)
    //        {
    //            Random rand = new Random();
    //            List<Question> sortedQuestionsQuizz = new List<Question>();

    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                //Requêtes Linq
    //                int nbrTotalQuestions = db.Question.Select(e => e).Count();
    //                IQueryable<Question> AllQuestionsByTechno = db.Question.Where(e => e.TechnologyId == technoid);
    //                IQueryable<DifficultyRate> RatesQuizz = db.DifficultyRate.Where(e => e.DifficultyMasterId == difficultymasterid);
    //                IQueryable<TypeQuestion> TypesQuestions = db.TypeQuestion.Select(e => e);

    //                //Génération de la liste de questions en fonction des paramètres
    //                foreach (var rate in RatesQuizz)
    //                {//Pour gérer la répartition des questions dans le quizz

    //                    for (int i = 0; i < Math.Floor(nombrequestions * rate.Rate); i++)
    //                    {
    //                        //pas encore utilisé
    //                        IQueryable<Question> QuestionByType = AllQuestionsByTechno.Where(e => e.TypeQuestion.NameType == "Question libre");
    //                        foreach (var question in QuestionByType)
    //                        {//Vérification par id de la présence d'une question
    //                            if (question.QuestionId == rand.Next(0, nbrTotalQuestions))
    //                            {
    //                                foreach (var newQuestion in sortedQuestionsQuizz)
    //                                {
    //                                    //Gestion des doublons
    //                                    if (question.QuestionId != newQuestion.QuestionId)
    //                                    {

    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }


    //            return sortedQuestionsQuizz;
    //        }
    //        /// <summary>
    //        /// 
    //        /// </summary>
    //        /// <param name="difficultyid"></param>
    //        /// <param name="technoid"></param>
    //        /// <param name="userid"></param>
    //        /// <param name="nomuser"></param>
    //        /// <param name="prenomuser"></param>
    //        /// <param name="questionlibre"></param>
    //        /// <param name="nombrequestions"></param>
    //        public static void CreateQuizz(int userid, int difficultymasterid, int technoid, string nomuser, string prenomuser, bool questionlibre, int nombrequestions)
    //        {
    //            List<Question> questionsQuizz = AddQuestionToQuizz(questionlibre, nombrequestions, technoid, difficultymasterid);
    //            FilRougeDBContext db = new FilRougeDBContext();
    //            try
    //            {
    //                Contact creatingQuizzContact = db.Contact.Single(e => e.UserId == userid);
    //                DifficultyMaster difficultyQuizz = db.DifficultyMaster.Single(e => e.DiffMasterId == difficultymasterid);
    //                Technology technoQuizz = db.Technology.Single(e => e.TechnoId == technoid);

    //                Quizz unQuizz = new Quizz
    //                {
    //                    ContactId = userid,
    //                    DifficultyMasterId = difficultymasterid,
    //                    TechnologyId = technoid,
    //                    PrenomUser = prenomuser,
    //                    NomUser = nomuser,
    //                    NombreQuestion = nombrequestions,
    //                    EtatQuizz = 0,
    //                    QuestionLibre = questionlibre,
    //                    Contact = creatingQuizzContact,
    //                    DifficultyMaster = difficultyQuizz,
    //                    Questions = questionsQuizz,
    //                    Technology = technoQuizz
    //                };
    //                db.SaveChanges();
    //                db.Dispose();
    //            }
    //            catch (AlreadyInTheQuestionsList e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //            catch (NoQuestionsForYou e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine(e.Message);
    //                db.Dispose();
    //            }
    //        }
    //        #endregion
    //    }
    //}
}