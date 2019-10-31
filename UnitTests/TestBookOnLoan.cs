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
    public class TestBookOnLoan
    {


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
