using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address addr1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer cust1 = new Customer("Miguel", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Pen", "P001", 3.0, 5));
        order1.AddProduct(new Product("Notebook", "P002", 10.0, 2));

        // Order 2 (Outside USA)
        Address addr2 = new Address("456 Calle", "Orizaba", "Veracruz", "Mexico");
        Customer cust2 = new Customer("Juan", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Pencil", "P003", 2.0, 10));
        order2.AddProduct(new Product("Eraser", "P004", 1.5, 4));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        Console.WriteLine("\n-----------------\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}