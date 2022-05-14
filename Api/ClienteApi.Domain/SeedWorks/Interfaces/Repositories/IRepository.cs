using ClienteApi.Domain.SeedWorks.AbstractClass;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApi.Domain.SeedWorks.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByCode(Guid code);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAllAsync();
        Task Update(TEntity entity);
        Task<bool> Exist(TEntity entity);
        Task Delete(TEntity entity);
        int GetId(Guid code);
        Task<int> SaveChanges();
    }
}
