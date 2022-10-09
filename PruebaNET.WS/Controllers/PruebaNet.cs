using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaNET.BLL.Managers;
using PruebaNET.Objetos.Clases.Terminales;
using PruebaNET.Objetos.Clases.DTO;
using PruebaNET.Objetos.Interfaces.BLL;
using PruebaNET.Objetos.Interfaces.DAL;
using Microsoft.Extensions.Caching.Distributed;

namespace PruebaNET.WS.Controllers
{
    [Route("api/v1/terminales/")]
    [ApiController]
    public class PruebaNet : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITerminalesManager _terminalesManager;
        private readonly IDistributedCache _cache;

        public PruebaNet(IUnitOfWork uow, ITerminalesManager terminalesManager, IMapper mapper, IDistributedCache cache)
        {
            _uow = uow;
            _terminalesManager = terminalesManager;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<TerminalesDTO>> GetTerminales()
        {
            try
            {
                var _terminalesDTO =await _terminalesManager.ObtenerTerminalesAsync(_uow, _mapper, _cache);
                return Ok(_terminalesDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
