using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Agente
    {
        /*public Agente()
        {
            Casos = new HashSet<Caso>();
        }*/

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public int? EmpresaId { get; set; }

        //public virtual Empresa? Empresa { get; set; }
        //public virtual ICollection<Caso> Casos { get; set; }
    }
}
