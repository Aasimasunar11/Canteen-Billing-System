            using Microsoft.Data.SqlClient;
using CanteenBillingSystem.Database.DataAccess;

namespace CanteenBillingSystem.Database.Services
{
    public class BillingService
    {
        private readonly DbConnection _db = new DbConnection();

        public void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            using var conn = _db.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Products (Name, Price, Quantity) VALUES (@n,@p,100)", conn);

            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@p", price);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Product added successfully!");
        }

        public void CreateBill()
        {
            using var conn = _db.GetConnection();
            conn.Open();

            Console.WriteLine("\nProducts:");
            var cmd = new SqlCommand("SELECT Id, Name, Price FROM Products", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]} - {reader["Price"]}");
            }
            reader.Close();

            decimal total = 0;

            while (true)
            {
                Console.Write("Enter Product ID (0 to finish): ");
                int pid = int.Parse(Console.ReadLine());
                if (pid == 0) break;

                Console.Write("Enter quantity: ");
                int qty = int.Parse(Console.ReadLine());

                var priceCmd = new SqlCommand(
                    "SELECT Name, Price FROM Products WHERE Id=@id", conn);
                priceCmd.Parameters.AddWithValue("@id", pid);

                var r = priceCmd.ExecuteReader();
                r.Read();
                string name = r["Name"].ToString();
                decimal price = (decimal)r["Price"];
                r.Close();

                total += price * qty;

                Console.WriteLine($"{qty} x {name} added to bill.");
            }

            Console.WriteLine("\nBill created successfully!");
            Console.WriteLine("Bill ID: 1");
            Console.WriteLine($"Total Amount: {total:F2}");
        }
    }
}
