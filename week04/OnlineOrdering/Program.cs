class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product(
            "Laptop",
            "P1001",
            800,
            1));

        order1.AddProduct(new Product(
            "Mouse",
            "P1002",
            25,
            2));

        order1.AddProduct(new Product(
            "Keyboard",
            "P1003",
            50,
            1));


        Address address2 = new Address(
            "45 Oxford Road",
            "London",
            "England",
            "UK");

        Customer customer2 = new Customer(
            "Sarah Johnson",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product(
            "Headphones",
            "P2001",
            100,
            1));

        order2.AddProduct(new Product(
            "Phone Case",
            "P2002",
            20,
            2));


        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}