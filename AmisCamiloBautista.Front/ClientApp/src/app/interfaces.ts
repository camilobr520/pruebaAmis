export interface Formulario{
    id:number,
    nombre:string,
    apellidos:string;
    fechaNacimiento:Date;
    lugarNacimiento:string;
    lugarResidencia:string;
    idgenero:number;
    hobbies:string;
    idcurso:number;
  }


export interface Reply{
  success: number;
  data:Formulario[];
  message:string;
}

export interface Generos{
  id: number;
  nombre:string;
}

export interface Cursos{
  id: number;
  nombre:string;
  // idmodalidad:number;
  // duracion_horas:number;
  // idtipo:number,
  // idcategoria:number,
  // idlineacarrera:number;
  // idprofesor:number;
  
}
