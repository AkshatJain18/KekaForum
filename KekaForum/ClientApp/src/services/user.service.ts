import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from 'src/models/Question';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly baseURL = 'https://localhost:5001/api/users';

  constructor(private httpClient:HttpClient) { }

  getAllUsers():Observable<any>{
    return this.httpClient.get(`${this.baseURL}`);
  }

  getUserById(userId:any):Observable<any>{
    return this.httpClient.get(`${this.baseURL}/${userId}`);
  }
}
