import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/services/question.service';
import { Question } from 'src/models/Question';
import { Answer } from 'src/models/Answer';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
})
export class QuestionsComponent implements OnInit {
  
  questions:Question[];
  answers:Answer[];
  currentQuestion:Question;

  constructor(private questionService:QuestionService) { }

  onQuestionSelect(question:Question){
    this.questionService.getAnswersByQuestionId(question.id).subscribe(item=>this.answers=item);
    this.currentQuestion=question;
  }

  ngOnInit() {
    this.questions=<Question[]>JSON.parse(localStorage.getItem("questions"));

    this.currentQuestion=this.questions.length>0?this.questions[0]:null;

    this.questionService.getAnswersByQuestionId(this.currentQuestion.id)
      .subscribe(item=>this.answers=item);
  }
}
