using AmisCamiloBautista.Dominio.Models;
using AmisCamiloBautista.Dominio.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmisCamiloBautista.Dominio.Models.Requets;
using System.Data.SqlClient;

namespace AmisCamiloBautista.Dominio.Service
{
    public class FormulariosService:IFormulariosService
    {
        public Reply GetFormularios()
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                try
                {
                    var lst = (from d in db.Estudiantes
                               join k in db.Generos on d.Idgenero equals k.Id
                               join j in db.Inscripciones on d.Id equals j.Idestudiante
                               join m in db.Cursos on j.Idcurso equals m.Id
                               join n in db.Profesores on m.Idprofesor equals n.Id
                               join h in db.Tipocursos on m.Idtipo equals h.Id
                                       select new 
                                       {
                                        Id=d.Id,
                                        Nombre=d.Nombre,
                                        Apellidos=d.Apellidos,
                                        FechaNacimiento=d.FechaNacimiento,
                                        LugarNacimiento=d.LugarNacimiento,
                                        LugarResidencia=d.LugarResidencia,
                                        Idgenero=d.Idgenero,
                                        Genero=k.Nombre,
                                        Hobbies=d.Hobbies,
                                        Curso=m.Nombre,
                                        Profesor=n.Nombre,
                                        TipoCurso=h.Nombre

                                       }).ToList();

                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

        public Reply GetFormulariosId(int id)
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                try
                {
                    var lst = (from d in db.Estudiantes
                               join k in db.Generos on d.Idgenero equals k.Id
                               join j in db.Inscripciones on d.Id equals j.Idestudiante
                               join m in db.Cursos on j.Idcurso equals m.Id
                               join n in db.Profesores on m.Idprofesor equals n.Id
                               join h in db.Tipocursos on m.Idtipo equals h.Id
                               where d.Id == id
                               select new
                               {
                                   Id = d.Id,
                                   Nombre = d.Nombre,
                                   Apellidos = d.Apellidos,
                                   FechaNacimiento = d.FechaNacimiento,
                                   LugarNacimiento = d.LugarNacimiento,
                                   LugarResidencia = d.LugarResidencia,
                                   Idgenero = d.Idgenero,
                                   Genero = k.Nombre,
                                   Hobbies = d.Hobbies,
                                   Curso = m.Nombre,
                                   Profesor = n.Nombre,
                                   TipoCurso = h.Nombre

                               }).ToList();

                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

        public Reply AddFormulario(EstudiantesRequest model)
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Estudiante oestudiante = new Estudiante();
                    Inscripcione oinscripciones = new Inscripcione();
                    oestudiante.Nombre = model.Nombre;
                    oestudiante.Apellidos = model.Apellidos;
                    oestudiante.FechaNacimiento = model.FechaNacimiento;
                    oestudiante.LugarNacimiento = model.LugarNacimiento;
                    oestudiante.LugarResidencia = model.LugarNacimiento;
                    oestudiante.Idgenero = model.Idgenero;
                    oestudiante.Hobbies = model.Hobbies;
                    db.Estudiantes.Add(oestudiante);
                    db.SaveChanges();
                    oinscripciones.Idcurso = model.IdCurso;
                    oinscripciones.Idestudiante = oestudiante.Id;
                    db.Inscripciones.Add(oinscripciones);
                    db.SaveChanges();
                    oReply.Success = 1;
                    List<Estudiante> lst = db.Estudiantes.ToList();
                    
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }
  
        public Reply EditFormulario(EstudiantesRequest model)
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                oReply.Success = 0;
                try
                {
                    Estudiante oestudiante = db.Estudiantes.Find(model.Id);
                    oestudiante.Nombre = model.Nombre;
                    oestudiante.Apellidos = model.Apellidos;
                    oestudiante.FechaNacimiento = model.FechaNacimiento;
                    oestudiante.LugarNacimiento = model.LugarNacimiento;
                    oestudiante.LugarResidencia = model.LugarNacimiento;
                    oestudiante.Idgenero = model.Idgenero;
                    oestudiante.Hobbies = model.Hobbies;
                    db.Entry(oestudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oReply.Success = 1;
                    List<Estudiante> lst = db.Estudiantes.ToList();
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

        public Reply DeleteFormulario(EstudiantesRequest model)
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oRespuesta = new Reply();
                oRespuesta.Success = 0;
                try
                {
                    Estudiante oestudiante = db.Estudiantes.Find(model.Id);
                    db.Remove(oestudiante);
                    db.SaveChanges();
                    oRespuesta.Success = 1;

                }
                catch (Exception ex)
                {
                    oRespuesta.Message = ex.Message;
                }




                return oRespuesta;
            }

        }

        public Reply GetGeneros()
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                try
                {
                    var lst = db.Generos.ToList();
                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }


        public Reply GetCursos()
        {
            using (PruebaAmisContext db = new PruebaAmisContext())
            {
                Reply oReply = new Reply();
                try
                {
                    var lst = db.Cursos.ToList();
                    oReply.Success = 1;
                    oReply.Data = lst;
                }
                catch (Exception ex)
                {
                    oReply.Message = ex.Message;
                }

                return oReply;
            }
        }

    }
}
