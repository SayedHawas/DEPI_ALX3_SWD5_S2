using Day8MVCDemo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProjectDemo
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestDiv()
        {
            // Arrange
            TestingDemoController controller = new TestingDemoController();
            //Act
            double result = controller.div(100, 2);
            //Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            TestingDemoController controller = new TestingDemoController();
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Welcome in MVC Unit Test ", result.ViewData["TestText"]);
        }
    }
}
