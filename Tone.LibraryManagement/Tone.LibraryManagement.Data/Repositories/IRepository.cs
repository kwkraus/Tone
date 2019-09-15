using System.Collections.Generic;
using System.Threading.Tasks;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}