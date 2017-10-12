using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlrightBooks.Models
{
    //Genre values used in our drop-down, these are passed to the API
    public class MenuEnum
    {
        public enum BookCat { Geography = 1, Romance, Crime, Psychology, Thriller, Comedy, Science, Reference, Horror, Sports, Philosophy, Adventure, Gardening, Music, Food, Programming, Parenting, Feminism }
        public BookCat Cats { get; set; }
    }
}
