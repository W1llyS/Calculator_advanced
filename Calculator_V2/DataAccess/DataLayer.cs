using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Calculator_V2.Models;

namespace Calculator_V2.DataAccess
{
    public class DataLayer : IDataAccess
    {
        // with escaped backslash
        private string connectionString =
            "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=afsddafs_eee;" +
            "User Id=afsddafs_eee;" +
            "Password=DontLookVole;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;" +
            "Connection Timeout=30;";


        public void SaveResult(double firstNumber, string operation, double secondNumber, double result)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = @"
                    INSERT INTO Results (FirstNumber, Operation, SecondNumber, Result) 
                    VALUES (@FirstNumber, @Operation, @SecondNumber, @Result)";
                connection.Execute(sql, new
                {
                    FirstNumber = firstNumber,
                    Operation = operation,
                    SecondNumber = secondNumber,
                    Result = result
                });
            }
        }

        public List<CalculationRecord> GetHistory()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                const string sql = @"
                    SELECT TOP 10 FirstNumber, Operation, SecondNumber, Result 
                    FROM Results 
                    ORDER BY Id DESC";
                return connection
                    .Query<CalculationRecord>(sql)
                    .AsList();
            }
        }
    }
}
