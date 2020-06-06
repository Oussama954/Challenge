using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Dal.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        int Count();
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, int>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, int>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, string>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, string>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize);
    }
}
