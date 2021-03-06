using System;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public Difficulty Difficulty { get; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int GoldsDrop { get; set; }

        public Monster(string name, Difficulty difficulty)
        {
            Random rnd = new Random();
            //automatically assign the value of Strength, Defense, and OriginalHP depending on the difficulty level
            if (difficulty == Difficulty.Hard)
            {
                Strength = rnd.Next(16, 19);
                Defense = rnd.Next(7, 10);
                OriginalHP = rnd.Next(21, 25);
                GoldsDrop = rnd.Next(21, 31);
            }
            else if (difficulty == Difficulty.Medium)
            {
                Strength = rnd.Next(13, 16);
                Defense = rnd.Next(5, 7);
                OriginalHP = rnd.Next(18, 21);
                GoldsDrop = rnd.Next(11, 21);
            }
            else if (difficulty == Difficulty.Easy)
            {
                Strength = rnd.Next(10, 13);
                Defense = rnd.Next(3, 5);
                OriginalHP = rnd.Next(15, 18);
                GoldsDrop = rnd.Next(1, 11);
            }

            Name = name;
            CurrentHP = OriginalHP;
            Difficulty = difficulty;
        }
    }
}