using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Meys.Data.UnitOfWorkAndGeneralRepo
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().AddRange(entities);
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);
        public TEntity Get(int id) => Context.Set<TEntity>().Find(id);
        public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>().ToList();
        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);
    }
}
