using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get()
        {
            return _books.Find(book => true).ToList();
        }
        public Book Get(string id)
        {
            var book = _books.Find<Book>(book => book.Id == id).FirstOrDefault();

            return null;
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);

            return book;
        }

        public void Update(string id, Book bookIn)
        {
            _books.ReplaceOne(book => book.Id == id, bookIn);
        }


        public void Remove(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public List<string> GetNames(int price)
        {
            var x = _books.Find(b => b.Price >= price).ToList();

            var names = x.Select(book => book.BookName).ToList();
            return names;
        }
    }
}