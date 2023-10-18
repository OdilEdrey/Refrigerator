using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator = new Refrigerator("Model A", "White", 5);

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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
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
    }
}
