using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; }
        private Hero Hero { get; }
        private Monster Enemy { get; }
        private Random Random { get; set; }
        public Fight(Hero game)
        {
            Hero = game;
            Monsters = new List<Monster>();
            Random = new Random();
            var monstersGroup1 = new List<string> { "Trunks", "Tenshinhan", "Kuririn", "Yamcha", "Son Goku" };
            var monstersGroup2 = new List<string> { "Android 18", "Son Goten", "Beerus", "Whis", "Son Gohan" };
            var monstersGroup3 = new List<string> { "Taopaipai", "Broly", "Bobbidi", "Dabra", "Vegeta" };
            var monstersGroup4 = new List<string> { "Oolong", "Pu'ar", "Chi-Chi", "Bulma", "Majin Boo" };
            var monstersGroup5 = new List<string> { "Gyū-Maō", "Lunch", "Chaozu", "Dr. Briefs", "Cell" };
            var monstersGroup6 = new List<string> { "Karin", "Yajirobe", "Mr. Popo", "Kami", "Freeza" };
            var monstersGroup7 = new List<string> { "Dende", "Android 17", "Mr. Satan", "Videl", "Piccolo" };
            var monstersGroups = new List<List<string>> { monstersGroup1, monstersGroup2, monstersGroup3, monstersGroup4, monstersGroup5, monstersGroup6, monstersGroup7 };

            var daysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var difficulty = new List<string> { "Easy", "Easy", "Medium", "Medium", "Hard" };

            for (var x = 0; x <= 6; x++)
            {//loop to the daysOfWeek and compare the day today to the days on the list
                if (DateTime.Today.DayOfWeek.ToString() == daysOfWeek[x])
                {//using the index of the day in daysOfWeek, select the group of monsters in the monstersGroup
                    foreach (var name in monstersGroups[x])
                    { //loop that create the monsters and assigning their names and difficulty levels
                        AddMonster(name, difficulty[monstersGroups[x].IndexOf(name)]);
                    }
                }
            }
            //choose random enemy from the Monsters list
            Enemy = Monsters[Random.Next(0, 5)];
        }

        private void AddMonster(string name, string difficulty)
        {
            var monster = new Monster(name, difficulty);

            Monsters.Add(monster);
        }

        public void Start()
        {
            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine("You've encountered " + Enemy.Name + "! " + Enemy.Strength + " Strength/" + Enemy.Defense + " Defense/" +
                Enemy.CurrentHP + " HP/" + Enemy.Difficulty + " Level. What will you do?");

                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Heal");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
                else if (input == "2")
                {
                    Hero.UsePotion();
                }
            }
        }

       

        private void HeroTurn()
        {
            int finalDamage;
            int baseDamage;

            if (Hero.EquippedWeapon == null)
            {
                baseDamage = Hero.Strength - Enemy.Defense;
            }
            else
            {
                baseDamage = Hero.Strength + Hero.EquippedWeapon.Strength - Enemy.Defense;
            }

            if (baseDamage <= 0)
            {
                finalDamage = 1;
                Enemy.CurrentHP -= finalDamage;
            }
            else
            {
                finalDamage = Random.Next(baseDamage - (baseDamage / 2), (baseDamage + (baseDamage / 2) + 1));
                Enemy.CurrentHP -= finalDamage;
            }

            Console.WriteLine("You did " + finalDamage + " damage!");

            if (Enemy.CurrentHP <= 0)
            {
                Win();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void MonsterTurn()
        {
            int finalDamage;
            int baseDamage;

            if (Hero.EquippedArmor != null && Hero.EquippedShield != null)
            {
                baseDamage = Enemy.Strength - (Hero.Defense + Hero.EquippedArmor.Defense + Hero.EquippedShield.Defense);
            }
            else if (Hero.EquippedArmor != null && Hero.EquippedShield == null)
            {
                baseDamage = Enemy.Strength - (Hero.Defense + Hero.EquippedArmor.Defense);
            }
            else if (Hero.EquippedArmor == null && Hero.EquippedShield != null)
            {
                baseDamage = Enemy.Strength - (Hero.Defense + Hero.EquippedShield.Defense);
            }
            else
            {
                baseDamage = Enemy.Strength - Hero.Defense;
            }

            if (baseDamage <= 0)
            {
                finalDamage = 1;
                Hero.CurrentHP -= finalDamage;
            }
            else
            {
                finalDamage = Random.Next(baseDamage - (baseDamage / 2), (baseDamage + (baseDamage / 2) + 1));
                Hero.CurrentHP -= finalDamage;
            }

            Console.WriteLine(Enemy.Name + " does " + finalDamage + " damage!");

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win()
        {
            Hero.Golds += Enemy.GoldsDrop;
            Console.WriteLine($"{Enemy.Name} has been defeated! You win the battle! {Enemy.GoldsDrop} Golds received");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}