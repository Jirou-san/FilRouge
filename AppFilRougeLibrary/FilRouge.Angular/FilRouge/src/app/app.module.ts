import { QuizzComponent } from './quizz/quizz.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    QuizzComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot()
  ],
  // tslint:disable-next-line:no-trailing-whitespace
  
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
