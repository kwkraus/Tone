using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tone.LibraryManagement.Data.Contexts;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Delete(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
