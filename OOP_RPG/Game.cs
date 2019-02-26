using System;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; }

        public Game()
        {
            Hero = new Hero();
        }

        public void Start()
        {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");

            Hero.Name = Console.ReadLine();

            Console.WriteLine("Hello " + Hero.Name);

            Main();
        }

        public void Main()
        {
            var input = "";

            while (input != "0")
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Shop");
                Console.WriteLine("0. Exit");

                input = Console.ReadLine();

                if (input == "1")
                {
                    this.Stats();
                }
                else if (input == "2")
                {
                    this.Inventory();
                }
                else if (input == "3")
                {
                    this.Fight();
                }
                else if (input == "4")
                {
                    this.Shop();
                }

                if (Hero.CurrentHP <= 0)
                {
                    return;
                }
            }
        }

        private void Stats()
        {
            Hero.ShowStats();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Inventory()
        {
            Hero.ShowInventory();

            var userInput = "";

            while (userInput != "0")
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1 - Equip Weapon");
                Console.WriteLine("2 - Equip Armor");
                Console.WriteLine("3 - Equip Shield");
                Console.WriteLine("4 - Unequip Weapon");
                Console.WriteLine("5 - Unequip Armor");
                Console.WriteLine("6 - Unequip Shield");
                Console.WriteLine("7 - Heal");
                Console.WriteLine("0 - Main Menu");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Choose a weapon to equip:");
                    foreach (var weapon in Hero.WeaponsBag)
                    {
                        Console.WriteLine(weapon.DisplayInfo());
                    }

                    Hero.EquipWeapon();
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Choose an armor to equip:");
                    foreach (var armor in Hero.ArmorsBag)
                    {
                        Console.WriteLine(armor.DisplayInfo());
                    }

                    Hero.EquipArmor();
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Choose a shield to equip:");
                    foreach (var shield in Hero.ShieldsBag)
                    {
                        Console.WriteLine(shield.DisplayInfo());
                    }
                    Hero.EquipShield();
                }
                else if (userInput == "4")
                {
                    Hero.UnequipWeapon();
                }
                else if (userInput == "5")
                {
                    Hero.UnequipArmor();
                }
                else if (userInput == "6")
                {
                    Hero.UnequipShield();
                }
                else if (userInput == "7")
                {
                    Hero.UsePotion();
                }
            }
        }         

        private void Fight()
        {
            var fight = new Fight(Hero);

            fight.Start();
        }

        private void Shop()
        {
            var shop = new Shop();
            var userInput = "";

            while (userInput != "0")
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. Weapons");
                Console.WriteLine("2. Armors");
                Console.WriteLine("3. Shields");
                Console.WriteLine("4. Health Potions");
                Console.WriteLine("0. Main Menu");

                userInput = Console.ReadLine();


                if (userInput == "1")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("WEAPONS");

                    foreach (var weapon in shop.Weapons)
                    {
                        Console.WriteLine(weapon.DisplayInfo());
                    }

                    Console.WriteLine("********************");

                    Console.Write("Please type weapon id: ");
                    var weaponID = Console.ReadLine();
                    Weapon weaponToPurchase = null;

                    foreach (var weapon in shop.Weapons)
                    {
                        if (weapon.ID.ToLower() == weaponID.ToLower())
                        {
                            weaponToPurchase = weapon;
                        }
                    }

                    Hero.PurchaseWeapon(weaponToPurchase);
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("ARMORS");
                    foreach (var armor in shop.Armors)
                    {
                        Console.WriteLine(armor.DisplayInfo());
                    }
                    Console.WriteLine("********************");
                    Console.Write("Please type armor id: ");
                    var armorID = Console.ReadLine();
                    Armor armorToPurchase = null;

                    foreach (var armor in shop.Armors)
                    {
                        if (armor.ID.ToLower() == armorID.ToLower())
                        {
                            armorToPurchase = armor;
                        }
                    }

                    Hero.PurchaseArmor(armorToPurchase);
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("SHIELDS");

                    foreach (var shield in shop.Shields)
                    {
                        Console.WriteLine(shield.DisplayInfo());
                    }

                    Console.WriteLine("********************");

                    Console.Write("Please type shield id: ");
                    var shieldID = Console.ReadLine();
                    Shield shieldToPurchase = null;

                    foreach (var shield in shop.Shields)
                    {
                        if (shield.ID.ToLower() == shieldID.ToLower())
                        {
                            shieldToPurchase = shield;
                        }
                    }

                    Hero.PurchaseShield(shieldToPurchase);
                }
                else if (userInput == "4")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("POTIONS");

                    foreach (var potion in shop.Potions)
                    {
                        Console.WriteLine(potion.DisplayInfo());
                    }

                    Console.WriteLine("********************");

                    Console.Write("Please type potion id: ");
                    var potionID = Console.ReadLine();
                    Potion potionToPurchase = null;

                    foreach (var potion in shop.Potions)
                    {
                        if (potion.ID.ToLower() == potionID.ToLower())
                        {
                            potionToPurchase = potion;
                        }
                    }
                    Hero.PurchasePotion(potionToPurchase);
                }
            }
        }
    }
}