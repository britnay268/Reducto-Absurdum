// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using Reducto_Absurdum;


List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Pixie Dust",
        Price = 12.99M,
        Available = true,
        ProductTypeId = new ProductType
        {
            Name = "Enchanted Objects",
            id = 3,
        }
    },
    new Product()
    {
        Name = "Wizard Wand",
        Price = 22.49M,
        Available = true,
        ProductTypeId = new ProductType
        {
            Name = "Wands",
            id = 4,
        }
    },
    new Product()
    {
        Name = "Flying Brookstick",
        Price = 122.09M,
        Available = false,
        ProductTypeId = new ProductType
        {
            Name = "Enchanted Objects",
            id = 3,
        }
    },
    new Product()
    {
        Name = "Harry Potter Tshirt",
        Price = 25.99M,
        Available = true,
        ProductTypeId = new ProductType
        {
             Name = "Apparel",
             id = 1,
        }
    },
    new Product()
    {
        Name = "Draught of Peace",
        Price = 22.99M,
        Available = true,
        ProductTypeId = new ProductType
        {
             Name = "Potions",
             id = 2,
        }
    },
    new Product()
    {
        Name = "Elixir of Life",
        Price = 52.99M,
        Available = true,
        ProductTypeId = new ProductType
        {
             Name = "Potions",
             id = 2,
        }
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

string? choice = null;

while (choice != "0")
{
    Console.WriteLine(@"Main Menu:
    0. Exit
    1. View all Products
    2. Add a product to the inventory
    3. Delete a product from the inventory
    4. Update a product's details
    5. Search product by product type");

    choice = Console.ReadLine();

    //if (choice == "0")
    //    Console.WriteLine("You have exited!");
    //else if (choice == "1")
    //    ViewAllProducts();
    //else if (choice == "2")
    //    AddProducts();
    //else if (choice == "3")
    //    DeleteProduct();
    //else if (choice == "4")
    //    UpdateProduct();
    //else if (choice == "5")
    //    SearchByProductType();
    //else
    //    Console.WriteLine("Value entered is invalid, try again!");

    switch (choice)
    {
        case "1":
            ViewAllProducts();
            break;
        case "2":
            AddProducts();
            break;
        case "3":
            DeleteProduct();
            break;
        case "4":
            UpdateProduct();
            break;
        case "5":
            SearchByProductType();
            break;
        default:
            if (choice.Equals("0"))
            {
                Console.WriteLine("You have exited!");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please choose a valid option!");
            }
            break;
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

void ViewAllProductTypes()
{
    int i = 1;
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{i++}. {ProductType(productType)}");
    }
}

void AddProducts()
{
    bool validInput = false;

    while (!validInput)
    {
        Console.WriteLine("Please enter the name of your product: ");

        string nameEntered = Console.ReadLine();

        Console.WriteLine("Please enter the price of your product: ");

        decimal priceEntered = decimal.Parse(Console.ReadLine());

        Console.WriteLine(@"Choose a number for your product type:");

        ViewAllProductTypes();

        int productTypeEntered = int.Parse(Console.ReadLine());

        if (productTypeEntered > 0 && productTypeEntered < productTypes.Count)
        {
            int productTypeIndex = productTypeEntered - 1;
            ProductType selectedProductType = productTypes[productTypeIndex];

            Product newProduct = new Product
            {
                Name = nameEntered,
                Price = priceEntered,
                Available = true,
                ProductTypeId = selectedProductType,
            };

            products.Add(newProduct);

            Console.WriteLine($"You added {newProduct.Name} which costs ${newProduct.Price}.");

            validInput = true;
        }
        else
        {
            Console.WriteLine("Please enter a valid option from the product type!");
        }
    }
}

void DeleteProduct()
{
    Console.WriteLine("Choose a product by number that you want to delete: ");

    ViewAllProducts();

    int choice = int.Parse(Console.ReadLine());

    products.RemoveAt(choice - 1);

    Console.WriteLine("You have successfully removed the product from the list!");
}

void UpdateProduct()
{
    Console.WriteLine("Choose a product (by number) you would like to update");

    ViewAllProducts();

    int choice = int.Parse(Console.ReadLine());

    Product chosenProduct = null;

    chosenProduct = products[choice - 1];

    void UserChosenProduct()
    {
        Console.WriteLine($@"You have chosen:
        Name: {chosenProduct.Name}
        Price: {chosenProduct.Price}
        Available: {chosenProduct.Available}
        Product Type ID: {chosenProduct.ProductTypeId.id}
        Product Type Name: { chosenProduct.ProductTypeId.Name}
        ");
    }

    UserChosenProduct();

    Console.WriteLine(@"Please choose an option (by number) to edit:
    1. Name
    2. Price
    3. Availability
    4. Product Type");

    int selection = int.Parse(Console.ReadLine());

    switch (selection)
    {
        case 1:
            Console.WriteLine("Enter a new name for the product:");
            string newName = Console.ReadLine();
            products[choice - 1].Name = newName;
            Console.WriteLine("The name of the chosen Product has been updated!");
            UserChosenProduct();
            break;
        case 2:
            Console.WriteLine("Enter a new price for the product:");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            products[choice - 1].Price = newPrice;
            Console.WriteLine("The price of the chosen Product has been updated!");
            UserChosenProduct();
            break;
        case 3:
            Console.WriteLine(@"Select an option (by number) for product's availability:
            1. Available
            2. Sold");
            string newAvailability = Console.ReadLine();
            if (newAvailability == "1")
            {
                products[choice - 1].Available = true;
            }
            else if (newAvailability == "2")
            {
                products[choice - 1].Available = false;
            }
            Console.WriteLine("The availability of the chosen Product has been updated!");
            UserChosenProduct();
            break;
        case 4:
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Select a new product type (by number) for the product:");
                ViewAllProductTypes();
                int newProductType = int.Parse(Console.ReadLine());

                if (newProductType > 0 && newProductType <= productTypes.Count)
                {
                    products[choice - 1].ProductTypeId.id = newProductType;
                    products[choice - 1].ProductTypeId.Name = productTypes[newProductType - 1].Name;
                    UserChosenProduct();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please choose an option from the list!");
                }
            }
            break;
        default:
            Console.WriteLine("Try again!");
            break;
    }
}

string ProductType(ProductType productType)
{
    string productTypeString = productType.Name;

    return productTypeString;
}

void SearchByProductType()
{
    bool validInput = false;

    while (!validInput)
    {
        try
        {
            Console.WriteLine("Select a product type (by number) to look for a product:");

            ViewAllProductTypes();

            int choice = int.Parse(Console.ReadLine());

            if (choice > 0 && choice <= productTypes.Count)
            {
                List<string> productByType = products.Where(p => p.ProductTypeId.id == choice).Select(p => p.Name).ToList();

                foreach (string name in productByType)
                {
                    Console.WriteLine(name);
                }
                validInput = true;
            }
            else
            {
                Console.WriteLine("Your selection is out of range. Please choose a number that matches the product type!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a number!");
        }  
    }

}