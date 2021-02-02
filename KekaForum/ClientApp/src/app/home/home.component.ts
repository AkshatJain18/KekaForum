import { Component } from '@angular/core';
import { NavbarService } from 'src/services/navbar.service';
import { User } from 'src/models/User';
import { Question } from 'src/models/Question';
import { QuestionService } from 'src/services/question.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  
  isFormVisible:boolean;
  user:User;
  questionsList:Question[];

  constructor(private navbarService:NavbarService,private questionService:QuestionService){
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  openQuestionForm(){
    this.isFormVisible=true;
    this.navbarService.hideSideNav();
    this.navbarService.hideTopNav();
  }

  addQuestion(){
    this.isFormVisible=false;
  }

  ngOnInit(){
    this.navbarService.showSideNav();
    this.navbarService.showTopNav();
 
    this.questionService.getAllQuestions()
    .subscribe(
      (item)=>
      {
        this.questionsList=item;
        localStorage.setItem('questions', JSON.stringify(this.questionsList));
      }
    );
  }
}
