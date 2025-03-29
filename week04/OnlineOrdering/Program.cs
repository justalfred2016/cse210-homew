using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
   
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address usaAddress = new Address("123 Main St", "New York", "NY", "USA");
            Address canadaAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Smith", usaAddress);
            Customer customer2 = new Customer("Marie Dubois", canadaAddress);

            // Create products
            Product product1 = new Product("Widget", "W123", 3.50m, 2);
            Product product2 = new Product("Gadget", "G456", 12.99m, 1);
            Product product3 = new Product("Thingamajig", "T789", 7.25m, 3);
            Product product4 = new Product("Doodad", "D012", 5.00m, 4);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order information
            List<Order> orders = new List<Order> { order1, order2 };

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"\nORDER {i + 1} DETAILS:");
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(orders[i].GetPackingLabel());
                Console.WriteLine(orders[i].GetShippingLabel());
                Console.WriteLine($"\nTOTAL COST: {orders[i].GetTotalCost():C2}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}