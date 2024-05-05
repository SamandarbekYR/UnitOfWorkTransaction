using OracleTransaction.Entities;

namespace OracleTransaction.DataAccess.Interfaces
{
    public interface IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        void Add (TEntity entity);
        IQueryable<TEntity> SelectedAll();
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity? GetById(Guid id);
    }
}
