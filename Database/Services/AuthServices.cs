using Microsoft.Data.SqlClient;
using CanteenBillingSystem.Database.DataAccess;

namespace CanteenBillingSystem.Database.Services
{
    public class AuthService
    {
        private readonly DbConnection _db = new DbConnection();

        public bool Login(string username, string password)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p",
                conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            int count = (int)cmd.ExecuteScalar();

            Console.WriteLine($"Debug: {username} / {password} -> {count} matches"); // ✅ Add this

            return count > 0;
        }
    }
}
