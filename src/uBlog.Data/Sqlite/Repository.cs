using NPoco;

namespace uBlog.Data.Sqlite
{
    public class Repository
    {
        protected IDatabase db;
        public Repository(IDatabase db)
        {
            this.db = db;
        }
    }
    //public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    //{
    //    protected readonly DbContext Context;

    //    public Repository(DbContext context)
    //    {
    //        Context = context;
    //    }

    //    public TEntity Get(int id)
    //    {
    //        return Context.Set<TEntity>().Find(id);
    //    }

    //    public IEnumerable<TEntity> GetAll()
    //    {
    //        return Context.Set<TEntity>().ToList();
    //    }

    //    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    //    {
    //        return Context.Set<TEntity>().Where(predicate);
    //    }

    //    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    //    {
    //        return Context.Set<TEntity>().SingleOrDefault(predicate);
    //    }

    //    public void Add(TEntity entity)
    //    {
    //        Context.Set<TEntity>().Add(entity);
    //    }

    //    public void AddRange(IEnumerable<TEntity> entities)
    //    {
    //        Context.Set<TEntity>().AddRange(entities);
    //    }

    //    public void Remove(TEntity entity)
    //    {
    //        Context.Set<TEntity>().Remove(entity);
    //    }

    //    public void RemoveRange(IEnumerable<TEntity> entities)
    //    {
    //        Context.Set<TEntity>().RemoveRange(entities);
    //    }
    //}
}