using SignalRBackend.DAL.DBConfiguration;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRBackend.DAL.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext Context;
        public GenericRepository(ApplicationContext context)
        {
            Context = context;
        }
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public T GetId(Int32 id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }
    }
}
