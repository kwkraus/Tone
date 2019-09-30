using System;
using System.Collections.Generic;
using Tone.LibraryManagement.Core.Entities;

namespace Tone.LibraryManagement.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}