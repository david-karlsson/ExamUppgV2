using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataInterface;
using System.Collections.Generic;
using ExamUppg;

namespace Unittests
{
    [TestClass]
    public class AisleTest
    {

      
        private static Mock<IAisleManager> SetupMock(Aisle aisle)
        {
            var aislemanagerMock = new Mock<IAisleManager>();

            aislemanagerMock.Setup(m =>
                    m.GetAisleByNumber(It.IsAny<int>()))
                .Returns(aisle);

            aislemanagerMock.Setup(m =>
                m.AddAisle(It.IsAny<int>()));
            return aislemanagerMock;
        }

       
        [TestMethod]
        public void TestAddAisle()
        {
            Mock<IAisleManager> aisleManagerMock = SetupMock(null);
            bool successfull = AddAisleNumberOne(aisleManagerMock);
            Assert.IsTrue(successfull);
            aisleManagerMock.Verify(
                m => m.AddAisle(It.Is<int>(i => i == 1)),
                    Times.Once());
        }

        private static bool AddAisleNumberOne(Mock<IAisleManager> aisleManagerMock)
        { 
            var aisle = new AisleAPI(aisleManagerMock.Object,null);
            var successfull = aisle.AddAisle(1);
            return successfull;
        }


        public void RemoveEmptyAisle()
        {
            var aisleManagerMock = new Mock<IAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();
            

            aisleManagerMock.Setup(m =>
               m.GetAisleByNumber(It.IsAny<int>()))
                .Returns(new Aisle
                {
                    AisleNr = 1,
                    Shelf = new List<Shelf>()


                });

           

            var libraryAPI = new AisleAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var successfull = libraryAPI.RemoveAisle(1);
            Assert.AreEqual(RemoveAisleErrorCodes.OK, successfull);
            aisleManagerMock.Verify(m =>
                m.RemoveAisle(It.IsAny<int>()), Times.Once);
        }

    }

}







    //Assert.IsTrue();



