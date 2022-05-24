using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebUI.Data
{
    public class DataManager
    {
        private readonly HttpClient _client;
        private readonly string serverAddres = "https://localhost:4001";

        public PageContainerManager PageContainerManager { get; private set; }
        public ContentCarouselManager ContentCarouselManager { get; private set; }

        public DataManager(HttpClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            _client = client;
            _client.BaseAddress = new Uri(serverAddres);
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            //_client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            PageContainerManager = new PageContainerManager(_client);
            ContentCarouselManager = new ContentCarouselManager(_client);
        }
    }
}
