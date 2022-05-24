using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PageContainerViewModel : BaseViewModel
    {
        public List<ContentCarouselsViewModel> ContentCarouselsViewModels { get; set; }

        public PageContainerViewModel(PageContainer pageContainer)
        {
            Name = pageContainer.Name;
            Id = pageContainer.Id;
            ContentCarouselsViewModels = new();
            foreach (var item in pageContainer.ContentCarousel)
            {
                ContentCarouselsViewModels.Add(new ContentCarouselsViewModel(item));
            };
        }
    }
}
