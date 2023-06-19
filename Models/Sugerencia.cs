using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Sugerencia
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public string? Comentario { get; set; }
        public int? EncuestaId { get; set; }

        public virtual Usuario? Cliente { get; set; }
        public virtual Encuesta? Encuesta { get; set; }
    }
}
