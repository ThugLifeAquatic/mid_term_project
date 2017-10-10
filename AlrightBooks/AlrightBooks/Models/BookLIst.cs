using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlrightBooks.Models
{
    public class BookList
    {
        [Key]
        public int BookListID { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
