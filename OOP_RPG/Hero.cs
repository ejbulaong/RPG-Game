using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; private set; }
        public int Defense { get; private set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Golds { get; set; }
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            ArmorsBag = new List<Armor>();
            WeaponsBag = new List<Weapon>();
            Strength = 10;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            Golds = 20;//initial golds provided for testing the shop functionality
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");

            if (this.EquippedWeapon != null)
            {
                Console.WriteLine("Strength: " + this.Strength + "(+" + this.EquippedWeapon.Strength + ")");
            }
            else
            {
                Console.WriteLine("Strength: " + this.Strength);
            }

            if (this.EquippedArmor != null)
            {

                Console.WriteLine("Defense: " + this.Defense + "(+" + this.EquippedArmor.Defense + ")");
            }
            else
            {
                Console.WriteLine("Defense: " + this.Defense);
            }


            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");

            foreach (var weapon in this.WeaponsBag)
            {
                Console.WriteLine(weapon.Name + " of " + weapon.Strength + " Strength");
            }

            Console.WriteLine("Armor: ");

            foreach (var armor in this.ArmorsBag)
            {
                Console.WriteLine(armor.Name + " of " + armor.Defense + " Defense");
            }
            Console.WriteLine("Golds: " + Golds);
        }

        public void EquipWeapon()
        {
            if (!WeaponsBag.Any())
            {
                Console.WriteLine("Sorry. No weapon to equip!!!");
            }
            else
            {
                var weaponsID = "";
                Console.Write("Please type weapon's ID: ");
                weaponsID = Console.ReadLine();

                foreach (var weapon in this.WeaponsBag)
                {
                    if (weapon.ID.ToLower() == weaponsID.ToLower() && weapon.Equipped == true)
                    {
                        Console.WriteLine("Weapon already equipped!!!");
                    }
                    else if (weapon.ID.ToLower() == weaponsID.ToLower() && weapon.Equipped == false)
                    {
                        this.EquippedWeapon = weapon;
                        weapon.Equipped = true;
                        Console.WriteLine("Successfully equipped weapon!!!");
                    }
                }
            }
        }

        public void EquipArmor()
        {
            if (!ArmorsBag.Any())
            {
                Console.WriteLine("Sorry. No armor to equip!!!");
            }
            else
            {
                var armorsID = "";
                Console.Write("Please type armor's ID: ");
                armorsID = Console.ReadLine();

                foreach (var armor in this.ArmorsBag)
                {
                    if (armor.ID.ToLower() == armorsID.ToLower() && armor.Equipped == true)
                    {
                        Console.WriteLine("Armor already equipped!!!");
                    }
                    else if (armor.ID.ToLower() == armorsID.ToLower() && armor.Equipped == false)
                    {
                        this.EquippedArmor = armor;
                        armor.Equipped = true;
                        Console.WriteLine("Successfully equipped armor!!!");
                    }
                }
            }
        }

        public void UnequipWeapon()
        {
            if (this.EquippedWeapon == null)
            {
                Console.WriteLine("Sorry you are not equipped with any weapon!!!");
            }
            else
            {
                this.EquippedWeapon = null;
                foreach (var weapon in this.WeaponsBag)
                {
                    weapon.Equipped = false;
                }
                Console.WriteLine("Weapon successfully unequiped!!!");
            }
        }

        public void UnequipArmor()
        {
            if (this.EquippedArmor == null)
            {
                Console.WriteLine("Sorry you are not equipped with any armor!!!");
            }
            else
            {
                this.EquippedArmor = null;
                foreach (var armor in this.ArmorsBag)
                {
                    armor.Equipped = false;
                }
                Console.WriteLine("Armor successfully unequiped!!!");
            }
        }

        public void PurchaseWeapon(Weapon weapon)
        {
            if (weapon == null)
            {
                Console.WriteLine($"Sorry. weapon not found!!!");
            }
            else if (this.Golds < weapon.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= weapon.Price;
                Console.WriteLine($"{weapon.Name} successfully purchased!!!");
                WeaponsBag.Add(weapon);
            }

        }

        public void PurchaseArmor(Armor armor)
        {
            if (armor == null)
            {
                Console.WriteLine($"Sorry. armor not found!!!");
            }
            else if (this.Golds < armor.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= armor.Price;
                Console.WriteLine($"{armor.Name} successfully purchased!!!");
                ArmorsBag.Add(armor);
            }
        }
    }
}