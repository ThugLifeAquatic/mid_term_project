using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace AlrightBooks.Models
{
    //Simplified book model to store books retrieved from the API
    public class Books : IBook
    {
        [Key]
        public int BookID
        {
            get; set;
        }
        public string Author
        {
            get; set;
        }
        [Display(Name = "Rating")]
        public decimal? AvgRating
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        [Display(Name = "Book Cover")]
        public string ImgURL
        {
            get; set;
        }
        [MaxLength(40)]
        public string ISBN
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public ApplicationUser User
        {
            get; set;
        }

    }
}
