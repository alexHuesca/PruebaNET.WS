using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace PruebaNET.Objetos.Interfaces.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        void Complete();

        Task<int> CompleteAsync();

        void DeshacerCambios();

        void DetachAllEntities();
    }
}
