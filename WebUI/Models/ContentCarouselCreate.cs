using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ContentCarouselCreate : ContentCarouselsViewModel
    {
        public List<IBrowserFile> ContentFile { get; set; }
        public CarouselsViewModel Carousel { get; set; }
    }
}
