using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET.DAL.Clases;
using PruebaNET.Objetos.Interfaces.DAL;

namespace PruebaNET.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(TerminalesContext contexto)
        {
            Context = contexto;
        }

        public void Complete()
        {
            Context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void DeshacerCambios()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }


        public void DetachAllEntities()
        {
            foreach (var entry in Context.ChangeTracker.Entries())
                entry.State = EntityState.Detached;
        }


    }
}
