using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        public IEnumerable<T> GetAll();
        public T GetById(Guid? id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public int SaveAll();
        public void Update(T entity);

        public bool DoesExist(Guid? id);
    }
}