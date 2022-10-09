using System;
using System.Collections.Generic;

namespace PruebaNET.Objetos.Clases.Terminales
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Terminales = new HashSet<Terminale>();
        }

        public int IdFab { get; set; }
        public string? FabName { get; set; }
        public string? FabDesc { get; set; }

        public virtual ICollection<Terminale> Terminales { get; set; }
    }
}
