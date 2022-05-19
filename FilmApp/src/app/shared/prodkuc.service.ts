import { Injectable } from '@angular/core';
import { ProdKuca } from './film.model';
import { HttpClient } from "@angular/common/http"
@Injectable({
  providedIn: 'root'
})
export class ProdkucService {

  constructor(private http:HttpClient) { }
  formData2:ProdKuca=new ProdKuca();
  list2: ProdKuca[];
  readonly baseURL="http://localhost:51148/api/ProdKucas"

  postProdKuca(){
    return this.http.post(this.baseURL,this.formData2)
  }
  putProdKuca(){
    return this.http.put(`${this.baseURL}/${this.formData2.kucaID}`, this.formData2);
  }
  
  deleteProdKuca(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)

  }
  refreshlist(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=> this.list2=res as ProdKuca[]);
}
}
