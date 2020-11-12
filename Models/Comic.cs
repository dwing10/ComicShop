using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class Comic
    {
        #region Properties

        [Key]
        public int ComicId { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER A TITLE")]
        public string Title { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER A WRITER")]
        [Display(Name = "Writer ID")]
        [ForeignKey("WriterID")]
        public int WriterID { get; set; }
        public Writer Writer { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER A ARTIST")]
        [Display(Name = "Artist ID")]
        [ForeignKey("ArtistID")]
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER A PUBLICATION YEAR")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please Rate This Title")]
        [Range(1,5, ErrorMessage = "RATING MUST BE BETWEEN 1 AND 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER A PUBLISHER")]
        [Display(Name = "Publisher ID")]
        [ForeignKey("PublisherID")]
        public int PublisherID { get; set; }
        public Publisher PublisherClass { get; set; }

        #endregion
    }
}
