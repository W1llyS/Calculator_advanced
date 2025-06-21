using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calculator_V2.DataAccess;
using Calculator_V2.Models;
using Calculator_V2.Services;
using System.Collections.Generic;

namespace Calculator_V2.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private Mock<DataLayer> _mockDataLayer;
        private CalculatorService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockDataLayer = new Mock<DataLayer>();
            _service = new CalculatorService(_mockDataLayer.Object);
        }

        [TestMethod]
        public void Compute_Addition_ReturnsCorrectResult()
        {
            double result = _service.Calculate(5, 3, "+", false);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Compute_Division_RoundsCorrectly()
        {
            double result = _service.Calculate(7, 2, "/", true);
            Assert.AreEqual(4, result); // 7/2 = 3.5 → rounded to 4
        }

       
    }
}
