import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuestionServiceService {
    public server: string;
    public quizId: number;
    public questionQuiz: JSON;

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
        .get<any>('http://' + this.server + 'GET /api/questionquizz/active/' + this.quizId)
        .subscribe(
            (response) => {
                this.questionQuiz = response;

                // this.questionQuiz.Quizz.UserFirstName;
                // this.questionQuiz.Quizz.UserLastName;
                // this.questionQuiz.Quizz.TechnologyId;
                // this.questionQuiz.Quizz.ActiveQuestionNum;
                // this.questionQuiz.Quizz.QuestionCount;
                // this.questionQuiz.Quizz.QuizzState;

                // this.questionQuiz.Question.Content;
                // this.questionQuiz.Question.IsFreeAnswer;

                // this.questionQuiz.Comment;
                // this.questionQuiz.FreeAnswer;
                // this.questionQuiz.RefuseToAnswer;
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
