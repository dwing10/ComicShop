using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class Comic
    {
        #region Properties

        public int ComicId { get; set; }

        [Required(ErrorMessage = "Please Enter A Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter A Publication Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please Rate This Title")]
        [Range(1,5, ErrorMessage = "Rating Must Be Between 1 And 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please Enter A Publisher")]
        public int PublisherID { get; set; }
        public Publisher PublisherClass { get; set; }

        #endregion
    }
}
