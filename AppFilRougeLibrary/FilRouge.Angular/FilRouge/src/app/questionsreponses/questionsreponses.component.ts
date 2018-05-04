import { Component, OnInit } from '@angular/core';
import { QuestionServiceService } from '../Services/QuestionService.service';

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
    this.QuestionNumber = 50;
    this.QuestionNumberMax = 100;
  }
  maxQuestionNumer() {
   this.QuestionNumberMax = 100;
  }
  actualQuestionNumber() {

    this.QuestionNumber = 50;
  }
}
