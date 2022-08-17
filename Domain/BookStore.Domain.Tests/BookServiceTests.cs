using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Services;
using Moq;
using Xunit;

namespace BookStore.Domain.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            //Создаем объект(заглушку), который "наследует" bookRepo
            var bookRepositoryStub = new Mock<IBookRepository>();

            //Когда будет вызываться GetAllByIsbn() у объекта типа IBookRepository с любым строковым параметром
            //Верни массив книжек
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-67890";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            //Создаем объект(заглушку), который "наследует" bookRepo
            var bookRepositoryStub = new Mock<IBookRepository>();

            //Когда будет вызываться GetAllByIsbn() у объекта типа IBookRepository с любым строковым параметром
            //Верни массив книжек
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
