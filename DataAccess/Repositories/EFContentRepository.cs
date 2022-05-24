using Core.Domain;
using Core.Repositories;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EFContentCarouselRepository : EFEntityRepository<ContentCarousel>, IContentCarouselRepository
    {
        public EFContentCarouselRepository(DataContext context) : base(context)
        {
            Includes = new Expression<Func<ContentCarousel, object>>[]
            {
                dependency => dependency.PageContainer
            };
        }
    }
}
