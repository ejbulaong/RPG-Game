using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<IItems> Items { get; set; }

        public Shop()
        {
            Items = new List<IItems>();
            generateItems();

        }

        private void generateItems()
        {
            //Weapons
            addItem(new Weapon("W0000", "Sword", 3, 10));
            addItem(new Weapon("W0001", "Axe", 4, 12));
            addItem(new Weapon("W0002", "Longsword", 7, 15));

            //Armors
            addItem(new Armor("A0000", "Wooden Armor", 10, 8));
            addItem(new Armor("A0001", "Metal Armor", 12, 14));
            addItem(new Armor("A0002", "Golden Armor", 15, 18));

            //Potions
            addItem(new Potion("P0000", "Health Potion", 7, 5));
            addItem(new Potion("P0001", "Strong Health Potion", 11, 10));
            addItem(new Potion("P0002", "Great Health Potion", 16, 15));

            //Shields
            addItem(new Shield("S0000", "Wooden Shield", 3, 10));
            addItem(new Shield("S0001", "Battle Shield", 4, 12));
            addItem(new Shield("S0002", "Dragon Shield", 7, 15));
        }

        private void addItem(IItems item)
        {
            Items.Add(item);
        }

        public void DisplayItems()
        {
            var weapons = (from item in this.Items
                           where item is Weapon
                           select item).ToList();

            var armors = (from item in this.Items
                          where item is Armor
                          select item).ToList();

            var shields = (from item in this.Items
                           where item is Shield
                           select item).ToList();

            var potions = (from item in this.Items
                           where item is Potion
                           select item).ToList();

            var list = new List<List<IItems>> { weapons, armors, shields, potions };
            var type = new List<string> { "Weapons", "Armors", "Shields", "Potions" };

            for (var x = 0; x < list.Count(); x++)
            {
                Console.WriteLine(type[x]);
                foreach (var item in list[x])
                {
                    Console.WriteLine(item.DisplayInfo());
                }
            }
        }
    }
}
