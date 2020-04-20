namespace DefaultNamespace
{
    public class Weapons : ItemClass
    {
        public string name;
        public string description;
        public string sprite;
        public int id;
        public int price;
        public int attack;
        public float attackspeed;
        public Weapons(string name, string description,  string sprite, int id, int price, int attack, float attackspeed) : base(name, description, id, price, sprite)
        {
            this.name = name;
            this.description = description;
            this.sprite = sprite;
            this.id = id;
            this.price = price;
            this.attack = attack;
            this.attackspeed = attackspeed;
        }
        
        
        
    }
}