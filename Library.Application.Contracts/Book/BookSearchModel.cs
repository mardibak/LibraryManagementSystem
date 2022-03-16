namespace Library.Application.Contracts.Book
{
    public class BookSearchModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Translator { get; set; }
        public long CategoryId { get; set; }
    }
}
