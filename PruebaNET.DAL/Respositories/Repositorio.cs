using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET.Objetos.Interfaces.DAL;

namespace PruebaNET.DAL.Repositories
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {

        public virtual IEnumerable<TEntity> GetAll(IUnitOfWork uow)
        {
            IQueryable<TEntity> dbQuery = uow.Context.Set<TEntity>();
            return dbQuery
                .ToArray();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(IUnitOfWork uow)
        {
            IQueryable<TEntity> dbQuery = uow.Context.Set<TEntity>();
            return await dbQuery
                .ToArrayAsync();
        }
    }
}
