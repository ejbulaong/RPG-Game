using System;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public string Difficulty { get; }
       
        public Monster(string name, string difficulty)
        {
            if (difficulty == "Hard")
            {
                Strength = 16;
                Defense = 6;
                OriginalHP = 22;
            }
            else if(difficulty == "Medium")
            {
                Strength = 15;
                Defense = 5;
                OriginalHP = 20;
            }
            else if (difficulty == "Easy")
            {
                Strength = 14;
                Defense = 4;
                OriginalHP = 18;
            }

            Name = name;
            CurrentHP = OriginalHP;


        }
    }
}