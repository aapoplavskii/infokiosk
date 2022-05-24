using Core.Domain;
using Core.Repositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EFEntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected Expression<Func<T, object>>[] Includes;

        public EFEntityRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            IQueryable<T> set = _context.Set<T>();
            var entity = set.FirstOrDefault(e => e.Id == id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> set = _context.Set<T>();
            if (Includes != null) set = Includes.Aggregate(set, (current, IncludeProp) => current.Include(IncludeProp));
            return await set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            IQueryable<T> set = _context.Set<T>();
            if (Includes != null) set = Includes.Aggregate(set, (current, IncludeProp) => current.Include(IncludeProp));
            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
