using System;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;

namespace POS
{
    public class DBActions
    {
        private readonly string _connectionString = File.ReadAllText("config.txt");
        public void ExecuteStoredProcedureVoid(string procedureName, Action<SqlCommand> configureParameters)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();

                using var cmd = new SqlCommand(procedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                configureParameters(cmd);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the database correctly. Exception: {ex}");
            }

        }

        public void ExecuteStoredProcedureReader(string procedureName, Action<SqlCommand> configureParameters, Action<SqlDataReader> handleReader)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();

                using var cmd = new SqlCommand(procedureName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                configureParameters(cmd);

                using var reader = cmd.ExecuteReader();
                handleReader(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the database correctly. Exception: {ex}");
            }
        }

    }
}