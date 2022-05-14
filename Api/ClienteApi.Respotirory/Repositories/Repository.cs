using ClienteApi.Domain.SeedWorks.AbstractClass;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces.Repositories;
using ClienteApi.Respotirory.Context;
using ClienteApi.Respotirory.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteApi.Respotirory.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();

        }
        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task<bool> Exist(TEntity entity)
        {
            return await DbSet.AnyAsync(x => x.Id == entity.Id);
        }


        public async Task<IEnumerable<TEntity>> Get
        (
            Expression<Func<TEntity, bool>> predicate
        )
        {
            return await DbSet.AsNoTracking()
                        .Where(predicate)
                        .ToListAsync();
        }

        public async Task<PagedModel<TEntity>> GetAll
        (
            Expression<Func<TEntity, bool>> predicate,
            int page,
            int size,
            CancellationToken cancellationToken
        )
        {
                return await DbSet.AsNoTracking()
                        .Where(predicate)
                        .PaginateAsync(page, size, cancellationToken);
        }

        public async Task<TEntity> GetByCode(Guid code)
        {
            return await DbSet.Where(x => x.Code == code).FirstOrDefaultAsync();
        }


        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public int GetId(Guid code)
        {
            return DbSet.Where(x => x.Code == code).Select(x => x.Id).FirstOrDefault();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
