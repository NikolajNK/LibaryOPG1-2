using System;

namespace Libary
{
    public class Book
    {
        private string _title;
        private decimal _price;

        public int Id { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(Title), "Der skal indeholde en titel");
                if (value.Length < 3) throw new ArgumentException("Titlen skal have minimum 3 tegn");
                _title = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0 || value > 2000) throw new ArgumentOutOfRangeException(nameof(Price), "Prisen skal være højere end 0 og mindre end 2000");
                _price = value;
            }
        }

        public Book() { }

        public Book(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id}: {Title}, {Price:C}";
        }
    }
}
