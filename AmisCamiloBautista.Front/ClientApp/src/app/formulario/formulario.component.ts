import { Component,Inject,ViewChild,ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormularioService } from '../service/formulario.service';
import {Formulario}from '../interfaces';
import { Observable } from 'rxjs';
import {FormControl} from '@angular/forms';
import { Reply } from '../interfaces';
import { DatePipe } from "@angular/common";
import { NuevoFormularioComponent } from '../nuevoformulario/nuevoformulario.component';
import { debug } from 'console';

@Component({
  selector: 'formulario-app',
  templateUrl: './formulario.component.html'
})
export class FormularioComponent {
public lstForm:Formulario[];
id:number;
  textControl=new FormControl('');
  nameControl=new FormControl('');


 constructor(http:HttpClient,@Inject("BASE_URL")baseUrl:string,
 protected formularioService:FormularioService
 ) {
      this.GetFormularios();
  }

  public GetFormularios(){
    this.formularioService.GetFormularios().subscribe(res=>{
        this.lstForm=res.data;
    })
  }
  public GetFormulariosId(){
      debugger
    this.formularioService.GetFormulariosId(this.id).subscribe(res=>{
        this.lstForm=res.data;
    })
  }


  public NuevoRegistro(i){
      if(i==1){
        this.GetFormularios();
      }
  }

}
