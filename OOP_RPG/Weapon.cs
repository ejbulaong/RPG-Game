namespace OOP_RPG
{
    public class Weapon : IItems
    {
        public string ID { get; }
        public string Name { get; }
        public int Strength { get; }
        public int Price { get; }
        public bool Equipped { get; set; }

        public Weapon(string id, string name, int strength, int price)
        {
            ID = id;
            Name = name;
            Strength = strength;
            Price = price;
            Equipped = false;
        }

        public string DisplayInfo()
        {
            return $"ID: {this.ID} Name: {this.Name} Strength: {this.Strength} Price: {this.Price} Golds";
        }
    }
}