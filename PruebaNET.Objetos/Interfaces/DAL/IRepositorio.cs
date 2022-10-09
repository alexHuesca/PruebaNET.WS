using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.Objetos.Interfaces.DAL
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(IUnitOfWork uow);

        Task<IEnumerable<TEntity>> GetAllAsync(IUnitOfWork uow);


        //IEnumerable<TEntity> GetAll(DbContext context);

        //Task<IEnumerable<TEntity>> GetAllAsync(DbContext context);
    }
}
