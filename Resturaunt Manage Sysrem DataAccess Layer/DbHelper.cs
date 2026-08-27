using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class DbHelper
    {
        // Update the connection string to match your SQL Server instance
        private static readonly string _connectionString =
            "Server=localhost;Database=RestaurantDB;Integrated Security=True;";

        public static SqlConnection CreateConnection()
        {
            return  new SqlConnection(_connectionString); 
        }

        public static SqlCommand CreateCommand(SqlConnection connection, string sql)
        {
            return new SqlCommand(sql, connection);
        }

        public static void AddParameter(SqlCommand command, string name, object value)
        {
            command.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }
    }
}
