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
    public class TestCustomer
    {

        private static Mock<ICustomerManager> SetupMock(Customer customer)
        {
            var customermanagerMock = new Mock<ICustomerManager>();

            customermanagerMock.Setup(m =>
                    m.GetCustomerByNumber(It.IsAny<int>()))
                .Returns(customer);


            customermanagerMock.Setup(m =>
                m.AddCustomer(It.IsAny<int>()));
            return customermanagerMock;

        }




        [TestMethod]
        public void TestAddCustomer()
        {
            Mock<ICustomerManager> customermanagerMock = SetupMock(null);
            bool successfull = AddCustomerNumberOne(customermanagerMock);
            Assert.IsTrue(successfull);
            customermanagerMock.Verify(
                m => m.AddCustomer(It.Is<int>(i => i == 1)),
                    Times.Once());
        }

        private static bool AddCustomerNumberOne(Mock<ICustomerManager> customermanagerMock)
        {
            var book = new CustomerAPI(customermanagerMock.Object);
            var successfull = customermanagerMock.AddCustomer(1);
            return successfull;
        }



   



  
        public void RemoveCustomer()
        {
            var customerManagerMock = new Mock<ICustomerManager>();


            customerManagerMock.Setup(m =>
               m.GetCustomerByNumber(It.IsAny<int>()))
                .Returns(new Customer
                {
                    CustomerNr = 8,
                    Debts = 20,
                    AmountOfBooksLoaned = 2



                });


            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.RemoveCustomer(8);
            Assert.AreEqual(RemoveCustomerErrorCodes.OK, successfull);
            customerManagerMock.Verify(m =>
                m.RemoveCustomer(It.IsAny<int>()), Times.Once);
        }



        public void CustomerLoanTest()
        {
            var customerManagerMock = new Mock<ICustomerManager>();


            customerManagerMock.Setup(m =>
               m.GetCustomerByNumber(It.IsAny<int>()))
                .Returns(new Customer
                {
                    CustomerNr = 8,
                    AmountOfBooksLoaned = 2


                });


            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.BookStatusLoan(8,2,true);
            Assert.AreEqual(BookLoanStatus.OK, successfull);
            customerManagerMock.Verify(m =>
                m.AddCustomer(It.IsAny<int>()), Times.Once);
        }


    }
}
