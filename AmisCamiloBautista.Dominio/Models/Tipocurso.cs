using System;
using System.Collections.Generic;

#nullable disable

namespace AmisCamiloBautista.Dominio.Models
{
    public partial class Tipocurso
    {
        public Tipocurso()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
