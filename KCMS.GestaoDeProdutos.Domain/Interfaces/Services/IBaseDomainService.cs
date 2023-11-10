namespace KCMS.GestaoDeProdutos.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
    }
}
