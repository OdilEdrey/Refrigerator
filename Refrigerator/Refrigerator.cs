using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class Refrigerator
    {
        private int Identifier;
        public string Model { get; }
        public string Color { get; }
        public int NumberOfShelves { get; } 
        public List<Shelf> Shelves { get; }

        public Refrigerator(string model, string color, int identifier)
        {
            Identifier = identifier;
            Model = model;
            Color = color;
            NumberOfShelves = 5;
            Shelves = new List<Shelf>();
        }

        public override string ToString()
        {
            return $"{} {}";
        }

        public int AvailableSpace()
        {
            return 0;
        }

        public void AddItem(Item item)
        {
            Shelves[0]
        }

        public Item RemoveItem(string itemId)
        {
            return null;
        }

        public void Clean()
        {
        }

        public List<Item> WhatToEat(string kashrut, string type)
        {
            return new List<Item>();
        }

        public void PrepareForShopping()
        {
        }

    }
}
