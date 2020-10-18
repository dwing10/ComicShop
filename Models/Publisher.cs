using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string Address { get; set; }
        public string City { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [StringLength(2, ErrorMessage = "Enter two letter state code")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        [Column("Zipcode")]
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
