using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using PruebaNET.Objetos.Clases.DTO;
using PruebaNET.Objetos.Clases.Terminales;
using PruebaNET.Objetos.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.Objetos.Interfaces.BLL
{
    public interface ITerminalesManager 
    {
        IEnumerable<TerminalesDTO> ObtenerTerminales(IUnitOfWork uow, IMapper mapper, IDistributedCache cache);
        Task<IEnumerable<TerminalesDTO>> ObtenerTerminalesAsync(IUnitOfWork uow, IMapper mapper, IDistributedCache cache);

    }
}
