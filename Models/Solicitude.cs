using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Solicitude
    {
        public Solicitude()
        {
            Casos = new HashSet<Caso>();
        }

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? EmpresaId { get; set; }
        public string? DescripcionSolicitud { get; set; }
        public string? EstadoSolicitud { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Usuario? Cliente { get; set; }
        public virtual Empresa? Empresa { get; set; }
        public virtual ICollection<Caso> Casos { get; set; }
    }
}
