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
        public int AchievementPoints { get; set; }
        public Rank Rank { get; set; }
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set; }
        public Shield EquippedShield { get; private set; }
        public List<IItems> ItemsBag { get; set; }
        public List<Achievements> Achievements { get; set; }
        public List<Monster> KilledMonsters { get; set; }

        public Hero()
        {
            ItemsBag = new List<IItems>();
            Achievements = new List<Achievements>();
            KilledMonsters = new List<Monster>();
            Strength = 10;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            Golds = 30;//initial golds provided for testing the shop functionality
            AchievementPoints = 0;
            Rank = Rank.Novice;

            Achievements.Add(new Achievements("achievement1", "1 Monster Killed", DateTime.Now.ToString(), 1));
            Achievements.Add(new Achievements("achievement2", "3 Monster Killed", DateTime.Now.ToString(), 2));
            Achievements.Add(new Achievements("achievement3", "5 Different Monster Killed", DateTime.Now.ToString(), 3));
            Achievements.Add(new Achievements("achievement4", "10 Monster Killed", DateTime.Now.ToString(), 5));
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

            if (this.EquippedArmor != null && this.EquippedShield != null)
            {

                Console.WriteLine("Defense: " + this.Defense + "(+" + (this.EquippedArmor.Defense + this.EquippedShield.Defense) + ")");
            }
            else if (this.EquippedArmor != null && this.EquippedShield == null)
            {
                Console.WriteLine("Defense: " + this.Defense + "(+" + this.EquippedArmor.Defense + ")");
            }
            else if (this.EquippedArmor == null && this.EquippedShield != null)
            {
                Console.WriteLine("Defense: " + this.Defense + "(+" + this.EquippedShield.Defense + ")");
            }
            else
            {
                Console.WriteLine("Defense: " + this.Defense);
            }

            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Rank: " + this.Rank);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            var weapons = (from item in this.ItemsBag
                           where item is Weapon
                           select item).ToList();

            var armors = (from item in this.ItemsBag
                          where item is Armor
                          select item).ToList();

            var shields = (from item in this.ItemsBag
                           where item is Shield
                           select item).ToList();

            var potions = (from item in this.ItemsBag
                           where item is Potion
                           select item).ToList();

            var list = new List<List<IItems>> { weapons, armors, shields, potions };
            var type = new List<string> { "Weapons:", "Armors:", "Shields:", "Potions:" };

            for (var x = 0; x < list.Count(); x++)
            {
                Console.WriteLine(type[x]);
                foreach (var item in list[x])
                {
                    Console.WriteLine(item.DisplayInfo());
                }
            }
            Console.WriteLine("Golds: " + Golds);
        }

        public void PurchaseItem(IItems item)
        {
            this.ItemsBag.Add(item);
            Console.WriteLine($"{item.Name} successfully purchased");
        }

        public void SellItem(IItems item)
        {
            if (item == null)
            {
                Console.WriteLine("Sorry. Item not found!!!");
            }
            else
            {
                var userInput = "";

                Console.Write($"{item.Name} selling price is {Convert.ToInt32(item.Price * 0.75)} Golds. Are you sure you want to sell this item?[Type Y to sell item...]");
                userInput = Console.ReadLine();

                if (userInput == "Y" || userInput == "y")
                {
                    var soldPrice = Convert.ToInt32(item.Price * 0.75);
                    this.Golds += soldPrice;
                    this.ItemsBag.Remove(item);
                    Console.WriteLine($"Item sold. {soldPrice} golds received ");
                }
                else
                {
                    Console.WriteLine($"Selling Item cancelled.");
                }
            }
        }

        public void EquipItem(IItems item)
        {
            if (item == null)
            {
                Console.WriteLine("Sorry. Item not found!!!");
            }
            else
            {
                if (item is Weapon && this.EquippedWeapon == null)
                {
                    var weapon = (Weapon)item;
                    this.EquippedWeapon = weapon;
                    weapon.Equipped = true;
                    Console.WriteLine($"{item.Name} Successfully Equipped!!!");
                }
                else if (item is Armor && this.EquippedArmor == null)
                {
                    var armor = (Armor)item;
                    this.EquippedArmor = armor;
                    armor.Equipped = true;
                    Console.WriteLine($"{item.Name} Successfully Equipped!!!");
                }
                else if (item is Shield && this.EquippedShield == null)
                {
                    var shield = (Shield)item;
                    this.EquippedShield = shield;
                    shield.Equipped = true;
                    Console.WriteLine($"{item.Name} Successfully Equipped!!!");
                }
                else
                {
                    Console.WriteLine("Equip Failed. You need to an Unequipped first");
                }
            }
        }

        public void UnequipItem(IItems item)
        {
            if (item == null)
            {
                Console.WriteLine("Sorry. Item not found!!!");
            }
            else
            {
                if (item is Weapon)
                {
                    var weapon = (Weapon)item;
                    this.EquippedWeapon = null;
                    weapon.Equipped = false;
                }
                else if (item is Armor)
                {
                    var armor = (Armor)item;
                    this.EquippedArmor = null;
                    armor.Equipped = false;
                }
                else if (item is Shield)
                {
                    var shield = (Shield)item;
                    this.EquippedShield = null;
                    shield.Equipped = false;
                }
                Console.WriteLine($"{item.Name} Successfully Unequipped!!!");
            }
        }

        public void UsePotion()
        {
            var maxHP = this.OriginalHP;
            var potions = (from item in this.ItemsBag
                           where item is Potion
                           select item).Cast<Potion>().ToList();

            if (this.CurrentHP == maxHP)
            {
                Console.WriteLine("No need to heal. HP is full");
            }
            else if (!potions.Any())
            {
                Console.WriteLine("Sorry. You don't have any healing potion!");
            }
            else
            {
                Console.WriteLine("Choose a potion to use:");

                foreach (var potion in potions)
                {
                    Console.WriteLine(potion.DisplayInfo());
                }

                Console.Write("Please type the potion id to use: ");

                var potionInput = Console.ReadLine();
                Potion potionToUse = null;

                foreach (var potion in potions)
                {
                    if (potion.ID.ToLower() == potionInput)
                    {
                        potionToUse = potion;
                    }
                }
                this.Heal(potionToUse);
            }
        }

        private void Heal(Potion potion)
        {
            if (potion == null)
            {
                Console.WriteLine("Sorry. Potion not found!!!");
            }
            else
            {
                if (potion.HealthRestored + this.CurrentHP > this.OriginalHP)
                {
                    this.CurrentHP = this.OriginalHP;
                }
                else
                {
                    this.CurrentHP += potion.HealthRestored;
                }
                this.ItemsBag.Remove(potion);
                Console.WriteLine("Health potion successfully used!!!");
            }
        }

        public void ShowAchievements()
        {
            var receivedAchievement = (from achievement in this.Achievements
                                       where achievement.Achieved == true
                                       select achievement).ToList();
            Console.WriteLine("********************");
            Console.WriteLine($"Achievement Points: {this.AchievementPoints} Point/s");
            if (!receivedAchievement.Any())
            {
                Console.WriteLine("Sorry. No achievement to show.");
            }
            else
            {
                Console.WriteLine("Achievements");
                foreach (var achievement in receivedAchievement)
                {
                    Console.WriteLine(achievement.ShowInfo());
                }
            }
            Console.WriteLine("********************");
        }

        public void CheckForAchievements()
        {
            var killedMonsters = (from monster in this.KilledMonsters
                                  orderby monster.Name
                                  select monster).ToList();

            var killedMonsterByGroup = (from monster in this.KilledMonsters
                                        group monster by monster.Name into monsters
                                        select new
                                        {
                                            MonstersCount = monsters.Count()
                                        }).ToList();
            var achievements = (from achievement in this.Achievements
                                where achievement.Achieved == false
                                select achievement).ToList();

            foreach (var achievement in achievements)
            {
                if ((killedMonsters.Count == 1 && achievement.ID == "achievement1") ||
                    (killedMonsters.Count == 3 && achievement.ID == "achievement2") ||
                    (killedMonsters.Count == 10 && achievement.ID == "achievement4") ||
                    (killedMonsterByGroup.Count == 5 && achievement.ID == "achievement3"))
                {
                    achievement.Achieved = true;
                    this.AchievementPoints += achievement.Points;

                    if(AchievementPoints == 1)
                    {
                        this.Rank = Rank.Apprentice;
                    }
                    if (AchievementPoints == 3)
                    {
                        this.Rank = Rank.Intermediate;
                    }
                    else if (AchievementPoints >= 6 && AchievementPoints <= 10)
                    {
                        this.Rank = Rank.Master;
                    }
                    else if (AchievementPoints > 10)
                    {
                        this.Rank = Rank.GrandMaster;
                    }

                    achievement.Date = DateTime.Now.ToString();
                    Console.WriteLine($"Congratulations.Achievement Received: {achievement.Name}");
                    Console.WriteLine($"Your new Rank is {this.Rank}!!!");
                }
            }
        }
    }
}
