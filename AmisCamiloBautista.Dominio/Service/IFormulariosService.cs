using AmisCamiloBautista.Dominio.Models.Reply;
using AmisCamiloBautista.Dominio.Models.Requets;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmisCamiloBautista.Dominio.Service
{
    public interface IFormulariosService
    {
        public Reply GetFormularios();
        public Reply GetFormulariosId(int id);
        public Reply AddFormulario(EstudiantesRequest model);
        public Reply EditFormulario(EstudiantesRequest model);
        public Reply DeleteFormulario(EstudiantesRequest model);

        public Reply GetGeneros();
        Reply GetCursos();



    }
}
