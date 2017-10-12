using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace AlrightBooks.Models
{
    //Interface for implementing books
    public interface IBook
    {
        int BookID
        {
            get; set;
        }
        string Author
        {
            get; set;
        }
        decimal? AvgRating
        {
            get; set;
        }
        string Title
        {
            get; set;
        }
        string ImgURL
        {
            get; set;
        }
        string ISBN
        {
            get; set;
        }
        string Description
        {
            get; set;
        }
        ApplicationUser User
        {
            get; set;
        }
    }
}
