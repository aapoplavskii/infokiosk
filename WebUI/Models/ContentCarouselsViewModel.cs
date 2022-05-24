using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ContentCarouselsViewModel : BaseViewModel
    {
        public string Content { get; set; }
        public int PageContainerId { get; set; }
        public TimeSpan TimeCycle { get; set; }
        //public PageContainerViewModel PageContainer { get; set; }
    }
}
