import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Message, MyResponse } from '../interfaces';
import { Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { Formulario } from '../interfaces';
import { Reply } from '../interfaces';




const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}
const httpOption={
  headers:new HttpHeaders({
    'Content-Type':'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class FormularioService {
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

   GetFormularios():Observable<Reply> {
   return this.http.get<Reply>(this.baseUrl + 'api/formulario/get');
  }
  GetFormulariosId(id:number):Observable<Reply> {
    return this.http.get<Reply>(this.baseUrl + 'api/formulario/getid/'+ id);
   }

   GetGeneros():Observable<Reply> {
    return this.http.get<Reply>(this.baseUrl + 'api/formulario/getGeneros');
   }

   GetCursos():Observable<Reply> {
    return this.http.get<Reply>(this.baseUrl + 'api/formulario/getCursos');
   }
 
   AddFormulario(formulario:Formulario):Observable<Reply>{
     debugger
    return this.http.post<Reply>(this.baseUrl + 'api/formulario/addFormulario',formulario,httpOption); 
  }

 


  



}
