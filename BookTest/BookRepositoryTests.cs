using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libary;
namespace BookLibraryTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private BookRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new BookRepository();
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            Book newBook = new Book() { Title = "New Book", Price = 300m };

            // Act
            Book addedBook = _repo.Add(newBook);

            // Assert
            Assert.AreEqual("New Book", addedBook.Title);
            Assert.AreEqual(300m, addedBook.Price);
            Assert.IsNotNull(_repo.GetById(addedBook.Id));
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Act
            Book? deletedBook = _repo.Delete(1);

            // Assert
            Assert.IsNull(_repo.GetById(1));
            Assert.AreEqual("Harry Potter", deletedBook?.Title);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            Book updateValues = new Book() { Title = "Updated Book", Price = 250m };

            // Act
            Book? updatedBook = _repo.Update(2, updateValues);

            // Assert
            Assert.AreEqual("Updated Book", updatedBook?.Title);
            Assert.AreEqual(250m, updatedBook?.Price);
            Assert.AreEqual("Updated Book", _repo.GetById(2)?.Title);
        }
    }
}