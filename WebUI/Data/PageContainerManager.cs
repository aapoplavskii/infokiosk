using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Data
{
    public class PageContainerManager : BaseManager<PageContainerViewModel>
    {
        public PageContainerManager(HttpClient client) : base(client)
        {
            controller = "PageContainers";
        }

        public async Task<NotificationViewModelGeneric<PageContainerViewModel>> CreateAsync(PageContainerViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Name", entity.Name)
            });
            return await CreateAsync(content);
        }

        public async Task<NotificationViewModelGeneric<PageContainerViewModel>> UpdateAsync(PageContainerViewModel entity)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", entity.Id.ToString()),
                new KeyValuePair<string,string>("Name", entity.Name)
            });
            return await UpdateAsync(content);
        }
    }
}
