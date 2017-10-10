using AlrightBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlrightBooks.ViewModels
{
    public class BookQViewModel
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
        public decimal AvgRating
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string ImgURL
        {
            get; set;
        }

        public virtual BookList BookList
        {
            get; set;
        }
        public string ISBN
        {
            get; set;
        }
    }
}
