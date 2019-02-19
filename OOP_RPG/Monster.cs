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
<<<<<<< HEAD
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
=======

        //Requirement 1: make it required that Name, Strength, Defense, OriginalHP, and CurrentHP parameters are provided when creating monsters across our code base.
        public Monster(string name, int strength, int defense, int originalHP, int currentHP)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = originalHP;
            CurrentHP = currentHP;
>>>>>>> cd75714f82f2ee9368f67590b3f64caa05b2e6fe
        }
    }
}