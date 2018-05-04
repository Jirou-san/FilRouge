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
    QuestionSubject = new Subject<any[]>();

    // QuestionSubject = new Subject<any[]>();
    // emitQuestionSubject() {
    //     emitQuestionSubject.next(this.questionQuiz.slice());
    // }

// dans app.componenet
// ngOnInit(){
//     this.biduleSubscription = this.QuestionService.biduleSubject.subscribe(
//         (bidules : any[] => {
//             this.bidules
//         })
//     )
// }

constructor(private httpClient: HttpClient) {
    //this.server = 'localhost:81';
    this.server = '10.110.12.51:81'; //Server IIS Marc au 20180503
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

// getQuestionQuiz_origine(quizId) {
//     this.quizId = quizId;
//     this.httpClient
//         .get<any>('http://' + this.server + '/api/questionquizz/active/' + quizId)
//         .subscribe(
//             (response) => {
//                 //this.questionQuiz = JSON.parse(response);
    
//                 this.userFirstName = response.UserFirstName;
//                 this.userLastName = response.Quizz.UserLastName;
//                 this.technology = response.Quizz.Technology;
//                 this.activeQuestionNum = response.Quizz.ActiveQuestionNum;
//                 this.questionTotalCount = response.Quizz.QuestionCount;
//                 this.quizState = response.Quizz.QuizzState;

//                 this.question = response.Question.Content;
//                 this.isFreeAnswer = response.Question.IsFreeAnswer;

//                 this.comment = response.Comment;
//                 this.freeAnswer = response.FreeAnswer;
//                 this.refuseToAnswer = response.RefuseToAnswer;
//                 console.log('Requete OK username : ' + response.UserFirstName + response.UserLastName );

//             },
//             (error) => {
//                 this.questionQuiz = null;
//                 console.log('Error service getQuestionQuiz ! :' + error);
//             }
//         );
// }

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
                        this.userFirstName = res[0].UserFirstName;
                        this.userLastName = res[0].Quizz.UserLastName;
                        this.technology = res[0].Quizz.Technology;
                        this.activeQuestionNum = res[0].Quizz.ActiveQuestionNum;
                        this.questionTotalCount = res[0].Quizz.QuestionCount;
                        this.quizState = res[0].Quizz.QuizzState;

                        this.question = res[0].Question.Content;
                        this.isFreeAnswer = res[0].Question.IsFreeAnswer;

                        this.comment = res[0].Comment;
                        this.freeAnswer = res[0].FreeAnswer;
                        this.refuseToAnswer = res[0].RefuseToAnswer;
                        this.questionQuiz = res[0];
                        // var data=res.constructor();
                        // this.questionQuiz= <QuestionQuiz[]>res.data;
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

class Quiz {
    public Id: number;
    public Technology;
}
class QuestionQuiz {
    public quizId: number;

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