using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Libary
{
    public class BookRepository
    {
        private List<Book> _books = new List<Book>();
        private int ID = 1;

        public BookRepository()
        {
            _books.Add(new Book(ID++, "Harry Potter", 100));
            _books.Add(new Book(ID++, "The Hobbit", 150));
            _books.Add(new Book(ID++, "Snehvide", 200));
            _books.Add(new Book(ID++, "Askepot", 120));
            _books.Add(new Book(ID++, "Jeg elsker programmering", 180));
        }

        public IEnumerable<Book> Get(decimal? maxPrice = null, string? orderBy = null, bool descending = false)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            if (maxPrice != null)
            {
                result = result.Where(b => b.Price <= maxPrice);
            }

            if (orderBy != null)
            {
                Func<Book, object> keySelector = orderBy.ToLower() switch
                {
                    "title" => b => b.Title,
                    "price" => b => b.Price,
                    _ => throw new ArgumentOutOfRangeException($"Invalid orderBy specifier: {orderBy.ToLower()}"),
                };

                result = descending ? result.OrderByDescending(keySelector) : result.OrderBy(keySelector);
            }

            return new List<Book>(result);  // Retunere en ny liste så den ikke erstatter den anden liste.
        }

        public Book? GetById(int id) => _books.SingleOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = ID++;
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return book;
        }

        public Book? Update(int id, Book values)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                book.Title = values.Title;
                book.Price = values.Price;
            }
            return book;
        }
    }
}