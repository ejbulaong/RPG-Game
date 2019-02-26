using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Potion : IItems
    {
        public string ID { get; }
        public string Name { get; }
        public int HealthRestored { get; }
        public int Price { get; }
        public bool Equipped { get; set; }

        public Potion(string id, string name, int healthRestored, int price)
        {
            ID = id;
            Name = name;
            HealthRestored = healthRestored;
            Price = price;
        }

        public string DisplayInfo()
        {
            return $"ID: {this.ID} Name: {this.Name} Health Restored: {this.HealthRestored} Price: {this.Price} Golds";
        }
    }
}
