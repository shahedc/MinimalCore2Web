using MinimalCore2Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MinimalCore2Web.Models;

namespace MinimalCore2Web.Tests
{
    public class CalcControllerTests
    {
        [Fact]
        public void ShowsCorrectIndexView()
        {
            var cc = new CalcController();
            var result = cc.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

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