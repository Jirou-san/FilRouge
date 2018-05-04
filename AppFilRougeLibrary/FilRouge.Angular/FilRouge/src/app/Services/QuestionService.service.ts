import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuestionServiceService {
    public server: string;
    public quizId: number;
    public questionQuiz: object;
    
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

getQuestionQuiz() {
    this.httpClient
        .get<any>('http://' + this.server + '/api/questionquizz/active/' + this.quizId)
        .subscribe(
            (response) => {
                this.questionQuiz = JSON.parse(response);
    
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
            },
            (error) => {
                this.questionQuiz = null;
                console.log('Error service getQuestionQuiz ! :' + error);
            }
        );
}
setQuestionQuiz(myQuestionQuiz) {
    this.httpClient
        .post('http://' + this.server + 'GET /api/questionquizz', myQuestionQuiz)
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
