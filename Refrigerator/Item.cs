using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    enum ItemType
    {
        food,
        drink 
    } enum Kashrut
    {
        milky, 
        meaty,
        parve
    }
    internal class Item
    {
        public static int GeneralItemID { get; set; } = 1;
        public int ItemID { get; set; }
        public string ProductName { get; set; }
        public int ShelfID { get; set; }
        public ItemType ItemType { get; set; }
        public Kashrut Kashrut { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SpaceOccupied { get; set; }

        public Item(string productName, ItemType itemType, Kashrut kashrut, DateTime expiryDate, int spaceOccupied)
        {
            ItemID = GeneralItemID++;
            ProductName = productName;
            ItemType = itemType;
            Kashrut = kashrut;
            ExpiryDate = expiryDate;
            SpaceOccupied = spaceOccupied;
        }

        public override string ToString()
        {
            return $"ItemID: {ItemID}, ProductName: {ProductName}, ItemType: {ItemType}, KosherType: {Kashrut}, ExpiryDate: {ExpiryDate}, SpaceOccupied: {SpaceOccupied}";
        }

    }
}
