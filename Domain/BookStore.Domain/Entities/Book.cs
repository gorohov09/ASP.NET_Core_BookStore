using System.Text.RegularExpressions;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        public int Id { get; }

        public string Isbn { get; }

        public string Author { get; }

        public string Title { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Book(int id, string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Isbn = isbn;
            Author = author;
            Title = title;
            Description = description;
            Price = price;
        }

        internal static bool IsIsbn(string str)
        {
            if (str == null)
                return false;

            //Fluent-синтаксис(текучий)
            str = str.Replace("-", "") //Убрали дефисы
                     .Replace(" ", "") //Убрали пробелы
                     .ToUpper(); //Перевели в верхний регистр

            return Regex.IsMatch(str, @"^ISBN\d{10}(\d{3})?$"); //Регулярное выражение(начинается с ISBN, потом идет любые 10 цифр или еще 3 цифры)
            //^x - x - должен быть всегда в начале строки
            //x$ - x - должен быть в конце строки
        }
    }
}
