// See https://aka.ms/new-console-template for more information

using Reducto_Absurdum;


List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Pixie Dust",
        Price = 12.99M,
        Available = true,
        ProductTypeId = 2348
    },
    new Product()
    {
        Name = "Wond",
        Price = 22.49M,
        Available = true,
        ProductTypeId = 6648
    },
    new Product()
    {
        Name = "Flying Brookstick",
        Price = 122.09M,
        Available = false,
        ProductTypeId = 2399
    },
};

string choice = null;

while (choice != "0")
{
    Console.WriteLine(@"Main Menu:
    0. Exit
    1. View all Products
    2. Add a product to the inventory
    3. Delete a product from the inventory
    4. Update a product's details");

    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("You have exited!");
    }
    else if (choice == "1")
    {
        ViewAllProducts();
    }
    else
    {
        Console.WriteLine("Under construction");
    }
};

void ViewAllProducts()
{
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
};