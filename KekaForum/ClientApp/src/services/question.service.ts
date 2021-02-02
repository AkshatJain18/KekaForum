import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from 'src/models/Question';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  readonly baseURL = 'https://localhost:5001/api/questions';

  constructor(private httpClient:HttpClient) { }

  getAllQuestions():Observable<any>{
    return this.httpClient.get(`${this.baseURL}`);
  }

  getAllQuestionsByUserId(userId:any):Observable<any>{
    return this.httpClient.get(`${this.baseURL}/userId/${userId}`)
  }

  getAnsweredQuestionsByUserId(userId:any):Observable<any>{
    return this.httpClient.get(`${this.baseURL}/userId/${userId}/answered`)
  }

  getAnswersByQuestionId(questionId:number):Observable<any>{
    return this.httpClient.get(`${this.baseURL}/${questionId}/answers`);
  }

  postQuestion(question:Question):Observable<any>{
    return this.httpClient.post(`${this.baseURL}`,question);
  }
}
