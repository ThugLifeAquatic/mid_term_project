using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkayBooksAPITestingBranch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OkayBooksAPITestingBranch.Controllers
{
    [Route("api/[controller]")]
    public class TheBooksController : Controller
    {
        [HttpGet("[action]/{genre}")]
        public async Task<IActionResult> Genre(string genre)
        {
            List<Book> ReturnBooks = new List<Book>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://www.googleapis.com");
                    var response = await client.GetAsync($"/books/v1/volumes?q=subject:{genre}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawBooks = TheBooks.FromJson(stringResult);
                    IEnumerable<Item> RawBooks = from o in rawBooks.Items
                                                 where o.VolumeInfo.Description != null
                                                 select o;
                    foreach (var o in RawBooks)
                    {

                        Book Abook = new Book
                        {
                            Title = o.VolumeInfo.Title,
                            Author = o.VolumeInfo.Authors.ToString(),
                            Description = o.VolumeInfo.Description,
                            ImageURL = o.VolumeInfo.ImageLinks.Thumbnail,
                            ISBN = o.VolumeInfo.IndustryIdentifiers[0].Identifier
                        };

                        ReturnBooks.Add(Abook);
                    }
                    return View(ReturnBooks);

                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting requested books from Google Books: {httpRequestException.Message}");
                }
            }
        }
    }
}
