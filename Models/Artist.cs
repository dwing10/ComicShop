using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER THE ARTIST'S NAME")]
        [Display(Name = "Artist's Name")]
        public string ArtistName { get; set; }
    }
}
