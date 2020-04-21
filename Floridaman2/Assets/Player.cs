namespace DefaultNamespace
{
    public class Player : EntityClass
    {
        public string name;
        public (int,int) hp; // premier int = max hp, deuxième = current hp
        public int lvl; // pas sûr que cette variable devienne utile
        private ItemClass[,] inventory;
        private bool dead;
        public int attack;
        DataBase data = new DataBase();
        
        public Player(int lvl, int attack, (int,int) hp, string name) : base(lvl,  attack,  hp, name)
        {
            this.name = name;
            this.hp = (500, 500);
            this.lvl = 1;
            this.inventory = new ItemClass[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    inventory[i, k] = data.items[0];
                }
            }
            
        }
    }
}