using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Shield> Shields { get; set; }
        public List<Potion> Potions { get; set; }

        public Shop()
        {
            Weapons = new List<Weapon>();
            Armors = new List<Armor>();
            Potions = new List<Potion>();
            Shields = new List<Shield>();
            generateItems();

        }

        private void generateItems()
        {
            //Weapons
            addWeapon(new Weapon("W0000", "Sword", 3, 10));
            addWeapon(new Weapon("W0001", "Axe", 4, 12));
            addWeapon(new Weapon("W0002", "Longsword", 7, 15));

            //Armors
            addArmor(new Armor("A0000", "Wooden Armor", 10, 8));
            addArmor(new Armor("A0001", "Metal Armor", 12, 14));
            addArmor(new Armor("A0002", "Golden Armor", 15, 18));

            //Potions
            addPotion(new Potion("P0000", "Health Potion", 7, 5));
            addPotion(new Potion("P0001", "Strong Health Potion", 11, 10));
            addPotion(new Potion("P0002", "Great Health Potion", 16, 15));

            //Shields
            addShield(new Shield("S0000", "Wooden Shield", 3, 10));
            addShield(new Shield("S0001", "Battle Shield", 4, 12));
            addShield(new Shield("S0002", "Dragon Shield", 7, 15));
        }

        private void addWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        private void addArmor(Armor armor)
        {
            Armors.Add(armor);
        }

        private void addPotion(Potion potion)
        {
            Potions.Add(potion);
        }

        private void addShield(Shield shield)
        {
            Shields.Add(shield);
        }
    }
}
