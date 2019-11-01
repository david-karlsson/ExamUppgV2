using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using Moq;
using DataInterface;
using ExamUppg;


namespace Unittests
{
    [TestClass]
    public class TestBookDiscard
    {

        public void SetDiscardBook()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();


            bookManagerMock.Setup(m =>
               m.GetBookByNumber(It.IsAny<long>()))
                .Returns(new Book
                {


                    BookDiscardListNr = 1,
                    Condition = 2,
                    OnLoan = false,
                    Title = "Clean Code",
                    AisleNr = 3,
                    ShelfNr = 7

                });



            var bookAPI = new BookAPI(bookManagerMock.Object, shelfManagerMock.Object);
            var successfull = bookAPI.RemoveBook(1);
            Assert.AreEqual(RemoveBookErrorCodes.PoorCondition, successfull);
            bookManagerMock.Verify(m =>
                m.RemoveBook(It.IsAny<long>()), Times.Once);
        }


        public void ShowDiscardBookList()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>(,);

            bookManagerMock.Setup(m =>
               m.GetBookDiscardList(It.IsAny<bool>()))
                .Returns(new Book
                {

                    BookDiscardList = new List<BookDiscardList>(1),


                });
        }



        [TestMethod]
        public void TestMethodBookOnLoan()
        {
            RemoveBookErrorCodes BooksIsOnLoan(int bookISBN, int bookOnLoanISBN)
            {

                return RemoveBookErrorCodes.OK;

            }  



        }










    }
}
