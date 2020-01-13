using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TodoList.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(T entity, Expression<Func<T, bool>> expression);      
    }
}