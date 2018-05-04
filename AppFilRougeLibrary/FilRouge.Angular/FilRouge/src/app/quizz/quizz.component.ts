import { Component, OnInit, Injectable, OnDestroy } from '@angular/core';
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
export class QuizzComponent implements OnInit, OnDestroy {
QuizzId: number;
UserFirstName: string;
UserLastName: string;
Technology: string;
Heures: number;
Minutes: number;
Secondes: number;
counterSubscription: Subscription;
  constructor(private questionService: QuestionServiceService, private route: ActivatedRoute) { }

  ngOnInit() {

    // Timer
    this.Minutes = 0;
    this.Heures = 0;

    this.QuizzId = this.route.snapshot.params['id'];
    const httpRequest = Observable.interval(1000);
    this.questionService.getQuestionQuiz(this.QuizzId);
    this.Technology = this.questionService.questionQuiz.Quiz.Technology.Name;
    this.UserFirstName = this.questionService.questionQuiz.Quiz.UserFirstName;
    this.UserLastName = this.questionService.questionQuiz.Quiz.UserFirstName;

    // const counter = Observable.interval(1000);
    // this.counterSubscription =
    // counter.subscribe(
    //   (value) => {
    //     // if (this.Secondes === 59) {
    //     //   this.Minutes ++;
    //     //   value = 0;
    //     //   if (this.Minutes === 59 && this.Secondes === 59) {
    //     //     this.Heures++;
    //     //     this.Minutes = 0;
    //     //     this.Secondes = 0;
    //     //     value = 0;
    //     //   }
    //     // }
    //     // this.Secondes = value;
    //     this.setTime(value);
    //   },
    //   (error) => {
    //     console.log('Error: ' + error );
    //   },
    //   () => {
    //     console.log('Observable complete!');
    //   }
    // );

  }
  ngOnDestroy() {
    this.counterSubscription.unsubscribe();
  }
  setTime(secondes: number) {
    this.Secondes = secondes % 60;
    this.Minutes = Math.floor(secondes / 60);
  }
}
