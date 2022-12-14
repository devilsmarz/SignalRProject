using Microsoft.EntityFrameworkCore;
using SignalRBackend.DAL.DBConfiguration.DatabaseConfiguration;
using SignalRBackend.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext Context;

        public GenericRepository(DatabaseContext context)
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

        public virtual async Task<T> GetById(Int32 id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }

        public void AttachEntity(T item)
        {
            Context.Set<T>().Attach(item);
        }

        public void DetachEntity(T item)
        {
            Context.Entry(item).State = EntityState.Detached;
        }
    }
}
