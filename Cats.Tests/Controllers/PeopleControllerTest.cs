using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cats;
using Cats.Controllers;

namespace Cats.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PeopleController controller = new PeopleController();

            // Act
            ViewResult result = controller.GetCatsInfo() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        
    }
}
