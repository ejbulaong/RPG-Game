namespace OOP_RPG
{
    public class Weapon
    {
        public string ID { get; }
        public string Name { get; }
        public int Strength { get; }
        public int Price { get; }

        public Weapon(string id, string name, int strength, int price)
        {
            ID= id;
            Name = name;
            Strength = strength;
            Price = price;
        }
    }
}