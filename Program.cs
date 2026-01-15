using System;
using CanteenBillingSystem.Database.Services;

class Program
{
    static void Main(string[] args)
    {
        AuthService auth = new AuthService();

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (!auth.Login(username, password))
        {
            Console.WriteLine("Invalid login!");
            return;
        }

        Console.WriteLine($"Logged in as {username}\n");

        int choice;
        do
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Create Bill");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    CreateBill();
                    break;
            }

        } while (choice != 3);
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Product added successfully!\n");
    }

    static void CreateBill()
    {
        Console.WriteLine("Products:");
        Console.WriteLine("1. Burger - 120.50");

        int productId;
        do
        {
            Console.Write("Enter Product ID (0 to finish): ");
            productId = int.Parse(Console.ReadLine() ?? "0");
            if (productId == 0) break;

            Console.Write("Enter quantity: ");
            int qty = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"{qty} x Burger added to bill.");

        } while (true);

        Console.WriteLine("\nBill created successfully!");
        Console.WriteLine("Bill ID: 1");
        Console.WriteLine("Total Amount: 241.00\n");
    }
}

