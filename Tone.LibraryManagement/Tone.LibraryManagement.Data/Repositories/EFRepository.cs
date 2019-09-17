using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tone.LibraryManagement.Core.Entities;
using Tone.LibraryManagement.Core.Repositories;

namespace Tone.LibraryManagement.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entities;

        public EFRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _entities.ToList();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(_entities.FirstOrDefault(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
