import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class QuestionServiceService {
    public server: string;
    public quizId: number;
    public questionQuiz: any; 
    public userFirstName: string;
    public userLastName: string;
    public technology: string;
    public activeQuestionNum: number;
    public questionTotalCount: number;
    public quizState: number;
    public question: string;
    public isFreeAnswer: boolean;
    public comment: string;
    public freeAnswer: string;
    public refuseToAnswer: string;
    public userResponses;
    QuestionSubject = new Subject<any>();

    // QuestionSubject = new Subject<any[]>();
    emitQuestionSubject() {
         this.emitQuestionSubject.next(this.questionQuiz.slice());
     }

// dans app.componenet
// ngOnInit(){
//     this.biduleSubscription = this.QuestionService.biduleSubject.subscribe(
//         (bidules : any[] => {
//             this.bidules
//         })
//     )
// }

constructor(private httpClient: HttpClient) {
    this.server = 'localhost:81';
    //this.server = '10.110.12.51:81'; //Server IIS Marc au 20180503
}

// getQuiz() {
//     this.httpClient
//         .get<any>('http://' + this.server + '/api/Quizz/' + this.quizId )
//         .subscribe(
//             (response) => {
//                 var techno = response.Technology.Name;
//                 var difficulty = response.Difficulty.Name;
//                 var userFirstName = response.UserFirstName;
//                 var userLastName = response.UserLastName;
//                 var activeQuestionNum = response.ActiveQuestionNum;
//                 if (activeQuestionNum < 1) { activeQuestionNum = 1; }
//                 var totalQuestionNum = response.QuestionCount;
//             },
//             (error) => {
//                 console.log('Error service getQuiz ! :' + error);
//             }
//         );
// }

getQuestionQuiz_origine(quizId) {
    this.quizId = quizId;
    this.httpClient
        .get<any>('http://' + this.server + '/api/questionquizz/active/' + quizId)
        .subscribe(
            (response) => {
                //this.questionQuiz = JSON.parse(response);
    
                this.userFirstName = response.UserFirstName;
                this.userLastName = response.Quizz.UserLastName;
                this.technology = response.Quizz.Technology;
                this.activeQuestionNum = response.Quizz.ActiveQuestionNum;
                this.questionTotalCount = response.Quizz.QuestionCount;
                this.quizState = response.Quizz.QuizzState;

                this.question = response.Question.Content;
                this.isFreeAnswer = response.Question.IsFreeAnswer;

                this.comment = response.Comment;
                this.freeAnswer = response.FreeAnswer;
                this.refuseToAnswer = response.RefuseToAnswer;
                console.log('Requete OK username : ' + response.UserFirstName + response.UserLastName );

            },
            (error) => {
                this.questionQuiz = null;
                console.log('Error service getQuestionQuiz ! :' + error);
            }
        );
}

getQuestionQuiz(quizId) {

    this.quizId = quizId;
    const url = 'http://' + this.server + '/api/questionquizz/active/' + quizId;
    let promise = new Promise(() => {
        this.httpClient.get(url)
                .toPromise()
                .then(
                    // Code à exécuter après récupération du résultat de la requête
                    res => { // success
                        console.log(res);
                        // this.userFirstName = res.UserFirstName;
                        // this.userLastName = res.Quizz.UserLastName;
                        // this.technology = res.Quizz.Technology;
                        // this.activeQuestionNum = res.Quizz.ActiveQuestionNum;
                        // this.questionTotalCount = res.Quizz.QuestionCount;
                        // this.quizState = res.Quizz.QuizzState;

                        // this.question = res.Question.Content;
                        // this.isFreeAnswer = res.Question.IsFreeAnswer;

                        // this.comment = res.Comment;
                        // this.freeAnswer = res.FreeAnswer;
                        // this.refuseToAnswer = res.RefuseToAnswer;
                        this.questionQuiz = < QuestionQuiz>res;
                        this.emitQuestionSubject();
                        //var data=res.constructor();
                        //this.questionQuiz= <QuestionQuiz[]>res.data;
                        console.log(this.questionQuiz);
                    }
                );

    });
    return promise;
}
setQuestionQuiz(myQuestionQuiz) {
    this.httpClient
        .post('http://' + this.server + '/api/questionquizz', myQuestionQuiz)
        .subscribe(
            () => {
                console.log('Enregistrement réponses ok');
            },
            (error) => {
                console.log('Error service setQuestionQuiz ! :' + error);
            }
        );
}
}

class Quizz {
    public Id: number;
    public TechnologyId: number;
    public ContactId: string;
    public DifficultyId: number;
    public QuizzState: number;
    public UserLastName: string;
    public UserFirstName: string;
    public HasFreeQuestion: boolean;
    public QuestionCount: number;
    public ExternalNum: string;
    public ActiveQuestionNum: number;
    public Technology: Technology;

    constructor(Id: number
        , TechnologyId: number
        , ContactId: string
        , DifficultyId: number
        , QuizzState: number
        , UserLastName: string
        , UserFirstName: string
        , HasFreeQuestion: boolean
        , QuestionCount: number
        , ExternalNum: string
        , ActiveQuestionNum: number
        , Technology: Technology){

    }
}

class QuestionQuiz {
    public Id: number;
    public QuizzId: number;
    public QuestionId: number;
    public DisplayNum: number;
    public FreeAnswer: string;
    public Comment: string;
    public RefuseToAnswer: string;
    public Question: Question;
    public Quizz: Quizz;
    public UserResponses: UserResponse[];

    constructor(Id: number
        , QuizzId: number
        , QuestionId: number
        , DisplayNum: number
        , FreeAnswer: string
        , Comment: string
        , RefuseToAnswer: string
        , Question: Question
        , Quizz: Quizz
        , UserResponses: UserResponse[]){

    }
}

class Technology {
    public Id: number;
    public DisplayNum: number;
    public Name: string;
    public IsActive: boolean;

    constructor(Id: number
        , DisplayNum: number
        , Name: string
        , IsActive: boolean
    ){

    }
}

class Question{
    public Id: number;
    public TechnologyId: number;
    public DifficultyId: number;
    public Content: string;
    public IsEnable: boolean;
    public IsFreeAnswer: boolean;
    public UserResponses: UserResponse[];
    public Responses: Response[];
    public Technology: Technology;
    //public Difficulty: Difficulty;

    constructor(Id: number
        , TechnologyId: number
        , DifficultyId: number
        , Content: string
        , IsEnable: boolean
        , IsFreeAnswer: boolean
        , UserResponses: UserResponse[]
        , Responses: Response[]
        , Technology: Technology
    ){

    }
}

class Response{
    public Id: number;
    public QuestionId: number;
    public Content: string;
    public Explanation:  string;
    public IsTrue: boolean;
    //public Question Question

    constructor(Id: number
        , QuestionId: number
        , Content: string
        , Explanation:  string
        , IsTrue: boolean){

    }
}

class UserResponse{
    public QuestionQuizzId: number;
    public ResponseId: number;
    //public virtual Response Response { get; set; }
    //public virtual Question Question { get; set; }
    //public virtual QuestionQuizz QuestionQuizz{ get; set; }

    constructor(QuestionQuizzId: number
        , ResponseId: number){

    }
}

// maFonction() {
//     let promise = new Promise(() =>{
//         httPClient.get(Url)
//                 .toPromise()
//                 .then(
//                     //Code à exécuter après récupération du résultat de la requête
//                     res => { //success
//                         console.log(res);
//                         var data=res.constructor();
//                         this.questionQuiz= <QuestionQuiz[]>res.data;
//                         console.log(this.questionQuiz);
//                     }
//                 );

//     });
//     return promise;
// }