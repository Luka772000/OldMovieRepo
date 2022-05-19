import { Injectable } from '@angular/core';
import { Film } from './film.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class filmService {

  constructor(private http:HttpClient) { }

  formData:Film=new Film();
  list: Film[];
  readonly baseURL="http://localhost:51148/api/FilmDetails"

  postFilm(){
    return this.http.post(this.baseURL,this.formData)
  }
  putFilm(){
    return this.http.put(`${this.baseURL}/${this.formData.filmId}`, this.formData);
  }
  
  deleteFilm(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)

  }
  refreshlist(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=> this.list=res as Film[]);
  }
}
