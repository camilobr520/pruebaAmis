import { Component,Inject,ViewChild,ElementRef, Output,EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormularioService } from '../service/formulario.service';
import {Formulario, Generos}from '../interfaces';
import { Observable } from 'rxjs';
import { Reply,Cursos } from '../interfaces';
import { DatePipe } from "@angular/common";
import {FormControl} from '@angular/forms';



@Component({
  selector: 'nuevoformulario-app',
  templateUrl: './nuevoformulario.component.html'
})
export class NuevoFormularioComponent {
    lstGeneros:Generos[]=[];
    lstCursos:Cursos[]=[];
    formulario:Formulario={} as any;

    @Output() actualizar=new EventEmitter<number>();
    
  constructor(
    http:HttpClient,@Inject("BASE_URL")baseUrl:string,
    protected formularioService:FormularioService
    ) {
        this.GetGeneros();
        this.GetCursos();
  }



  public GetGeneros(){
    this.formularioService.GetGeneros().subscribe(res=>{
        this.lstGeneros=res.data;
    })
  }
  public GetCursos(){
    this.formularioService.GetCursos().subscribe(res=>{
        this.lstCursos=res.data;
    })
  }

  public Save(){
    this.formularioService.AddFormulario(this.formulario).subscribe(res=>{
        this.actualizar.emit(1);
    })
  }

}
