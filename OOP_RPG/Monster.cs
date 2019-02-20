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

            if (difficulty == "Hard")
            {
                Difficulty = "Hard";
                Strength = rnd.Next(16, 18);
                Defense = rnd.Next(7, 8);
                OriginalHP = rnd.Next(22, 25);
            }
            else if(difficulty == "Medium")
            {
                Difficulty = "Medium";
                Strength = rnd.Next(13, 15);
                Defense = rnd.Next(5, 6);
                OriginalHP = rnd.Next(19, 21);
            }
            else if (difficulty == "Easy")
            {
                Difficulty = "Easy";
                Strength = rnd.Next(10, 12);
                Defense = rnd.Next(2, 4);
                OriginalHP = rnd.Next(15, 18);
            }

            Name = name;
            CurrentHP = OriginalHP;
        }
    }
}