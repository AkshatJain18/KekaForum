import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from 'src/models/Question';
import { Category } from 'src/models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  readonly baseURL = 'https://localhost:5001/api/categories';

  constructor(private httpClient:HttpClient) { }

  getAllCategories():Observable<any>{
    return this.httpClient.get(`${this.baseURL}`);
  }

  postCategory(category:Category):Observable<any>{
    return this.httpClient.post(`${this.baseURL}`,category);
  }
}
