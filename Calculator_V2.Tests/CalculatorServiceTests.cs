using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calculator_V2.Services;
using Calculator_V2.DataAccess;

namespace Calculator_V2.Tests
{
    [TestClass]
    public class CalculatorServiceLogicTests
    {
        private Mock<IDataAccess> _mockDataAccess;
        private CalculatorService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockDataAccess = new Mock<IDataAccess>();
            _service = new CalculatorService(_mockDataAccess.Object);
        }

        [TestMethod]
        public void Compute_Addition_ReturnsSum()
        {
            double result = _service.Calculate(10, 5, "+", false);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Compute_Subtraction_ReturnsDifference()
        {
            double result = _service.Calculate(10, 5, "-", false);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Compute_Multiplication_ReturnsProduct()
        {
            double result = _service.Calculate(4, 3, "*", false);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Compute_Division_ReturnsQuotient()
        {
            double result = _service.Calculate(10, 2, "/", false);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Compute_Division_RoundsResult()
        {
            double result = _service.Calculate(7, 2, "/", true); // 3.5 → 4
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void Compute_DivisionByZero_ThrowsException()
        {
            _service.Calculate(5, 0, "/", false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Compute_InvalidOperator_ThrowsException()
        {
            _service.Calculate(5, 3, "%", false);
        }
    }
}

