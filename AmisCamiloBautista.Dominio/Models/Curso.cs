using System;
using System.Collections.Generic;

#nullable disable

namespace AmisCamiloBautista.Dominio.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Idmodalidad { get; set; }
        public int DuracionHoras { get; set; }
        public int Idtipo { get; set; }
        public int Idcategoria { get; set; }
        public int Idlineacarrera { get; set; }
        public int? Idprofesor { get; set; }

        public virtual Categoria IdcategoriaNavigation { get; set; }
        public virtual Lineacarrera IdlineacarreraNavigation { get; set; }
        public virtual Modalidade IdmodalidadNavigation { get; set; }
        public virtual Tipocurso IdtipoNavigation { get; set; }
    }
}
