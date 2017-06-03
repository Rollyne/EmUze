using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity:class
    {
        void Add(TEntity item);

        ICollection<TEntity> GetAll();
        ICollection<TEntity> Where(Func<TEntity, bool> condition);
        TEntity FirstOrDefault(Func<TEntity, bool> condition);
        int Count();

        void Update(TEntity item);

        void Delete(TEntity item);

        void Save();
    }
}