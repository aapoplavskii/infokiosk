using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ContentCarouselsViewModel : BaseViewModel
    {
        public byte[] Content { get; set; }
        public int PageContainerId { get; set; }
        public TimeSpan TimeCycle { get; set; }

        public ContentCarouselsViewModel(ContentCarousel contentCarousel)
        {
            Content = contentCarousel.Content;
            Id = contentCarousel.Id;
            PageContainerId = contentCarousel.PageContainerId;
            TimeCycle = contentCarousel.TimeCycle;
        }



    }
}
