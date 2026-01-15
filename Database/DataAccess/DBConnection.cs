using Microsoft.Data.SqlClient;

namespace CanteenBillingSystem.Database.DataAccess
{
    public class DbConnection
    {
        private readonly string _connectionString =
            "Server=localhost;Database=CanteenDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
