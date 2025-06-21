using Calculator_V2.Models;
using Calculator_V2.DataAccess;
using System;
using System.Collections.Generic;

namespace Calculator_V2.Services
{
    public class CalculatorService
    {
        private readonly DataLayer _dataLayer;

        public CalculatorService(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public double Compute(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                        throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }
        }

        public double Calculate(double a, double b, string operation, bool round)
        {
            var result = Compute(a, b, operation);
            if (round)
                result = Math.Round(result);

            _dataLayer.SaveResult(a, operation, b, result);
            return result;
        }

        public List<CalculationRecord> GetHistory()
        {
            return _dataLayer.GetHistory();
        }
    }
}
