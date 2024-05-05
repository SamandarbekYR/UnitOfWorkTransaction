using Microsoft.EntityFrameworkCore;
using OracleTransaction.DataAccess.Data;
using OracleTransaction.DataAccess.Interfaces;
using OracleTransaction.Entities;

namespace OracleTransaction.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private DbSet<TEntity> _dbSet;
    public Repository(AppDbContext appDb)
    {
        _dbSet = appDb.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public TEntity? GetById(Guid id)
    => _dbSet.FirstOrDefault(e => e.Id == id)!;

    public void Remove(TEntity entity)
    => _dbSet.Remove(entity);

    public IQueryable<TEntity> SelectedAll()
    => _dbSet;

    public void Update(TEntity entity)
    => _dbSet.Update(entity);
}
