using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public List<Book> Get() =>
            _bookService.GetAll();

        [HttpGet("{id}")]
        public Book Get(string id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return null;
            }

            return null;
        }

        [HttpPost]
        public void Create(Book book)
        {
            _bookService.Create(book);

        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.UpdateById(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }

        [HttpGet("price/{id}")]
        public List<string> Get(int price)
        {
            var bookNames = _bookService.GetNames(price);
            return bookNames;
        }
    }
}