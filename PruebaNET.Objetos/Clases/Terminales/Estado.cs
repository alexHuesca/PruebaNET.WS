using System;
using System.Collections.Generic;

namespace PruebaNET.Objetos.Clases.Terminales
{
    public partial class Estado
    {
        public Estado()
        {
            Terminales = new HashSet<Terminale>();
        }

        public int IdEstado { get; set; }
        public string? EstadoName { get; set; }
        public string? EstadoDesc { get; set; }

        public virtual ICollection<Terminale> Terminales { get; set; }
    }
}
