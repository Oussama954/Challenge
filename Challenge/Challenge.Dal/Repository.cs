﻿using Challenge.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Dal
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }
        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, int>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, int>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, string>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, string>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }
    }
}
