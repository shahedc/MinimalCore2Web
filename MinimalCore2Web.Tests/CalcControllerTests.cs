using MinimalCore2Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MinimalCore2Web.Models;
using MinimalCore2Web.Services;

namespace MinimalCore2Web.Tests
{
    public class CalcControllerTests
    {
        // OPTION 1: constructor injection
        //[Fact]
        //public void ShowsCorrectIndexView()
        //{
        //    var mockExternalService = new Mock<IExternalService>();
        //    mockExternalService.Setup(m => m.DoGreatThings()).Returns(true);
        //    var objExternalService = mockExternalService.Object;

        //    var cc = new CalcController(mockExternalService.Object);
        //    var result = cc.Index() as ViewResult;
        //    Assert.Equal("Index", result.ViewName);
        //}

        // Option 2: setter injection (no param in default constructor)
        [Fact]
        public void ShowsCorrectIndexView()
        {
            var cc = new CalcController();
            var result = cc.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        // OPTION 1: constructor injection
        //[Theory]
        //[InlineData(1, 2, 3)]
        //public void ShowsCorrectProcessView(int x, int y, int expectedResult)
        //{
        //    var mockExternalService = new Mock<IExternalService>();
        //    mockExternalService.Setup(m => m.DoGreatThings()).Returns(true);
        //    var objExternalService = mockExternalService.Object;

        //    var cc = new CalcController(mockExternalService.Object);
        //    var calcModel = new CalcViewModel()
        //    {
        //        Number1 = x,
        //        Number2 = y
        //    };


        //    var result = cc.Process(calcModel) as ViewResult;
        //    Assert.Equal(expectedResult, calcModel.Result);
        //}

        // Option 2: setter injection (no param in default constructor)
        [Theory]
        [InlineData(1, 2, 3)]
        public void ShowsCorrectProcessView(int x, int y, int expectedResult)
        {
            var cc = new CalcController();
            var calcModel = new CalcViewModel()
            {
                Number1 = x,
                Number2 = y
            };


            var result = cc.Process(calcModel, "Add") as ViewResult;
            Assert.Equal(expectedResult, calcModel.Result);
        }
    }
}