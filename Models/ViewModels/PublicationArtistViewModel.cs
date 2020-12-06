using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models.ViewModels
{
    public class PublicationArtistViewModel
    {
        public List<Artist> Artists { get; set; }
        public List<Comic> Comics { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Writer> Writers { get; set; }
    }
}
