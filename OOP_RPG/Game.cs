using System;

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

        private void Main()
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

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
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
                Console.WriteLine("0. Main Menu");

                userInput = Console.ReadLine();


                if (userInput == "1")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("WEAPONS");

                    foreach (var weapon in shop.Weapons)
                    {
                        Console.WriteLine($"ID: {weapon.ID} Name: {weapon.Name} Strength: {weapon.Strength} Price: {weapon.Price} Golds");
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

                    Hero.purchaseWeapon(weaponToPurchase);
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Available Golds: {Hero.Golds}\n");
                    Console.WriteLine("ARMORS");
                    foreach (var armor in shop.Armors)
                    {
                        Console.WriteLine($"ID: {armor.ID} Name: {armor.Name} Defense: {armor.Defense} Price: {armor.Price} Golds");
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

                    Hero.purchaseArmor(armorToPurchase);
                }

            }
        }
    }
}