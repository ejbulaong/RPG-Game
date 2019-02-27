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
                Console.WriteLine("3. View Achievements");
                Console.WriteLine("4. Fight Monster");
                Console.WriteLine("5. Shop");
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
                    this.Achievement();
                }
                else if (input == "4")
                {
                    this.Fight();
                }
                else if (input == "5")
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
                Console.WriteLine("1 - Equip Item");
                Console.WriteLine("2 - Unequip Item");
                Console.WriteLine("3 - Use Potion");
                Console.WriteLine("4 - Sell Item");
                Console.WriteLine("0 - Main Menu");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    EquipItem();
                }
                else if (userInput == "2")
                {
                    UnequipItem();
                }
                else if (userInput == "3")
                {
                    Hero.UsePotion();
                }
                else if (userInput == "4")
                {
                    SellItem();
                }
            }
        }

        private void SellItem()
        {

        }

        private void UnequipItem()
        {
            if (Hero.EquippedArmor == null && Hero.EquippedWeapon == null && Hero.EquippedShield == null)
            {
                Console.WriteLine("You are not equipped with any item!!!");
            }
            else
            {
                var userInput = "";
                IItems itemToUnequip = null;
                var equippedItems = (from item in Hero.ItemsBag
                                     where (item is Weapon && ((Weapon)item).Equipped == true) ||
                                        (item is Armor && ((Armor)item).Equipped == true) ||
                                        (item is Shield && ((Shield)item).Equipped == true)
                                     select item).ToList();

                Console.WriteLine("Equipped Items");
                foreach (var item in equippedItems)
                {
                    Console.WriteLine(item.DisplayInfo());
                }
                Console.Write("Please enter the Item's ID to unequip: ");
                userInput = Console.ReadLine();

                foreach (var item in equippedItems)
                {
                    if (item.ID.ToLower() == userInput.ToLower())
                    {
                        itemToUnequip = item;
                    }
                }

                Hero.UnequipItem(itemToUnequip);
            }
        }

        private void EquipItem()
        {
            var userInput = "";
            IItems itemToEquip = null;
            var items = (from item in Hero.ItemsBag
                         where (item is Weapon && ((Weapon)item).Equipped == false) ||
                            (item is Armor && ((Armor)item).Equipped == false) ||
                            (item is Shield && ((Shield)item).Equipped == false)
                         select item).ToList();

            if (!items.Any())
            {
                Console.WriteLine("Sorry. No item to equip!!!");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.DisplayInfo());
                }
                Console.Write("Please enter the Item's ID to equip: ");
                userInput = Console.ReadLine();
                foreach (var item in items)
                {
                    if (item.ID.ToLower() == userInput.ToLower())
                    {
                        itemToEquip = item;
                    }
                }

                Hero.EquipItem(itemToEquip);
            }
        }

        private void Achievement()
        {
            Hero.ShowAchievements();
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

            Console.WriteLine($"Available Golds: {Hero.Golds}");
            shop.DisplayItems();
            Console.Write("Please enter the item's ID that you want to purchase: ");
            userInput = Console.ReadLine();

            var itemToPurchase = (from item in shop.Items
                                  where item.ID.ToLower() == userInput.ToLower()
                                  select item).FirstOrDefault();

            if (itemToPurchase == null)
            {
                Console.WriteLine("Sorry. Item not found!");
            }
            else if (itemToPurchase.Price > Hero.Golds)
            {
                Console.WriteLine("Sorry. You don't have enough gold!");
            }
            else
            {
                Hero.Golds -= itemToPurchase.Price;
                Hero.PurchaseItem(itemToPurchase);
            }

        }
    }
}