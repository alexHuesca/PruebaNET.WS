using AutoMapper;
using PruebaNET.Objetos.Clases.Terminales;
using PruebaNET.Objetos.Clases.DTO;
using Microsoft.AspNetCore.Routing.Constraints;

namespace PruebaNET.WS
{
    // AutoMapping.cs
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Terminale, TerminalesDTO>()
                .ForMember(d => d.estadoName, o => o.MapFrom(p => p.IdEstadoNavigation.EstadoName))
                .ForMember(d => d.fabName, o => o.MapFrom(p => p.IdFabNavigation.FabName));

        }
    }
}
