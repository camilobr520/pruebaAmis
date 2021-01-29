using System;
using System.Collections.Generic;
using System.Text;

namespace AmisCamiloBautista.Dominio.Models.Requets
{
    public class EstudiantesRequest
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Id { get; set; }
        public string LugarNacimiento { get; set; }
        public string LugarResidencia { get; set; }
        public int Idgenero { get; set; }
        public string Hobbies { get; set; }

        public int IdCurso { get; set; }
    }
}
