﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
    }
}
