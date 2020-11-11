using BooksApi.Models;
using BooksApi.Models.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<Customer> _customer;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Book> GetAllBooks()
        {
            return _books.Find(book => true).ToList();
        }
        public Book GetBookById(string id)
        {
            var book = _books.Find<Book>(book => book.Id == id).FirstOrDefault();

            return null;
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);       
            return book;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void UpdateBookById(string id, Book bookIn)
        {
            _books.ReplaceOne(book => book.Id == id, bookIn);
        }


        public void RemoveBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public List<string> GetBookNames(int price)
        {
            var x = _books.Find(b => b.Price >= price).ToList();

            var names = x.Select(book => book.BookName).ToList();
           
            return names;
        }
    }
}