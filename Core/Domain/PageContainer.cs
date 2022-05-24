using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class PageContainer : BaseEntity
    {
        public string Name { get; set; }
        public List<ContentCarousel> ContentCarousel { get; set; }
    }
}
