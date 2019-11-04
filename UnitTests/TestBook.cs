using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using Moq;
using DataInterface;
using ExamUppg;
using System.Collections.Generic;
using System.Collections;

namespace Unittests
{
    [TestClass]
    public class TestBook
    {

        private static Mock<IBookManager> SetupMock(Book book)
        {
            var bookmanagerMock = new Mock<IBookManager>();

            bookmanagerMock.Setup(m =>
                    m.GetBookByNumber(It.IsAny<long>()))
                .Returns(book);


            bookmanagerMock.Setup(m =>
                m.AddBook(It.IsAny<long>()));
            return bookmanagerMock;

        }




        [TestMethod]
        public void TestAddBook()
        {
            Mock<IBookManager> bookmanagerMock = SetupMock(null);
            bool successfull = AddBookNumberOne(bookmanagerMock);
            Assert.IsTrue(successfull);
            bookmanagerMock.Verify(
                m => m.AddBook(It.Is<int>(i => i == 1)),
                    Times.Once());
        }

        private static bool AddBookNumberOne(Mock<IBookManager> bookmanagerMock)
        {
            var book = new BookAPI(bookmanagerMock.Object);
            var successfull = book.AddBook(1);
            return successfull;
        }



        [TestMethod]
        public void TestMethodBook()
        {
            var book = new Book();
            book.Price = 200;//temp
            book.ISBN = 9780132911221;
            Assert.AreEqual(book.ISBN, 9780132911221);
            Assert.AreEqual(200, book.Price);
            Assert.AreEqual(1,((9*3)+7+(8*3)+0+(1*3)+3+(2*3)+9+(1*3)+1+(2*3)+2)%10);
          
        }



        public void MoveBook()
        {
            var bookManagerMock = new Mock<IBookManager>();

            var shelfManagerMock = new Mock<IShelfManager>();


            shelfManagerMock.Setup(m =>
          m.GetShelfByNumber(It.IsAny<int>()))
           .Returns(new Shelf { ShelfNr = 2 });



            bookManagerMock.Setup(m =>
        m.GetBookByNumber(It.IsAny<long>()))
         .Returns(new Book
         {

             ISBN = 9780132911221,
             Shelf = new Shelf()

         });




            var bookAPI = new BookAPI(bookManagerMock.Object, shelfManagerMock.Object);
            var result = bookAPI.MoveBook(1, true);
            Assert.AreEqual(MoveBookErrorCodes.OK, result);
            bookManagerMock.Verify(m =>
                m.MoveBook(2, 2), Times.Once());



            Assert.AreEqual(shelfManagerMock.ShelfNr, bookManagerMock.ShelfNr);

            bookManagerMock.ShelfNr = 3;
        }

        public void RemoveBook()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();


            bookManagerMock.Setup(m =>
               m.GetBookByNumber(It.IsAny<long>()))
                .Returns(new Book
                {
                    BookOnLoan = new List<BookOnLoan>()

                });



            var bookAPI = new BookAPI(bookManagerMock.Object, shelfManagerMock.Object);
            var successfull = bookAPI.RemoveBook(1);
            Assert.AreEqual(RemoveBookErrorCodes.OK, successfull);
            bookManagerMock.Verify(m =>
                m.RemoveBook(It.IsAny<long>()), Times.Once);
        }


    }
}
