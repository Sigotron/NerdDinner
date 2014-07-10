using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerdDinner.Controllers;
using NerdDinner.Models;
using NerdDinner.Tests.Fakes;

namespace NerdDinner.Tests.Controllers
{
    [TestClass]
    public class DinnerControllerTest
    {

        List<Dinner> CreateTestDinners()
        {
            List<Dinner> dinners = new List<Dinner>();

            for (int i = 0; i < 101; i++)
            {
                Dinner sampleDinner = new Dinner()
                    {
                        DinnerId = i,
                        Title = "Sample Dinner",
                        HostedBy = "someUser",
                        Address = "Some Address",
                        Country = "USA",
                        ContactPhone = "425-555-1212",
                        Description = "Some description",
                        EventDate = DateTime.Now.AddDays(i),
                        Latitude = 99,
                        Longitude = -99
                    };
                dinners.Add(sampleDinner);
            }
            return dinners;
        }

        DinnersController CreateDinnersController()
        {
            var repository = new FakeDinnerRepository(CreateTestDinners());
            return new DinnersController(repository);
        }



        [TestMethod]
        public void DetailsAction_Should_Return_View_For_Dinner()
        {

            // Arrange
            var controller = CreateDinnersController();

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView_For_BogusDinner()
        {

            // Arrange
            var controller = CreateDinnersController();

            // Act
            var result = controller.Details(999) as ViewResult;

            // Assert
            Assert.AreEqual("NotFound", result.ViewName);
        }
    }
}
