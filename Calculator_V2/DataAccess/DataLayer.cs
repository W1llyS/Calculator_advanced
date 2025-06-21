using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Calculator_V2.Models;

namespace Calculator_V2.DataAccess
{
    public class DataLayer : IDataAccess
    {
        private string connectionString = "workstation id=SachyDB.mssql.somee.com;packet size=4096;user id=sachyckyne_SQLLogin_1;pwd=ri31z9jhqv;data source=SachyDB.mssql.somee.com;persist security info=False;initial catalog=SachyDB;TrustServerCertificate=True";

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
