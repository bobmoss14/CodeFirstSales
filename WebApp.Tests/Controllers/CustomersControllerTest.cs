using System;
using System.Linq;
using CodeFirstSales;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;

namespace WebApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for CutomersControllerTest
    /// </summary>
    [TestClass]
    public class CustomersControllerTest
    {

        public static CustomersController TestContextInstance { get; set; }
        private Customer CreatedCustomer { get; set; }
        //  private Customer UpdatedCustomer { get; set; }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestContextInstance = new CustomersController();

        }

        [TestInitialize()]
        public void CustomerInitialize()
        {
            CreatedCustomer = new Customer()
            {
                FirstName = "Bella",
                LastName = "Molavi"
            };

            TestContextInstance.Post(CreatedCustomer);
        }



        [TestCleanup()]
        public void CustomerCleanup()
        {
            var customer = TestContextInstance.Get()
                .FirstOrDefault(c => c.CustomerId == CreatedCustomer.CustomerId);

            if (customer != null)
                TestContextInstance.Delete(customer.CustomerId);
            else
            {
                throw new Exception("Customer was not found!");
            }
        }


        #region Additional test attributes
        //

        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //

        #endregion

        [TestMethod]
        [Priority(1)]
        public void TestGetCustomers()
        {

            // Act
            var result = TestContextInstance.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count(), 0);
            //
        }

        [TestMethod]
        [Priority(1)]
        public void TestGetCustomer()
        {
            // Arrange
            var customer = TestContextInstance.Get().FirstOrDefault();

            // Act
            if (customer != null)
            {
                var result = TestContextInstance.Get(customer.CustomerId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(result.CustomerId, customer.CustomerId);
            }
            else
            {
                throw new Exception("no Customer is found!");
            }

            //
        }

        [TestMethod]
        [Owner("Bob MOssanen")]
        [Priority(3)]
        [Ignore()]
        public void TestGetCustomerWithNonExistentId()
        {
            // Arrange

            var result = TestContextInstance.Get(-1);


            // Act


            //Assert
            Assert.IsNull(result);


        }


        [TestMethod]
        [Priority(2)]
        public void TestAddCustomer()
        {
            // Arrange


            // Act
            var result = TestContextInstance.Get(CreatedCustomer.CustomerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CustomerId, CreatedCustomer.CustomerId);
            //
        }

        [TestMethod]
        [Priority(2)]
        public void TestUpdateCustomer()
        {
            // Arrange
            var result = TestContextInstance.Get(CreatedCustomer.CustomerId);
            result.FirstName = result.FirstName + "1";
            result.LastName = result.LastName + "1";

            // Act
            TestContextInstance.Put(result.CustomerId, result);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, CreatedCustomer.FirstName.ToLower(),true);
            //
        }
    }
}
