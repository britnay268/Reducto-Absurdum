﻿// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using Reducto_Absurdum;


List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Pixie Dust",
        Price = 12.99M,
        Available = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Wizard Wand",
        Price = 22.49M,
        Available = true,
        ProductTypeId = 4
    },
    new Product()
    {
        Name = "Flying Brookstick",
        Price = 122.09M,
        Available = false,
        ProductTypeId = 3
    },
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "Apparel",
        id = 1,
    },
    new ProductType()
    {
        Name = "Potions",
        id = 2,
    },
    new ProductType()
    {
        Name = "Enchanted Objects",
        id = 3,
    },
    new ProductType()
    {
        Name = "Wands",
        id = 4,
    }
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
    else if (choice == "2")
    {
        AddProducts();
    }
    else if (choice == "3")
    {
        DeleteProduct();
    }
    else if (choice == "4")
    {
        UpdateProduct();
    }
    else
    {
        Console.WriteLine("Value entered is invalid, try again!");
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

void AddProducts()
{
    Console.WriteLine("Please enter the name of your product: ");

    string nameEntered = Console.ReadLine();

    Console.WriteLine("Please enter the price of your product: ");

    decimal priceEntered = decimal.Parse(Console.ReadLine());

    Console.WriteLine(@"Choose a number for your product type:
    1. Apparel
    2. Potions
    3. Enchanted Objects
    4. Wands");

    int productTypeEntered = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = nameEntered,
        Price = priceEntered,
        Available = true,
        ProductTypeId = productTypeEntered
    };

    products.Add(newProduct);

    Console.WriteLine($"You added {newProduct.Name} which costs ${newProduct.Price}.");
}

void DeleteProduct()
{
    Console.WriteLine("Delete a product");
}

void UpdateProduct()
{
    Console.WriteLine("Update a product");
}