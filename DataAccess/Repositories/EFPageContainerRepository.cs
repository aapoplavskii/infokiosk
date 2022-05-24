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
    public class EFPageContainerRepository : EFEntityRepository<PageContainer>, IPageContainerRepository
    {
        public EFPageContainerRepository(DataContext context) : base(context)
        {
            Includes = new Expression<Func<PageContainer, object>>[]
{
                dependency => dependency.ContentCarousel
};
        }



        public async Task<PageContainer> GetByName(string name)
        {
            IQueryable<PageContainer> set = _context.Set<PageContainer>();
            if (Includes != null) set = Includes.Aggregate(set, (current, IncludeProp) => current.Include(IncludeProp));
            return await set.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
