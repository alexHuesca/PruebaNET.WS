using PruebaNET.Objetos.Interfaces.DAL;


namespace PruebaNET.Objetos.Interfaces.BLL
{
    public interface IManager<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(IUnitOfWork uow);

        Task<IEnumerable<TEntity>> GetAllAsync(IUnitOfWork uow);
    }
}
