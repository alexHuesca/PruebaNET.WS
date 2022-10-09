using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.Objetos.Clases.DTO
{
    public class TerminalesDTO
    {
        public string terminalName { get; set; }
        public string terminalDesc { get; set; }
        public string fabName { get; set; }
        public string estadoName { get; set; }
        public Nullable<System.DateTime> fechafabricacion { get; set; }
        public Nullable<System.DateTime> fechaestado { get; set; }

    }
}
