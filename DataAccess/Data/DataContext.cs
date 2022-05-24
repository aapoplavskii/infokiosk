using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<ContentCarousel> ContentCarousels { get; set; }
        public DbSet<PageContainer> PageContainers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
