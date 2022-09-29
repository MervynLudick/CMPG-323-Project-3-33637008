using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Interfaces;

namespace DeviceManagement_DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ConnectedOfficeContext _context;
        
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public int SaveAll()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        /// <summary>
        /// Checks if an entity exists in the datastore with a given Id
        /// </summary>
        /// <param name="id">The Id of the entity</param>
        /// <returns></returns>
        public bool DoesExist(Guid? id)
        {
            return GetById(id) != null;
        }
    }
}