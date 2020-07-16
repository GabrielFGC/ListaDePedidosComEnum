using System;
using System.Globalization;
using Pedidos.Entities;
using Pedidos.Entities.Enums;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Cliente Data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth data (DD/MM/YYYY) ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, date);

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus order = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Order dados = new Order(DateTime.Now, order, client);

            Console.Write("\nHow many items to this order? ");
            int items = int.Parse(Console.ReadLine());

            for (int i = 0; i < items; i++)
            {
                Console.WriteLine($"\nEnter {i + 1} item data: ");
                Console.Write("Product name: ");
                string products = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(products, price);

                OrdemItem ordemItem = new OrdemItem(quantity, price, product);

                dados.AddItem(ordemItem);
            }

            Console.WriteLine("\nOrder Summary");

            Console.WriteLine(dados);

        }
    }
}
