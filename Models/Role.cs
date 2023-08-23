using System;
using System.Collections.Generic;

namespace ProyectoGrupalG06.Models
{
    public partial class Role
    {
        /*public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }*/

        public int Id { get; set; }
        public string? NombreRol { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
