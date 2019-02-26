using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shield : IItems
    {
        public string ID { get; }
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }
        public bool Equipped { get; set; }

        public Shield(string id, string name, int defense, int price)
        {
            ID = id;
            Name = name;
            Defense = defense;
            Price = price;
            Equipped = false;
        }

        public string DisplayInfo()
        {
            return $"ID: {this.ID} Name: {this.Name} Defense: {this.Defense} Price: {this.Price} Golds";
        }
    }
}
