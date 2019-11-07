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



        public void CustomerReturnTest()
        {
            var customerManagerMock = new Mock<ICustomerManager>();

            customerManagerMock.Setup(m =>
               m.GetCustomerByNumber(It.IsAny<int>()))
                .Returns(new Customer
                {
                    AmountOfBooksLoaned = 2,
                    LoanPeriod = 65,
                    CustomerName = "Mr.Person",
                    CustomerAdress = "AdressStreet 123",
                    Condition = 3,


        });
           

            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.BookStatusReturnCheck(8, 9780132911221);
            Assert.AreEqual(BookReturnStatus.OK, successfull);

            customerManagerMock.Verify(m =>
                m.AddCustomer(It.IsAny<int>()), Times.Once);
        }







        public void ReminderListTest()
        {
            var customerManagerMock = new Mock<ICustomerManager>();


            customerManagerMock.Setup(m =>
               m.ReminderList(It.IsAny<int>()))
                .Returns(new ReminderList
                {
                    
                   Customer = new List <Customer>()


                

                });
         

            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.BookStatusReturnCheck(1, 9780132911221);
            Assert.AreEqual(BookReturnStatus.OK, successfull);

            customerManagerMock.Verify(m =>
                m.AddCustomer(It.IsAny<int>()), Times.Once);
        }





        public void PopularBookTest()
        {
            var bookManagerMock = new Mock<IBookManager>();

            var customerManagerMock = new Mock<ICustomerManager>();

            customerManagerMock.Setup(m =>
               m.PopularBookList(It.IsAny<int>()))
                .Returns(new PopularBookList
                {

                    PopularBook = new List<PopularBook>()




                });


            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.BookStatusReturnCheck(1, 9780132911221);
            Assert.AreEqual(BookReturnStatus.OK, successfull);

            customerManagerMock.Verify(m =>
                m.AddCustomer(It.IsAny<int>()), Times.Once);
        }




        public void PartyInvitationTest()
        {
            var customerManagerMock = new Mock<ICustomerManager>();



            customerManagerMock.Setup(m =>
               m.PartyInvitation(It.IsAny<int>()))
                .Returns(new PartyInvitation
                {

                    Minor = new List<Minor>()



                });


            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.BookStatusReturnCheck(1, 9780132911221);
            Assert.AreEqual(BookReturnStatus.OK, successfull);

            customerManagerMock.Verify(m =>
                m.AddCustomer(It.IsAny<int>()), Times.Once);
        }




    }
}
