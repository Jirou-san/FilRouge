import { QuizzComponent } from './quizz/quizz.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { QuestionsreponsesComponent } from './questionsreponses/questionsreponses.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';

const appRoutes: Routes = [
  {
    path: 'quizz', component: QuizzComponent
  },
  {
    path: '', component: AppComponent
  },
  {
    path: 'doquizz', component: QuestionsreponsesComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    QuizzComponent,
    QuestionsreponsesComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  // tslint:disable-next-line:no-trailing-whitespace
  
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
