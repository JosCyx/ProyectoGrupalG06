using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Caso
    {
        public int Id { get; set; }
        public int? SolicitudId { get; set; }
        public int? AgenteId { get; set; }
        public string? DescripcionCaso { get; set; }
        public string? PrioridadCaso { get; set; }
        public string? EstadoCaso { get; set; }
        public DateTime? FechaCreacion { get; set; }

        //public virtual Agente? Agente { get; set; }
        //public virtual Solicitude? Solicitud { get; set; }
    }
}
