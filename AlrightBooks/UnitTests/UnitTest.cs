using System;
using AlrightBooks.Models;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void SetBookID()
        {
            //Arrange
            var book = new Books {BookID = 100};
            
            //Act
            book.BookID = 200;
            
            //Assert
            Assert.Equal(200, book.BookID);
        }
        [Fact]
        public void EnumValidation()
        {
            //Arrange
            var enumSelct = new MenuEnum {Cats = MenuEnum.BookCat.Romance};

            //Act
            enumSelct.Cats = MenuEnum.BookCat.Horror;

            //Assert
            Assert.Equal("Horror", enumSelct.Cats.ToString());
        }
        [Fact]
        public void AverageRatingNotNullable()
        {
            //Arrange
            var newVolume = new VolumeInfo {AverageRating = null};
           
            //Act
            decimal? temp = 0.00M;
            if (newVolume.AverageRating == null)
            {
                temp = 0.00M;
            }
            else
            {
                temp = newVolume.AverageRating;
            }
            string tempISBN = "N/A";

            Books Abook = new Books
            {
                ISBN = tempISBN
            };
           
            //Assert
            Assert.NotNull(Abook.ISBN);
        }
        [Fact]
        public void ISBNInRange()
        {
            //Arrange
            var ISBN = new Books();
            
            //Act
            ISBN.ISBN = "0123456789";
            
            //Assert
            Assert.InRange(ISBN.ISBN.Length, 0 , 40);
        }
        [Fact]
        public void BookIDType()
        {
            //Arrange
            Books bookID = new Books();
            //Act
            bookID.BookID = 1234;
            //Assert
            Assert.IsType(typeof(int), bookID.BookID);
        }
    }
}
