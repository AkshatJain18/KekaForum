import { Component, OnInit, Input } from '@angular/core';
import { Answer } from 'src/models/Answer';
import { QuestionService } from 'src/services/question.service';
import { Question } from 'src/models/Question';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
})
export class AnswerComponent implements OnInit {

  @Input() answers:Answer[];
  @Input() question:Question;

  constructor() { 
    
  }

  ngOnInit() {
    
  }

}
