using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlrightBooks.Models;

namespace AlrightBooks.Models
{
    public class AlrightBooksContext : DbContext
    {
        public AlrightBooksContext (DbContextOptions<AlrightBooksContext> options)
            : base(options)
        {
        }

        public DbSet<AlrightBooks.Models.User> User { get; set; }

        public DbSet<AlrightBooks.Models.Book> Book { get; set; }

        public DbSet<AlrightBooks.Models.BookList> BookList { get; set; }
    }
}
