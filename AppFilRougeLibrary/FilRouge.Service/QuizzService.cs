
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
    public QuizzService() { } //Constructeur

    /// <summary>
    /// Méthode pour créer un Quiz
    /// </summary>
    /// <param name="userId">Id de la personne qui a généré le quiz</param>
    /// <param name="technologyId">Technologie du quiz</param>
    /// <param name="difficultyId">Difficulté du quiz</param>
    /// <param name="userLastName">Nom du candidat</param>
    /// <param name="userFirstName">Prénom du candidat</param>
    /// <param name="externalNum">Identifaint du candidat fonctionnellement optionnel provenant d'un outil de gestion des RH </param>
    /// <param name="numberQuestions">Nombre de questions du quiz</param>
    /// <param name="freeAnswerMax">Nombre maximum de questions libres à poser (0 par défaut) </param>
    /// <param name="freeAnswerMin">Nombre minimum de questions libres à poser (0 par défaut)</param>
    /// <returns>Id du quizz créé</returns>
    public int CreateQuizz(string userId, int technologyId, int difficultyId, string userLastName, string userFirstName, string externalNum, int numberQuestions, int freeAnswerMax = 0, int freeAnswerMin = 0)
    {       
        List<int> listQuestions = new List<int>();

        Random myRandom = new Random();
        int nbFreeQuestions, nbQCMQuestions;
        //, nbQuestions;
        int myReturnedID=0;


        // Traitement du cas de figure où oon s'est trompé entre Min et Max.
        // On remet les choses dans l'ordre      
        if (freeAnswerMax < freeAnswerMin)
        {
            var tmpMax = freeAnswerMax;
            freeAnswerMax = freeAnswerMin;
            freeAnswerMin = tmpMax;
        }
        if (freeAnswerMax < freeAnswerMin) throw new Exception(nameof(CreateQuizz) + "freeAnswerMax < freeAnswerMin");

        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var myDifficulties = db.DifficultyRate
                             .Where(e => e.DifficultyQuizzId == difficultyId);

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
                    foreach(var diff in difficulties)
                    {
                        listKeys.Add(diff.Key);
                    }
                    while (myCount< numberQuestions)
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
                        listQuestions=listQuestions.Concat(
                            AddQuestions(userLastName, userFirstName, externalNum, technologyId, difficulty.Key, nbFreeQuestions, true)).ToList();
                        //Questions QCM
                        listQuestions = listQuestions.Concat(
                            AddQuestions(userLastName, userFirstName, externalNum, technologyId, difficulty.Key, nbQCMQuestions, false)).ToList();

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
                    //nbQuestions = listQuestions.Count();
                    int rndDisplayNum; //Nombre aléatoire
                    //Création des questions pour le quiz
                    foreach (var questionId in listQuestions)
                    {
                        // On rend l'ordre d'affichage aléatoire grâce au DisplayNum
                        rndDisplayNum = myRandom.Next(100);
                        db.QuestionQuizz.Add(new QuestionQuizz()
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
                catch (Exception e )
                {
                    Console.WriteLine("Une erreur est survenue\n" + e.Message);
                    dbContextTransaction.Rollback();
                }
            }
        }
        return myReturnedID;
    }

    /// <summary>
    /// Renvoie une liste d'Id de questions aléatoires pour l'utilisateur pour la technology et le niveau de difficulté donné.
    /// </summary>
    /// <param name="userLastName">Nom du candidat</param>
    /// <param name="userFirstName">Prénom du candidat</param>
    /// <param name="externalNum">Identifaint du candidat fonctionnellement optionnel provenant d'un outil de gestion des RH</param>
    /// <param name="technologyId">Technologie des questions</param>
    /// <param name="difficultyId">Niveau de difficulté des questions</param>
    /// <param name="numberQuestions">Nombre de questions à retourner</param>
    /// <param name="isFreeAnswer">True si on doit retourner des questions libre. False pour des questions de type QCM</param>
    /// <returns></returns>
    private List<int> AddQuestions(string userLastName, string userFirstName, string externalNum, int technologyId, int difficultyId, int numberQuestions, bool isFreeAnswer = false)
    {
        List<int> questionsARetourner = new List<int>();

        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            List<int> questionsPossibles = db.Question
                                .Where(e =>
                                    ((e.TechnologyId == technologyId)
                                    && (e.DifficultyId == difficultyId)
                                    && (e.IsFreeAnswer == isFreeAnswer)
                                    ))
                                .Select(e => e.Id).ToList();

            List<int> questionsDejaPosees = db.QuestionQuizz
                                .Where(e =>
                                    ((e.Question.TechnologyId == technologyId)
                                    && (e.Question.DifficultyId == difficultyId)
                                    && (e.Question.IsFreeAnswer == isFreeAnswer)
                                    && (e.Quizz.UserFirstName == userFirstName)
                                    && (e.Quizz.UserLastName == userLastName)
                                    && (e.Quizz.ExternalNum == externalNum)
                                    ))
                                .Select(e => e.QuestionId).ToList();

            var questionsPossiblesUtilisateur = questionsPossibles
                                                .Where(e => !(questionsDejaPosees.Contains(e))).ToList();

            var myRandom = new System.Random();
            int index = 0;
            
            if (questionsPossiblesUtilisateur.Count() >= numberQuestions)
            {
                // La liste des questions disponible est suffisante, 
                // il ne sera pas nécessaire de repiocher dans les questions déjà passées

                //for (int x = 0; x < questionsARetourner.Count(); x++)
                while(questionsARetourner.Count()<numberQuestions)
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
                    throw new Exception("Impossible d'aller au bout de la génération ! \nPas assez de questions pour générer le quiz.");
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

    /// <summary>
    /// Récupère un quiz avec ces questions, les propositions de réponses et les réponses de l'utilisateur
    /// GetQuizById isn't lazy! Work hard!! 
    /// </summary>
    /// <param name="id">Id du Quiz à récupérer</param>
    /// <returns>Quiz</returns>
    public Quizz GetQuizzById(int id)
    {
        //throw new Exception("Méthode non implémentée");
        Quizz returnedQuiz=null;
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            //db.Configuration.LazyLoadingEnabled = false;
            //On n'est pas des fénéant ! On récupère jusqu'aux rréponses de l'utilisateur
            
            returnedQuiz = db.Quizz
                            .Include(nameof(QuestionQuizz))
                            .Include(nameof(Technology))
                            .Where(e => e.Id == id)
                            .FirstOrDefault();
        }     
        return returnedQuiz;
    }

    /// <summary>
    /// Récupère tous les quiz de la base
    /// Ne prend pas les dépendances. (mode lazy)
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
    /// <param name="agent">Agent recruteur ou admin qui a généré les quizz</param>
    /// <returns>Liste de quizz</returns>
    public List<Quizz> GetAllQuizz(Contact agent)
    {
        //throw new Exception("Méthode non implémentée");
        List<Quizz> returnedQuizz = new List<Quizz>();
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            returnedQuizz = db.Quizz
                            .Where(e=>e.Contact == agent)
                            .ToList();
        }
        return returnedQuizz;
    }

    public List<Quizz> GetQuizz(Quizz quizzFilter)
    {
        List<Quizz> returnedQuizz = new List<Quizz>();
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            returnedQuizz = db.Quizz.ToList();
            if (quizzFilter.DifficultyId != 0) returnedQuizz = returnedQuizz.Where(e => e.DifficultyId == quizzFilter.DifficultyId).ToList();
            if (quizzFilter.TechnologyId != 0) returnedQuizz = returnedQuizz.Where(e => e.TechnologyId == quizzFilter.TechnologyId).ToList();
            if (quizzFilter.ContactId != "") returnedQuizz = returnedQuizz.Where(e => e.ContactId == quizzFilter.ContactId).ToList();
            if (quizzFilter.UserLastName !="") returnedQuizz = returnedQuizz.Where(e => e.UserLastName == quizzFilter.UserLastName).ToList();
            if (quizzFilter.UserFirstName != "") returnedQuizz = returnedQuizz.Where(e => e.UserFirstName == quizzFilter.UserFirstName).ToList();
            if (quizzFilter.ExternalNum != "") returnedQuizz = returnedQuizz.Where(e => e.ExternalNum == quizzFilter.ExternalNum).ToList();
        }
        return returnedQuizz;
    }

    /// <summary>
    /// Permet de mettre à jour les données utilisateur pour un quiz donné
    /// </summary>
    /// <param name="quizId">Id du quiz que l'on souhaite modifier</param>
    /// <param name="userFirstName">Prénom. Mettre à null si on ne souhaite pas modifier la valeur</param>
    /// <param name="userLastName">Nom. Mettre à null si on ne souhaite pas modifier la valeur</param>
    /// <param name="externalNumber">Numéro externe d'identification. Mettre à null si on ne souhaite pas modifier la valeur</param>
    public void UpdateQuiz(int quizId, string userFirstName, string userLastName, string externalNumber)
    {
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            var myQuiz = db.Quizz.Where(e => e.Id == quizId).FirstOrDefault();
            
            if (myQuiz != null)
            {
                if (userFirstName != null) myQuiz.UserFirstName = userFirstName;
                if (userLastName != null) myQuiz.UserLastName = userLastName;
                if (externalNumber != null) myQuiz.ExternalNum = externalNumber;
                db.SaveChanges();
            }
        }
    }

    //public void UpdateQuizzAnswer(int QuestionQuizzId, UserResponse userAnswer)
    //{
    //    throw new Exception("Méthode non implémentée");
    //}

    //public void UpdateQuizzAnswers(Quizz quiz)
    //{
    //    throw new Exception("Méthode non implémentée");
    //}

    /// <summary>
    /// Donne l'Id de la question en cours pour un quiz donné et des propositions de réponse associées
    /// </summary>
    /// <param name="quizzId">Id du quiz dont on souhaite connaitre la question en cours</param>
    /// <returns>Id de la question</returns>
    public int GetActiveQuestion(int quizzId)
    {
        int returnedQuestionId = 0;

        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            //Récupération du numéro de la question active
            var numQ = db.Quizz
                        .Where(e => e.Id == quizzId)
                        .First().ActiveQuestionNum;

            var questionsQuiz = db.QuestionQuizz
                        .Include(nameof(Response))
                        .Where(e => e.QuizzId == quizzId)
                        .OrderBy(e => e.DisplayNum)
                        .ToList();

            if (numQ == 0) numQ = 1; // Si le test n'a pas été commencé, on positionne sur la première question
            if (questionsQuiz.Count() < numQ)
            {
                returnedQuestionId = 0;
            }
            else
            {
                returnedQuestionId = questionsQuiz[numQ - 1].QuestionId;
            }
            
        }

        return returnedQuestionId;
    }

    /// <summary>
    /// Ecrit les réponses pour un un questionQuizz donné et donne le focus à la question suivante
    /// </summary>
    /// <param name="questionQuizz">QuestionQuiz sur lequel on souhaite répondre. Met à jour La réponse libre ou le refus de réponse le cas échéant</param>
    /// <param name="userResponses">Liste des réponses utilisateur associées au questionQuiz</param>
    public void SetQuestionQuizzAnswer(QuestionQuizz questionQuizz, List<UserResponse> userResponses)
    {
        //throw new Exception("Méthode non implémentée");
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            using(var dbContextTransaction = db.Database.BeginTransaction())
            {
                // On récupère l'enregistrement qui correspond au question Quiz
                var myQuestionQuiz = db.QuestionQuizz.Where(e => e.Id == questionQuizz.Id).FirstOrDefault();

                if (myQuestionQuiz == null)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception("QuestionQuiz Id non trouvé");
                }
                else
                {
                    //Enregistrement existe
                    //On vérifie si certains champs ont été modifiés et on réalise la modif le cas échéant
                    if (questionQuizz.FreeAnswer != null) myQuestionQuiz.FreeAnswer = questionQuizz.FreeAnswer;
                    if (questionQuizz.RefuseToAnswer == true) myQuestionQuiz.RefuseToAnswer = questionQuizz.RefuseToAnswer;


                    //On écrit la liste des réponses de l'utilisateur
                    throw new Exception("Méthode non implémentée"); // A traiter
                    try
                    {
                        foreach (var userResponse in userResponses)
                        {
                            // Vérification que la réponse utilisateur est apporté pour le questionQuiz donné et qu'il répond aussi à une proposition de réponse associé au questionQuiz
                            if (questionQuizz.Id != userResponse.QuestionQuizzId) throw new Exception("Discordance userRéponse et questionQuiz");
                            var questionId = (db.Response.Where(e => e.Id == userResponse.ResponseId).FirstOrDefault()).QuestionId;
                            if (questionQuizz.QuestionId != ((db.Response.Where(e => e.Id == userResponse.ResponseId).FirstOrDefault()).QuestionId))
                                throw new Exception("Discordance userResponse et questionId du questionQuiz");

                            // Ajout de la userResponse
                            db.UserResponse.Add(userResponse);
                            db.SaveChanges();

                        }
                    } catch (NullReferenceException)
                    {
                        //On passe cette exception sans la lever
                    }
                    

                    //On met à jour le numéro de la question active
                    var myQuiz = db.Quizz.Where(e => e.Id == myQuestionQuiz.QuizzId).FirstOrDefault();
                    if (myQuiz == null)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("Quiz Id non trouvé");
                    }
                    else
                    {
                        //On incrément la question active
                        myQuiz.ActiveQuestionNum += 1;
                        //Si on est arrivé à la fin du quiz on le marque dans la table
                        if (myQuiz.QuestionCount < myQuiz.ActiveQuestionNum) myQuiz.QuizzState = QuizzStateEnum.Done;
                        else myQuiz.QuizzState = QuizzStateEnum.InProgress;
                    }
                    db.SaveChanges();
                    // On est ici donc tout c'est bien passé
                    dbContextTransaction.Commit();
                }
            }
        }
    }

    #region analyse des réponses
    /// <summary>
    /// Récupère une liste des mauvaises userResponse pour une questionQuiz donnée.
    /// Si userResponse.Response.IsTrue = true c'est que le user n'a pas sélectionné la réponse alors que c'étatit une bonne réponse
    /// </summary>
    /// <param name="questionQuizId">Id de la questionQuiz</param>
    /// <returns></returns>
    public List<UserResponse> GetFalseAnswersForAQuestionQuiz(int questionQuizId)
    {
        var returnedResponses = new List<UserResponse>();
        using (FilRougeDBContext db = new FilRougeDBContext())
        {
            var myQuestionQuiz = db.QuestionQuizz.Where(e => e.Id == questionQuizId).FirstOrDefault();

            //Liste des réponse répondues et fausses
            var myBadResponses = db.UserResponse
                                .Include(nameof(Response))
                                .Where(e => (e.QuestionQuizzId == myQuestionQuiz.Id) && (e.Response.IsTrue == false))
                                .ToList();
            //Liste des réponses bonne mais non sélectionnées par l'utilisateur
            List<Response> myResponses = db.UserResponse
                                .Include(nameof(Response))
                                .Where(e => (e.QuestionQuizzId == myQuestionQuiz.Id))
                                .Select(e => e.Response).ToList();
            var myForgetResponses = db.Response
                                .Where(e => ((e.IsTrue == true) && (e.QuestionId == myQuestionQuiz.Id) && !(myResponses.Contains(e))))
                                .ToList();

            var myForgetUserResponses = new List<UserResponse>();

            foreach(var myForgetResponse in myForgetResponses)
            {
                myForgetUserResponses.Add(new UserResponse()
                {
                    QuestionQuizzId = myQuestionQuiz.Id,
                    Response=myForgetResponse,
                });
            }
            myBadResponses.AddRange(myForgetUserResponses.ToArray());
            returnedResponses.AddRange(myBadResponses);
        }
            


        return returnedResponses;
    }
    #endregion
}



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
