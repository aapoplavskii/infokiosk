using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class ContentCarousel : BaseEntity
    {
        public byte[] Content { get; set; }
        public int PageContainerId { get; set; }
        public PageContainer PageContainer { get; set; }
        public TimeSpan TimeCycle { get; set; }
    }
}
