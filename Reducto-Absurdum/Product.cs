using System;
namespace Reducto_Absurdum;

public class Product
{
    public string ? Name { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }
    public ProductType ProductTypeId { get; set; }
    public DateTime DateStocked { get; set; }
    // Why are we doing this? In Thrown for a Loop, we calculated a TimeSpan in our code without using a class property, and that worked fine. The disadvantage of what we did in Thrown For A Loop is that the code outside of the class needed to know how to use the properties of the Product class to calculate the age of the product. The code needed to know all of the implementation details. Here, we are keeping all of those details in the Product class itself, so that all the code that uses the class needs to know is that there is a property on the class DaysOnShelf that can be accessed. This is an example of the first pillar of Object-Oriented Programming (OOP) - abstraction.
    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }
}
