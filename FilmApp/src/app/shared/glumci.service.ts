import { Injectable } from '@angular/core';
import { Glumac } from './film.model';
import { HttpClient } from "@angular/common/http"
@Injectable({
  providedIn: 'root'
})
export class GlumciService {

  constructor(private http:HttpClient) { }
  formData1:Glumac=new Glumac();
  list1: Glumac[];
  readonly baseURL="http://localhost:51148/api/Glumacs"

  postGlumac(){
    return this.http.post(this.baseURL,this.formData1)
  }
  putGlumac(){
    return this.http.put(`${this.baseURL}/${this.formData1.glumacID}`, this.formData1);
  }
  
  deleteGlumac(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)

  }
  refreshlist(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=> this.list1=res as Glumac[]);
}
}
