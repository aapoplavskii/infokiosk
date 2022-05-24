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
    class EFCarouselRepository : EFEntityRepository<Carousel>, ICarouselRepository
    {
        public EFCarouselRepository(DataContext context) : base(context)
        {
            Includes = new Expression<Func<Carousel, object>>[]
            {
                dependency => dependency.ContentsCarousel
            };
        }
    }
}
