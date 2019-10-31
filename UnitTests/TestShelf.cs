using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using Moq;
using DataInterface;
using ExamUppg;
using System.Collections.Generic;

namespace Unittests
{
    [TestClass]
    public class ShelfTest
    {



        private static Mock<IShelfManager> SetupMockShelf(Shelf shelf)
        {
            var shelfmanagerMock = new Mock<IShelfManager>();

            shelfmanagerMock.Setup(m =>
                    m.GetShelfByNumber(It.IsAny<int>()))
                .Returns(shelf);

            shelfmanagerMock.Setup(m =>
                m.AddShelf(It.IsAny<int>()));
            return shelfmanagerMock;
        }


        [TestMethod]
        public void TestAddShelf()
        {
            Mock<IShelfManager> shelfmanagerMock = SetupMockShelf(null);
            bool successfull = AddShelfNumberOne(shelfmanagerMock);
            Assert.IsTrue(successfull);
            shelfmanagerMock.Verify(
                m => m.AddShelf(It.Is<int>(i => i == 1)),
                    Times.Once());
        }

        private static bool AddShelfNumberOne(Mock<IShelfManager> shelfmanagerMock)
        {
            var shelf = new AisleAPI(shelfmanagerMock.Object);
            var successfull = shelf.AddShelf(1);
            return successfull;
        }




        public void MoveShelf()
        {
            var aisleManagerMock = new Mock<IAisleManager>();


            var shelfManagerMock = new Mock<IShelfManager>();


            aisleManagerMock.Setup(m =>
               m.GetAisleByNumber(It.IsAny<int>()))
                .Returns(new Aisle { AisleID = 2 });

            shelfManagerMock.Setup(m =>
              m.GetShelfByNumber(It.IsAny<int>()))
               .Returns(new Shelf
               {
                   ShelfID = 2,
                   Aisle = new Aisle()
               });

            var shelfAPI = new ShelfAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var result = shelfAPI.MoveShelf(1, 1);
            Assert.AreEqual(ChangeShelfErrorCodes.MoveShelf, result);
            shelfManagerMock.Verify(m =>
                m.MoveShelf(2, 2), Times.Once());

        }



        public void ChangeShelfNumber()
            {

            var shelfManagerMock = new Mock<IShelfManager>();


            shelfManagerMock.Setup(m =>
              m.GetShelfByNumber(It.IsAny<int>()))
               .Returns(new Shelf
               {
                   ShelfNr = 1
               }); ;

        }



        public void RemoveEmptyShelf()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();


            shelfManagerMock.Setup(m =>
               m.GetShelfByNumber(It.IsAny<int>()))
                .Returns(new Shelf
                {
                    ShelfNr = 1,
                    Book = new List<Book>()


                });



            var shelfAPI = new ShelfAPI(shelfManagerMock.Object, bookManagerMock.Object);
            var successfull = shelfAPI.RemoveShelf(1);
            Assert.AreEqual(RemoveShelfErrorCodes.OK, successfull);
            shelfManagerMock.Verify(m =>
                m.RemoveShelf(It.IsAny<int>()), Times.Once);


        }
    }
}