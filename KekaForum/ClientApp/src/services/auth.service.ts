import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  readonly baseURL = 'https://localhost:5001/api/auth';

  constructor(private http:HttpClient) { }

  login(loginCredentials:any):Observable<any>{
    return this.http.post(`${this.baseURL}/login`, loginCredentials);
  } 

  register(userDetails:any):Observable<any>{
    return this.http.post(`${this.baseURL}/register`, userDetails);
  }
}
