using System.Collections.Generic;
using System.Data.SqlClient;

public class DataLayer
{
    private string connectionString = "workstation id=SachyDB.mssql.somee.com;packet size=4096;user id=sachyckyne_SQLLogin_1;pwd=ri31z9jhqv;data source=SachyDB.mssql.somee.com;persist security info=False;initial catalog=SachyDB;TrustServerCertificate=True";

    // Save the calculation result to the database
    public void SaveResult(double firstNumber, string operation, double secondNumber, double result)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Results (FirstNumber, Operation, SecondNumber, Result) VALUES (@firstNumber, @operation, @secondNumber, @result)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstNumber", firstNumber);
                command.Parameters.AddWithValue("@operation", operation);
                command.Parameters.AddWithValue("@secondNumber", secondNumber);
                command.Parameters.AddWithValue("@result", result);
                command.ExecuteNonQuery();
            }
        }
    }

    // Retrieve the calculation history from the database
    public List<CalculationRecord> GetHistory()
    {
        List<CalculationRecord> history = new List<CalculationRecord>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TOP 10 FirstNumber, Operation, SecondNumber, Result FROM Results ORDER BY Id DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CalculationRecord record = new CalculationRecord
                        {
                            FirstNumber = (double)reader["FirstNumber"],
                            Operation = reader["Operation"].ToString(),
                            SecondNumber = (double)reader["SecondNumber"],
                            Result = (double)reader["Result"]
                        };
                        history.Add(record);
                    }
                }
            }
        }

        return history; 
    }

    // Class to represent a single calculation record
    public class CalculationRecord
    {
        public double FirstNumber { get; set; }
        public string Operation { get; set; }
        public double SecondNumber { get; set; }
        public double Result { get; set; }
    }
}