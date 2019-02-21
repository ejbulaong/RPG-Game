using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<Weapon> Weapons = new List<Weapon>();
        public List<Armor> Armors = new List<Armor>();

        public Shop()
        {   
            //Weapons
            addWeapon(new Weapon("W0001","Sword", 3, 10));
            addWeapon(new Weapon("W0002", "Axe", 4, 12));
            addWeapon(new Weapon("W0003", "Longsword", 7, 15));

            //Armors
            addArmor(new Armor("A0001", "Wooden Armor", 10, 8));
            addArmor(new Armor("A0002", "Metal Armor", 12, 14));
            addArmor(new Armor("A0003", "Golden Armor", 15, 18));
        }

        private void addWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        private void addArmor(Armor armor)
        {
            Armors.Add(armor);
        }
    }
}
