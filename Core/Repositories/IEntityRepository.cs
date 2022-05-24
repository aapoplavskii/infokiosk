using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        public Task Create(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetById(int id);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
