﻿namespace Library.Application.Contracts.Book
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Translator { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public string CreationDate { get; set; }
    }
}
