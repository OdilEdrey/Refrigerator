using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Item
    {
        public string Identifier { get; }
        public string Name { get; }
        public Shelf Shelf { get; }
        public string Type { get; }
        public string Kashrut { get; }
        public DateTime ExpirationDate { get; }
        public double SpaceInSquareMeters { get; }

        public Item(string identifier, string name, string type, string kashrut, DateTime expirationDate, double spaceInSquareMeters)
        {
            Identifier = identifier;
            Name = name;
             Type = type;
            Kashrut = kashrut;
            ExpirationDate = expirationDate;
            SpaceInSquareMeters = spaceInSquareMeters;
        }

        public override string ToString()
        {
            return $"{} {}";
        }
    }
}
