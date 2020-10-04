using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class Publisher
    {
        [Display(Name = "Publisher ID")]

        public int PublisherID { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }
    }
}
