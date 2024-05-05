using OracleTransaction.Entities;

namespace OracleTransaction.DataAccess.Interfaces
{
    public interface IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> SelectedAll();
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity? GetById(Guid id);
    }
}
