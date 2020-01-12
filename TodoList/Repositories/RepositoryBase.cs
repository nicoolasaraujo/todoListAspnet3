using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Contracts;
using TodoList.Data;

namespace TodoList.Repositories
{
    public class RepositoryBase<T> :  IRepository<T> where T : class
    {
        protected DatabaseContext RepositoryContext { get; set; }

        public RepositoryBase(DatabaseContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Create(T entity)
        {
            var result = this.RepositoryContext.Set<T>().Add(entity).Entity;
            this.RepositoryContext.SaveChanges();
            return result;
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.RepositoryContext.SaveChanges();
        }

        public bool Exists(T entity, Expression<Func<T,bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Any(expression);
        }
    }
}