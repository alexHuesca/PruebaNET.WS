using Microsoft.EntityFrameworkCore;
using PruebaNET.BLL.Managers;
using PruebaNET.DAL;
using PruebaNET.DAL.Clases;
using PruebaNET.DAL.Repositories;
using PruebaNET.Objetos.Interfaces.BLL;
using PruebaNET.Objetos.Interfaces.DAL;

namespace PruebaNET.WS
{
    public class DependenciasWS
    {
        /// <summary>
        /// Registro de dependecias del programa.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegistraDependencias(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITerminalesManager, TerminalesManager>();
            services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddDbContext<TerminalesContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["RedisCacheUrl"]; });

        }
    }
}
