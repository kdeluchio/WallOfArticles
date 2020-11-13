import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IArticle } from '../interfaces/iarticle';
import { INewArticle } from '../interfaces/INewArticle';
import { IResponse } from '../interfaces/iresponse';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private http : HttpClient) { }

  GetById(id : number) : Observable<IArticle>{

    const params: {[param: string]: string} = {};
    params.id = id.toString();
      
    return this.http.get<IArticle>(`${environment.url}/Article/GetById`, { params});
  }

  GetAll() : Observable<IArticle[]>{
      
    return this.http.get<IArticle[]>(`${environment.url}/Article/GetAll`);
  }  
  
  Liked(id : number) : Observable<IResponse>{

    return this.http.put<IResponse>(`${environment.url}/Article/Liked/${id}`, {id}); 
  }

  Delete(id : number) : Observable<IResponse>{

    const params: {[param: string]: string} = {};
    params.id = id.toString();
      
    return this.http.delete<IResponse>(`${environment.url}/Article/Remove/${id}`);
  }

  Create(article : INewArticle) : Observable<IResponse>{
      
    return this.http.post<IResponse>(`${environment.url}/Article/Create`, article);
  }

}
