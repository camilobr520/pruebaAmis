using System;
using System.Collections.Generic;

#nullable disable

namespace AmisCamiloBautista.Dominio.Models
{
    public partial class Profesore
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public int Idgenero { get; set; }
        public string Hobbies { get; set; }
    }
}
