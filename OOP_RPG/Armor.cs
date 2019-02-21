namespace OOP_RPG
{
    public class Armor
    {
        public string ID { get; }
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }

        public Armor(string id, string name, int defense, int price)
        {
            ID = id;
            Name = name;
            Defense = defense;
            Price = price;
        }
    }
}