using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Encuesta
    {
        /*public Encuesta()
        {
            Sugerencia = new HashSet<Sugerencia>();
        }*/

        public int Id { get; set; }
        public string? Pregunta1 { get; set; }
        public string? Pregunta2 { get; set; }
        public string? Pregunta3 { get; set; }

       // public virtual ICollection<Sugerencia> Sugerencia { get; set; }
    }
}
