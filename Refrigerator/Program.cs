using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using static Refrigerator.Refrigerator;

namespace Refrigerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            Refrigerator refrigerator1 = new Refrigerator(1, "Model A", "White", 5);
            Refrigerator refrigerator2 = new Refrigerator(2, "Model B", "Black", 5);
            Refrigerator refrigerator3 = new Refrigerator(3, "Model c", "Green", 5);

            refrigerators.Add(refrigerator1);
            refrigerators.Add(refrigerator2);
            refrigerators.Add(refrigerator3);


            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1: List items in the refrigerator");
                Console.WriteLine("2: Check available space in the refrigerator");
                Console.WriteLine("3: Add an item to the refrigerator");
                Console.WriteLine("4: Remove an item from the refrigerator");
                Console.WriteLine("5: Clean the refrigerator");
                Console.WriteLine("6: What do I want to eat?");
                Console.WriteLine("7: List items by expiration date");
                Console.WriteLine("8: List shelves by available space");
                Console.WriteLine("9: List refrigerators by available space");
                Console.WriteLine("10: Prepare for shopping");
                Console.WriteLine("100: Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(refrigerator1.ToString());
                        break;
                    case 2:
                        Console.WriteLine($"There is {refrigerator1.GetAvailableSpace()} square meters of free space left in the refrigerator.");
                        break;
                    case 3:
                        Item itemToAdd = GetItem();

                        if (refrigerator1.AddItem(itemToAdd))
                            Console.WriteLine("Item Added.");
                        else Console.WriteLine("There is no available space for this product.");
                        break;
                    case 4:
                        Console.WriteLine("Enter product Id that you want to take out of the refrigerator: ");
                        int itemId = int.Parse(Console.ReadLine());
                        if (refrigerator1.RemoveItem(itemId) != null)
                            Console.WriteLine("product removed.");
                        else Console.WriteLine("Product Id don't exists");
                        break;
                    case 5:
                        List<Item> expiredItems = new List<Item>();
                        expiredItems = refrigerator1.CleanRefrigerator();
                        if (expiredItems.Count > 0)
                        {
                            Console.WriteLine("Product removed:");
                            foreach (Item item in expiredItems)
                                Console.WriteLine(item.ToString());

                        }
                        else Console.WriteLine("There are no expired products.");
                        break;
                    case 6:
                        Console.WriteLine("What would you like to get:");
                        ItemType itemType = GetItemType();
                        Kashrut kashrut = GetKashrut();

                        List<Item> userFoodChoices = refrigerator1.FindFood(kashrut, itemType);
                        if (userFoodChoices.Count > 0)
                        {
                            Console.WriteLine("The products that suit your choice: ");
                            foreach (var item in userFoodChoices)
                                Console.WriteLine(item.ToString());
                        }
                        else Console.WriteLine("There are no products that suit your choice.");
                        break;
                    case 7:
                        List<Item> items = refrigerator1.SortItemsByExpiryDate();
                        if (items.Count >0)
                        {
                            Console.WriteLine("The products in the refrigerator are listed by expiration date:");
                            foreach (Item item in items)
                                Console.WriteLine(item.ToString());
                        }
                        else Console.WriteLine("There are no products.");
                        break;
                    case 8:
                        List<Shelf> sortedShelves = refrigerator1.SortShelvesByFreeSpace();

                        foreach (var shelf in sortedShelves)
                        {
                            Console.WriteLine("Free Space: " + shelf.ToString());
                        }
                        break;
                    case 9:
                        List<Refrigerator> sortedRefrigerators = SortRefrigeratorsByAvailableSpace(refrigerators);

                        foreach (var fridge in sortedRefrigerators)
                        {
                            Console.WriteLine(fridge.ToString());
                        }
                        break;
                    case 10:
                        Console.WriteLine(refrigerator1.ShoppingPreparing());
                        break;
                    case 100:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }              
            }            
        }
        public static Kashrut GetKashrut()
        {
            string KashrutItem;
            while (true)
            {
                Console.Write("Enter product kashrut (milky, meaty, parve): ");
                KashrutItem = Console.ReadLine();
                if (KashrutItem == "milky" || KashrutItem == "meaty" || KashrutItem == "parve")
                    break;
                Console.WriteLine("You must choose milky / meaty / parve.");
            }
            
            Kashrut kashrut;
            if (KashrutItem == "milky")
                kashrut = Kashrut.milky;
            else if (KashrutItem == "meaty")
                kashrut = Kashrut.meaty;
            else
                kashrut = Kashrut.parve;

            return kashrut;
        }
        public static ItemType GetItemType() 
        {
            string type;
            while (true)
            {
                Console.Write("Enter product type (food/drink): ");
                type = Console.ReadLine();
                if (type == "food" || type == "drink")
                    break;
                Console.WriteLine("You must choose food / drink.");
            }
            ItemType itemType;
            if (type == "food")
                itemType = ItemType.food;
            else 
                itemType = ItemType.drink;
            return itemType;
            
        }
        public static Item GetItem() 
        {
            Console.Write("Enter product name: ");
            string itemName = Console.ReadLine();

            ItemType itemTypeUserChoise = GetItemType();

            Kashrut kashrutUserChoice = GetKashrut();

            Console.Write("Enter the product's expiration year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter the product's expiration month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter the product's expiration day: ");
            int day = int.Parse(Console.ReadLine());
            DateTime expiryDate = new DateTime(year, month, day);
            Console.Write("Enter product size: ");
            int spaceOccupied = int.Parse(Console.ReadLine());

            Item item = new Item(itemName, itemTypeUserChoise, kashrutUserChoice, expiryDate, spaceOccupied);
            return item;
        }
        public static List<Refrigerator> SortRefrigeratorsByAvailableSpace(List<Refrigerator> refrigerators)
        {
            return refrigerators.OrderByDescending(r => r.GetAvailableSpace()).ToList();
        }
    }
}
