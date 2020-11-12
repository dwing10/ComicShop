using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicShop.Models
{
    public class Writer
    {
        public int WriterID { get; set; }

        [Required(ErrorMessage = "PLEASE ENTER THE WRITER'S NAME")]
        [Display(Name = "Writer's Name")]
        public string WriterName { get; set; }
    }
}
