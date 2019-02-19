namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        //Requirement 1: make it required that Name, Strength, Defense, OriginalHP, and CurrentHP parameters are provided when creating monsters across our code base.
        public Monster(string name, int strength, int defense, int originalHP, int currentHP)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = originalHP;
            CurrentHP = currentHP;
        }
    }
}