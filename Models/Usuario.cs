using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Solicitudes = new HashSet<Solicitude>();
            Sugerencia = new HashSet<Sugerencia>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NombreUsuario { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
        public virtual ICollection<Solicitude> Solicitudes { get; set; }
        public virtual ICollection<Sugerencia> Sugerencia { get; set; }
    }
}
