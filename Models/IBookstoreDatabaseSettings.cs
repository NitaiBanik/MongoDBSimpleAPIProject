namespace BooksApi.Models
{
    public interface IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}