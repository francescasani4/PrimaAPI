using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimaAPI.Database;
using PrimaAPI.Model.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly FakeDatabase database = DatabaseSingleton.Instance;

        [HttpGet("id")]
        public IActionResult GetBook(int idBook)
        {
            var book = database.Books.FirstOrDefault(b => b.IdBook == idBook);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("title")]
        public IActionResult GetBook(string title)
        {
            var book = database.Books.FirstOrDefault(b => b.Title == title);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int idBook)
        {
            var book = database.Books.FirstOrDefault(b => b.IdBook == idBook);

            if (book == null)
                return NotFound();

            database.Books.Remove(book);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]BookRequest book)
        {
            database.AddBook(new Database.Book
            {
                IdBook = 0,
                Title = book.Title,
                Author = book.Author,
                PublicationDate = book.PublicationDate
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookRequest book)
        {
            var currentBook = database.Books.FirstOrDefault(b => b.IdBook == book.IdBook);

            if (book == null)
                return NotFound();

            currentBook.Title = book.Title;
            currentBook.Author = book.Author;
            currentBook.PublicationDate = book.PublicationDate;

            return Ok(book);
        }

        [HttpGet("all")] 
        public IActionResult AllBook()
        {
            return Ok(database.Books);
        }
    }
}

