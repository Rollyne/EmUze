using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Data;

namespace Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected EmuzerDbContext context;

        protected Repository()
        {
            context = new EmuzerDbContext();
        }
        public void Add(TEntity item)
        {
            context.Set<TEntity>().Add(item);
        }

        public ICollection<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public ICollection<TEntity> Where(Func<TEntity, bool> condition)
        {
            return context.Set<TEntity>().Where(condition).ToList();
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> condition)
        {
            return context.Set<TEntity>().FirstOrDefault(condition);
        }

        public int Count()
        {
            return context.Set<TEntity>().Count();
        }

        public void Update(TEntity item)
        {
            context.Set<TEntity>().AddOrUpdate(item);
        }

        public void Delete(TEntity item)
        {
            context.Set<TEntity>().Remove(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
