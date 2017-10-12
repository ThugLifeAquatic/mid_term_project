using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlrightBooks.Data;
using AlrightBooks.Models;
using AlrightBooks.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;

namespace AlrightBooks.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        //Adds userManager so we can ID the current user
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            //Retrieves books from the db, only the ones associated with the currently logged in user
            List<Books> UserBooks = new List<Books>();
            var CurrentUser = await _userManager.GetUserAsync(User);
            var CurrId = CurrentUser.Id;
            var DbBooks = _context.Books;
            foreach (var B in DbBooks)
            {
                if (B.User != null && B.User.Id == CurrId)
                {
                    UserBooks.Add(B);
                }
            }
            return View(UserBooks);
        }


        //This Method calls the google books api using the genre specified by the user.
        public async Task<IActionResult> Genre(MenuEnum.BookCat genre)
        {
            ICollection<Books> ReturnBooks = new List<Books>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://www.googleapis.com");
                    
                    var response = await client.GetAsync($"/books/v1/volumes?maxResults=40&q=subject:{genre}");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON response
                    var rawBooks = TheBooks.FromJson(stringResult);
                    if (rawBooks.Items != null)
                    {

                        IEnumerable<Item> RawBooks = from o in rawBooks.Items
                                                     where o.VolumeInfo.Description != null
                                                     select o;
                        foreach (var o in RawBooks)
                        {
                            decimal? temp = 0.00M;
                            if (o.VolumeInfo.AverageRating == null)
                            {
                                temp = 0.00M;
                            }
                            else
                            {
                                temp = o.VolumeInfo.AverageRating;
                            }
                            string tempISBN = "N/A";
                            if (o.VolumeInfo.IndustryIdentifiers != null)
                            {
                                tempISBN = o.VolumeInfo.IndustryIdentifiers[0].Identifier;
                            }
                            //Maps Massive JSON objects to our simpler book model
                            Books Abook = new Books
                            {
                                Title = o.VolumeInfo.Title,
                                Author = o.VolumeInfo.Authors[0],
                                AvgRating = temp,
                                Description = o.VolumeInfo.Description,
                                ImgURL = o.VolumeInfo.ImageLinks.Thumbnail,
                                ISBN = tempISBN
                            };
                            ReturnBooks.Add(Abook);
                        }
                    }
                    //returns the currated books
                    return View(ReturnBooks);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting requested books from Google Books: {httpRequestException.Message}");
                }
            }
        }

        

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.BookID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        //This method adds books to the users reading list.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Author,AvgRating,Title,ImgURL,Description,ISBN")] Books books)
        {
            //Associates the new book with the logged in user
            books.User = await _userManager.GetUserAsync(User);
            //If User is not logged in, Direct them to.
            if(books.User == null)
            {
                return BadRequest("Please Log in to add books to your book list.");
            }
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.SingleOrDefaultAsync(m => m.BookID == id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Author,AvgRating,Title,ImgURL,Description,ISBN")] Books books)
        {
            if (id != books.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.BookID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.SingleOrDefaultAsync(m => m.BookID == id);
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
