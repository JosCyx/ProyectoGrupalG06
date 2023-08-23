using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Empresa
    {
        /*public Empresa()
        {
            Agentes = new HashSet<Agente>();
            Solicitudes = new HashSet<Solicitude>();
        }*/

        public int Id { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }

        //public virtual ICollection<Agente> Agentes { get; set; }
        //public virtual ICollection<Solicitude> Solicitudes { get; set; }
    }
}
