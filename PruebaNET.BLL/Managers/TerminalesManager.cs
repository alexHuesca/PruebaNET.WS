using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using PruebaNET.Objetos.Clases.DTO;
using PruebaNET.Objetos.Clases.Terminales;
using PruebaNET.Objetos.Interfaces.BLL;
using PruebaNET.Objetos.Interfaces.DAL;
using System.Text.Json;
using System.Text;

namespace PruebaNET.BLL.Managers
{
    public class TerminalesManager: ITerminalesManager
    {
        private readonly IRepositorio<Terminale> _TerminalesRepository;

        public TerminalesManager(IRepositorio<Terminale> TerminalesRepository)
        {
            _TerminalesRepository = TerminalesRepository;
        }

        /// <summary>
        /// Método para obtener Terminales.
        /// Comprobación y registro en cache.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="mapper"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public IEnumerable<TerminalesDTO> ObtenerTerminales(IUnitOfWork uow, IMapper mapper, IDistributedCache cache)
        {
            byte[] cachedData =  cache.GetAsync("TerminalesDTO").Result;
            List<TerminalesDTO> _terminalesDTO=null;
            if (cachedData != null)
            {
                // If the data is found in the cache, encode and deserialize cached data.
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                _terminalesDTO = JsonSerializer.Deserialize<List<TerminalesDTO>>(cachedDataString);
            }
            if (_terminalesDTO == null)
            {
                var terminales = _TerminalesRepository.GetAll(uow);
                _terminalesDTO = mapper.Map<IEnumerable<Terminale>, IEnumerable<TerminalesDTO>>(terminales).ToList();
                var serializedDTO = JsonSerializer.Serialize<List<TerminalesDTO>>(_terminalesDTO);
                var data = Encoding.ASCII.GetBytes(serializedDTO);
                cache.Set("TerminalesDTO", data);
            }

            return _terminalesDTO;
        }
        /// <summary>
        /// Método para obtener Terminales async.
        /// Comprobación y registro en cache.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="mapper"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TerminalesDTO>> ObtenerTerminalesAsync(IUnitOfWork uow, IMapper mapper, IDistributedCache cache)
        {
            byte[] cachedData = await cache.GetAsync("TerminalesDTO");
            List<TerminalesDTO> _terminalesDTO = null;
            if (cachedData != null)
            {
                // If the data is found in the cache, encode and deserialize cached data.
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                _terminalesDTO = JsonSerializer.Deserialize<List<TerminalesDTO>>(cachedDataString);
            }
            if (_terminalesDTO == null)
            {
                var terminales =await  _TerminalesRepository.GetAllAsync(uow);
                _terminalesDTO = mapper.Map<IEnumerable<Terminale>, IEnumerable<TerminalesDTO>>(terminales).ToList();
                var serializedDTO = JsonSerializer.Serialize<List<TerminalesDTO>>(_terminalesDTO);
                var data = Encoding.ASCII.GetBytes(serializedDTO);
                cache.Set("TerminalesDTO", data);
            }

            return _terminalesDTO;
        }
    }
}
