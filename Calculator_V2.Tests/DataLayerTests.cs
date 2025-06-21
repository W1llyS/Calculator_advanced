using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_V2.DataAccess;
using System;

namespace Calculator_V2.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        private DataLayer _dataLayer;

        [TestInitialize]
        public void Setup()
        {
            _dataLayer = new DataLayer();
        }

        [TestMethod]
        public void SaveResult_DoesNotThrow()
        {
            var ex = Record.Exception(() =>
                _dataLayer.SaveResult(2, "+", 3, 5));

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void GetHistory_ReturnsList()
        {
            var history = _dataLayer.GetHistory();
            Assert.IsNotNull(history);
        }
    }

    public static class Record
    {
        public static Exception Exception(Action action)
        {
            try
            {
                action();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
