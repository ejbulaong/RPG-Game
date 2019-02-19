using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; }
        private Hero Hero { get; }

        public Fight(Hero game)
        {
            Hero = game;
            Monsters = new List<Monster>();

            var monstersGroup1 = new List<string> { "Trunks", "Tenshinhan", "Kuririn", "Yamcha", "Son Goku" };
            var monstersGroup2 = new List<string> { "Android 18", "Son Goten", "Beerus", "Whis", "Son Gohan" };
            var monstersGroup3 = new List<string> { "Taopaipai", "Broly", "Bobbidi", "Dabra", "Vegeta" };
            var monstersGroup4 = new List<string> { "Oolong", "Pu'ar", "Chi-Chi", "Bulma", "Majin Boo" };
            var monstersGroup5 = new List<string> { "Gyū-Maō", "Lunch", "Chaozu", "Dr. Briefs", "Cell" };
            var monstersGroup6 = new List<string> { "Karin", "Yajirobe", "Mr. Popo", "Kami", "Freeza" };
            var monstersGroup7 = new List<string> { "Dende", "Android 17", "Mr. Satan", "Videl", "Piccolo" };

<<<<<<< HEAD
            var daysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var monstersGroups = new List<List<string>> { monstersGroup1, monstersGroup2, monstersGroup3, monstersGroup4, monstersGroup5, monstersGroup6, monstersGroup7 };
            var difficulty = new List<string> { "Easy", "Easy", "Medium", "Medium", "Hard" };

            for (var x = 0; x <= 6; x++)
            {
                if(DateTime.Today.DayOfWeek.ToString() == daysOfWeek[x])
                {
                    foreach(var name in monstersGroups[x])
                    {
                        AddMonster(name, difficulty[monstersGroups[x].IndexOf(name)]);
                    }
                }
            }
        }

        private void AddMonster(string name, string difficulty)
        {
            var monster = new Monster(name, difficulty);
=======
        private void AddMonster(string name, int strength, int defense, int hp)
        {
            //Requirement 1: make it required that Name, Strength, Defense, OriginalHP, and CurrentHP parameters are provided when creating monsters across our code base.
            var monster = new Monster(name, strength, defense, hp, hp);
>>>>>>> cd75714f82f2ee9368f67590b3f64caa05b2e6fe
            Monsters.Add(monster);
        }

        public void Start()
        {
            Random rnd = new Random();
            var enemy = Monsters[rnd.Next(0, 4)];

            while (enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" +
                enemy.CurrentHP + " HP. What will you do?");

                Console.WriteLine("1. Fight");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn(enemy);
                }
            }
        }

        private void HeroTurn(Monster monster)
        {
            var enemy = monster;
            var compare = Hero.Strength - enemy.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                enemy.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                enemy.CurrentHP -= damage;
            }

            Console.WriteLine("You did " + damage + " damage!");

            if (enemy.CurrentHP <= 0)
            {
                Win(enemy);
            }
            else
            {
                MonsterTurn(enemy);
            }
        }

        private void MonsterTurn(Monster monster)
        {
            var enemy = monster;
            int damage;
            var compare = enemy.Strength - Hero.Defense;

            if (compare <= 0)
            {
                damage = 1;
                Hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                Hero.CurrentHP -= damage;
            }

            Console.WriteLine(enemy.Name + " does " + damage + " damage!");

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win(Monster monster)
        {
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}