using System.Collections.Generic;
using Calculator_V2.Models;

namespace Calculator_V2.DataAccess
{
    public interface IDataAccess
    {
        void SaveResult(double firstNumber, string operation, double secondNumber, double result);
        List<CalculationRecord> GetHistory();
    }
}
