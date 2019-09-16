using System.Collections.Generic;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}