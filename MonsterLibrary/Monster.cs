using DungeonLibrary;

namespace MonsterLibrary
{
    public class Monster : Character
    {
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        private int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            
            set
            {
                if (value > MaxDamage || value < 1)
                {
                    _minDamage = 1;
                }
                
                else
                {
                    _minDamage = value;
                }
                ;
            }
        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
            
        

       
        public override string ToString()
        {
            return $@"
            ********* MONSTER *********
            {Name}
            Life: {Life} of {MaxLife}
            Damage: {MinDamage} to {MaxDamage}
            Block: {Block}
            Description:
            {Description}
            ";
        }

        public override int CalcDamage()
        {
            
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetMonster()
        {
            Monster Jeremy = new Monster("Jeremy", 30, 30, 70, 8, 8, 1, "The father of C# OOOH SPOOKY");
            Monster Danielle = new Monster("Danielle", 17, 25, 50, 10, 4, 1, "Master of CodeSharing");
            Monster Frank = new Monster("Frank", 10, 20, 65, 20, 15, 1, "Don't Let the name fool you, he's very very dangerous");
            Monster JakeTheDog = new Monster("Jake The Dog", 25, 25, 50, 20, 8, 2, "Super Stretchy Dog!!!");
            
         
            List<Monster> monsters = new List<Monster>()
            {
                Jeremy,Jeremy,Jeremy,
                Danielle,Danielle,
                Frank,Frank,Frank,Frank,Frank,
                JakeTheDog,JakeTheDog

            };
            return monsters[new Random().Next(monsters.Count)];
        }
    }
}