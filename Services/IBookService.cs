using BooksApi.Models;
using System.Collections.Generic;

namespace BooksApi.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(string id);
        Book AddBook(Book book);
        Customer AddCustomer(Customer customer);
        void UpdateBookById(string id, Book bookIn);
        void RemoveBook(string id);
        List<string> GetBookNames(int price)
    }
}
