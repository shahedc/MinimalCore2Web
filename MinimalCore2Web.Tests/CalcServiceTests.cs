﻿using MinimalCore2Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MinimalCore2Web.Services;
using System;

namespace MinimalCore2Web.Tests
{
    public class CalcServiceTests
    {
        [Theory]
        [InlineData(4, 5, 9)]
        [InlineData(2, 3, 5)]
        public void TestAddNumbers(int x, int y, int expectedResult)
        {
            var cs = new CalcService();
            var result = cs.AddNumbers(x, y);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(12, 2, 24)]
        public void TestMultiplyNumbers(int x, int y, int expectedResult)
        {
            var cs = new CalcService();
            var actualResult = cs.MultiplyNumbers(x, y);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(2, 4, true, 6)]
        [InlineData(2, 4, false, -999)]
        public void TestAddNumbersViaInterface(int x, int y, bool isSuccessful, int expectedResult)
        {
            var mockExternalService = new Mock<IExternalService>();
            mockExternalService.Setup(m => m.DoGreatThings()).Returns(isSuccessful);
            var objExternalService = mockExternalService.Object;

            var calcService = new CalcService();
            var result = calcService.AddNumbersIfSuccessful(x, y, objExternalService);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        public void TestEvenNumber(int x, bool expectedResult)
        {
            var cs = new CalcService();
            var actualResult = cs.IsEven(x);
            Assert.Equal(expectedResult, actualResult);
        }

        //[Theory(Skip = "Don't run this test for now")]
        [InlineData(2)]
        public void TestEvenNumber(int x)
        {
            var cs = new CalcService();
            var actualResult = cs.IsEven(x);
            Assert.True(actualResult);
        }

        [Theory]
        //[InlineData(1, false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(22, true)]
        [InlineData(32, true)]
        public void TestEvenOrOdd(int x, bool isEven)
        {
            var cs = new CalcService();
            var actualResult = cs.IsEvenOrOdd(x);
            Assert.Equal(isEven, actualResult);
        }

        //[Theory(Skip="this is broken")]
        [Theory]
        [InlineData(1, 0)]
        public void TestDivideByZero(int x, int y)
        {
            var cs = new CalcService();

            Exception ex = Assert
                .Throws<DivideByZeroException>(() => cs.UnsafeDivide(x, y));

        }
    }
}