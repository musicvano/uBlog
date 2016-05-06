using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace uBlog.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetByPage(int pageIndex, int pageSize);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}