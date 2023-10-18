using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Shelf
    {
        public string Identifier { get; }
        public int Floor { get; }
        public double SpaceInSquareMeters { get; } 
        public List<Item> Items { get; }

        public Shelf(string identifier, int floor)
        {
            Identifier = identifier;
            Floor = floor;
            SpaceInSquareMeters = 20;
            Items = new List<Item>();
        }

        public override string ToString()
        {
            return $"{} {}";
        }

    }
}
