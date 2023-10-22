using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Refrigerator
    {
        public int RefrigeratorID { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int NumberOfShelves { get; set; }
        public List<Shelf> Shelves { get; set; }

        public Refrigerator(int refrigeratorID, string model, string color, int numberOfShelves)
        {
            RefrigeratorID = refrigeratorID;
            Model = model;
            Color = color;
            NumberOfShelves = numberOfShelves;
            Shelves = new List<Shelf>
            {
                new Shelf(1, 1, 20),
                new Shelf(2, 2, 20),
                new Shelf(3, 3, 20),
                new Shelf(4, 4, 20),
                new Shelf(5, 5, 20),
            };
        }

        public override string ToString()
        {
            return $"RefrigeratorID: {RefrigeratorID}, Model: {Model}, Color: {Color}, NumberOfShelves: {NumberOfShelves}";
        }

        public int GetAvailableSpace()
        {
            int availableSpace = 0;
            foreach (var shelf in Shelves)
            {
                availableSpace += shelf.SpaceAvailable;
            }
            return availableSpace;
        }

        public bool AddItem(Item item)
        {
            foreach (var shelf in Shelves)
            {
                if (shelf.SpaceAvailable >= item.SpaceOccupied)
                {
                    item.ShelfID = shelf.ShelfID;
                    shelf.Items.Add(item);
                    shelf.SpaceAvailable -= item.SpaceOccupied;
                    return true;
                }
            }
            return false;
        }

        public Item RemoveItem(int itemID)
        {
            Item itemToRemove = null;

            foreach (var shelf in Shelves)
            {
                foreach (var item in shelf.Items)
                {
                    if (item.ItemID == itemID)
                    {
                        shelf.Items.Remove(item);
                        itemToRemove = item;
                        break;
                    }
                }
            }
            return itemToRemove;
        }

        public List<Item> CleanRefrigerator()
        {
            DateTime now = DateTime.Now;
            List<Item> expiredItems = new List<Item>();


            foreach (var shelf in Shelves)
            {
                for (int i = 0; i <= shelf.Items.Count - 1; i++)
                {
                    if (shelf.Items[i].ExpiryDate < now)
                    {
                        expiredItems.Add(shelf.Items[i]);
                        shelf.Items.RemoveAt(i);
                    }
                }
            }
            return expiredItems;
        }

        public List<Item> FindFood(Kashrut kashrut, ItemType itemType)
        {
            List<Item> foundItems = new List<Item>();
            foreach (var shelf in Shelves)
            {
                foreach (var item in shelf.Items)
                {
                    if (item.ItemType == itemType && item.Kashrut == kashrut && item.ExpiryDate > DateTime.Now)
                    {
                        foundItems.Add(item);
                    }
                }
            }
            return foundItems;
        }

        public List<Item> SortItemsByExpiryDate()
        {
            List<Item> allItem = new List<Item>();
            foreach (var shelf in Shelves)
            {
                allItem = allItem.Concat(shelf.Items).ToList();
            }
            allItem = allItem.OrderBy(item => item.ExpiryDate).ToList();

            return allItem;
        }
        public List<Shelf> SortShelvesByFreeSpace()
        {
            return Shelves.OrderByDescending(shelf => shelf.SpaceAvailable).ToList();
        }

        public string ShoppingPreparing()
        {
            if (GetAvailableSpace() >= 20)
                return "There is enough free space in the refrigerator.";

            CleanRefrigerator();

            if (GetAvailableSpace() >= 20)
                return "After removing expired items, there is enough free space in the refrigerator.";

            RemoveItemsByParameters(Kashrut.milky, 3);
            if (GetAvailableSpace() >= 20)
                return "The refrigerator has been emptied of all milk items that will expire in less than three days.";
            RemoveItemsByParameters(Kashrut.meaty, 7);
            if (GetAvailableSpace() >= 20)
                return "The refrigerator has been emptied of all meat items that will expire in less than a week.";
            RemoveItemsByParameters(Kashrut.parve, 1);
            if (GetAvailableSpace() >= 20)
                return "The fridge was cleared of all the parve items that were valid for less than a day.";

            return "Not enough space was freed up in the fridge. This is not the time to shop.";

        }
        public void RemoveItemsByParameters(Kashrut kashrut, int numOfDays)
        {
            List<Item> itemsToRemove = new List<Item>();

            foreach (var shelf in Shelves)
            {
                foreach (var item in shelf.Items)
                {
                    if (item.Kashrut == kashrut && item.ExpiryDate < DateTime.Now.AddDays(numOfDays))
                    {
                        itemsToRemove.Add(item);
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    shelf.Items.Remove(item);
                }

                itemsToRemove.Clear();
            }
        }

    }
}





