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
            _bookService.GetAllBooks();

        [HttpGet("{id}")]
        public Book Get(string id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return null;
            }

            return null;
        }

        [HttpPost]
        public void AddBook(Book book)
        {
            _bookService.AddBook(book);

        }

        [HttpPost("{customer}")]
        public void CreateCustomer(Customer customer)
        {
            _bookService.AddCustomer(customer);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(string id, Book bookIn)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.UpdateBookById(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.RemoveBook(book.Id);

            return NoContent();
        }

        [HttpGet("price/{id}")]
        public List<string> Get(int price)
        {
            var bookNames = _bookService.GetBookNames(price);
            return bookNames;
        }
    }
}