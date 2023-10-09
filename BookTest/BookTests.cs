using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libary;

namespace LibaryTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void CreateBook_ValidInputs_ShouldSucceed()
        {
            // Arrange
            var book = new Book(1, "Valid Title", 100);

            // Act & Assert
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("Valid Title", book.Title);
            Assert.AreEqual(100, book.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBook_NullTitle_ShouldThrowException()
        {
            // Arrange & Act
            var book = new Book(1, null, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBook_ShortTitle_ShouldThrowException()
        {
            // Arrange & Act
            var book = new Book(1, "Ab", 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateBook_InvalidPrice_ShouldThrowException()
        {
            // Arrange & Act
            var book = new Book(1, "Valid Title", 2001);
        }

        [TestMethod]
        public void ToString_ValidBook_ShouldReturnExpectedString()
        {
            // Arrange
            var book = new Book(1, "Valid Title", 100);

            // Act
            var result = book.ToString();

            // Assert
            Assert.AreEqual("1: Valid Title, $100.00", result);
        }
    }
}
