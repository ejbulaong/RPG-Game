using System;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public string Difficulty { get; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(string name, string difficulty)
        {
            Random rnd = new Random();
            //automatically assign the value of Strength, Defense, and OriginalHP depending on the difficulty level
            if (difficulty == "Hard")
            {
                Strength = rnd.Next(16, 19);
                Defense = rnd.Next(7, 10);
                OriginalHP = rnd.Next(21, 25);
            }
            else if (difficulty == "Medium")
            {
                Strength = rnd.Next(13, 16);
                Defense = rnd.Next(5, 7);
                OriginalHP = rnd.Next(18, 21);
            }
            else if (difficulty == "Easy")
            {
                Strength = rnd.Next(10, 13);
                Defense = rnd.Next(3, 5);
                OriginalHP = rnd.Next(15, 18);
            }

            Name = name;
            CurrentHP = OriginalHP;
            Difficulty = difficulty;
        }
    }
}