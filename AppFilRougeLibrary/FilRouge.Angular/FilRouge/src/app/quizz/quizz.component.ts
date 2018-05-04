import { Component, OnInit, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/interval';
import { Subscription } from 'rxjs/Subscription';
import { QuestionServiceService } from '../Services/QuestionService.service';
import { ActivatedRoute } from '@angular/router';
@Injectable()
@Component({
  selector: 'app-quizz',
  templateUrl: './quizz.component.html',
  styleUrls: ['./quizz.component.scss']
})
export class QuizzComponent implements OnInit {
QuizzId: number;
UserFirstName: string;
UserLastName: string;
Technology: string;
Minutes: number;
Secondes: number;
  constructor(private questionService: QuestionServiceService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.QuizzId = this.route.snapshot.params['id'];
    // const counterS = Observable.interval(1000);
    // const counterM = Observable.interval(60000);
    const httpRequest = Observable.interval(1000);
    this.questionService.getQuestionQuiz(this.QuizzId);
    this.Technology = this.questionService.technology;
this.UserFirstName = this.questionService.userFirstName;
this.UserLastName = this.questionService.userLastName;

  }

}
