import { Component, OnInit } from '@angular/core';
import { QuestionServiceService } from '../Services/QuestionService.service'

@Component({
  selector: 'app-questionsreponses',
  templateUrl: './questionsreponses.component.html',
  styleUrls: ['./questionsreponses.component.scss']
})
export class QuestionsreponsesComponent implements OnInit {
  public QuestionNumber: Number;
  public QuestionNumberMax: Number;
  constructor(private quizzService: QuestionServiceService) { }

  ngOnInit() {
    this.QuestionNumber = 0;
    this.QuestionNumberMax = 0;
  }
  maxQuestionNumer()
  {
   this.QuestionNumberMax = this.quizzService.questionQuiz.Quizz.QuestionCount;
  }
  actualQuestionNumber()
  {
    this.QuestionNumber = this.quizzService.questionQuiz.Quizz.ActiveQuestionNum;
  }
}