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
                            Console.WriteLine("item Added.");
                        else Console.WriteLine("There is no available space for this item.");
                        break;
                    case 4:
                        Console.WriteLine("Enter item Id that you want to take out of the refrigerator: ");
                        int itemId = int.Parse(Console.ReadLine());
                        if (refrigerator1.RemoveItem(itemId) != null)
                            Console.WriteLine("item removed.");
                        else Console.WriteLine("item Id does not exist.");
                        break;
                    case 5:
                        List<Item> expiredItems = new List<Item>();
                        expiredItems = refrigerator1.CleanRefrigerator();
                        if (expiredItems.Count > 0)
                        {
                            Console.WriteLine("item removed:");
                            foreach (Item item in expiredItems)
                                Console.WriteLine(item.ToString());

                        }
                        else Console.WriteLine("There are no expired items.");
                        break;
                    case 6:
                        Console.WriteLine("What would you like to get:");
                        ItemType itemType = GetItemType();
                        Kashrut kashrut = GetKashrut();

                        List<Item> userFoodChoices = refrigerator1.FindFood(kashrut, itemType);
                        if (userFoodChoices.Count > 0)
                        {
                            Console.WriteLine("The items that suit your choice: ");
                            foreach (var item in userFoodChoices)
                                Console.WriteLine(item.ToString());
                        }
                        else Console.WriteLine("There are no items that suit your choice.");
                        break;
                    case 7:
                        List<Item> items = refrigerator1.SortItemsByExpiryDate();
                        if (items.Count >0)
                        {
                            Console.WriteLine("The items in the refrigerator are listed by expiration date:");
                            foreach (Item item in items)
                                Console.WriteLine(item.ToString());
                        }
                        else Console.WriteLine("There are no items.");
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
                Console.Write("Enter item kashrut (milky, meaty, parve): ");
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
                Console.Write("Enter item type (food/drink): ");
                type = Console.ReadLine();
                if (type == "food" || type == "drink")
                    break;
                Console.WriteLine("You must choose food or drink.");
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
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            ItemType itemTypeUserChoice = GetItemType(); // Implement GetItemType()

            Kashrut kashrutUserChoice = GetKashrut(); // Implement GetKashrut()
            int year, month, day;

            while (true)
            {
                Console.Write("Enter the item's expiration year (4 digits): ");
                year = int.Parse(Console.ReadLine());
                if (year >= 1000 && year <= 9999)
                {
                    break;
                }
                Console.WriteLine("Invalid year. Please enter a 4-digit year.");
            }

            while (true)
            {
                Console.Write("Enter the item's expiration month (2 digits between 01 and 12): ");
                month = int.Parse(Console.ReadLine());
                if (month >= 1 && month <= 12)
                {
                    break;
                }
                Console.WriteLine("Invalid month. Please enter a 2-digit month between 01 and 12.");
            }

            while (true)
            {
                Console.Write("Enter the item's expiration day (2 digits between 01 and 31): ");
                day = int.Parse(Console.ReadLine());
                if (day >= 1 && day <= 31)
                {
                    break;
                }
                Console.WriteLine("Invalid day. Please enter a 2-digit day between 01 and 31 based on the chosen month.");
            }

            Console.Write("Enter item size: ");
            int spaceOccupied = int.Parse(Console.ReadLine());

            Item item = new Item(itemName, itemTypeUserChoice, kashrutUserChoice, new DateTime(year, month, day), spaceOccupied);
            return item;
        }
        public static List<Refrigerator> SortRefrigeratorsByAvailableSpace(List<Refrigerator> refrigerators)
        {
            return refrigerators.OrderByDescending(r => r.GetAvailableSpace()).ToList();
        }
    }
}
