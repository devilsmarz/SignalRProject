using System;
using System.Threading.Tasks;

namespace SignalRBackend.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Int32 id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void AttachEntity(T item);
        void DetachEntity(T item);
    }
}
