using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Shelf
    {
        public int ShelfID { get; set; }
        public int FloorNumber { get; set; }
        public int SpaceAvailable { get; set; }
        public List<Item> Items { get; set; }

        public Shelf(int shelfID, int floorNumber, int spaceAvailable)
        {
            ShelfID = shelfID;
            FloorNumber = floorNumber;
            SpaceAvailable = spaceAvailable;
            Items = new List<Item>();
        }
        public override string ToString()
        {
            return $"ShelfID: {ShelfID}, FloorNumber: {FloorNumber}, SpaceAvailable: {SpaceAvailable}, Items: {string.Join(", ", Items)}";
        }


    }
}
