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
            //can't be more than maxdamage, can't be less than 1
            set
            {
                if (value > MaxDamage || value < 1)
                {
                    _minDamage = 1;
                }
                //else if (value < 1)
                //{
                //    _minDamage = 1;
                //}
                else
                {
                    _minDamage = value;
                }
                //_minDamage = value > MaxDamage || value < 1 ? 1 : value;
            }//end set
        }//end MinDamage

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            //Property = parameter
        }//end FQ CTOR
        //default constructor for a default monster
        public Monster()
        {
            //Character Fields
            Name = "Spencer's Mustache";
            MaxLife = 25;//MaxLife first!
            Life = 25;
            HitChance = 30;
            Block = 8;
            //Monster Fields
            MaxDamage = 10;//MaxDamage First!
            MinDamage = 2;
            Description = @"Out of the fog, a mysterious mustache makes a baby cry...
                                                                                                                                         
                                                                                        
          ██████        ██████████  ██████████        ██████                  
        ████        ██████████████████████████████        ████                
        ████    ██████████████████████████████████████    ████                
        ██████████████████████████████████████████████████████                
          ████████████████████████  ████████████████████████                  
            ██████████████████          ██████████████████                    
                ████████                      ████████                        
                                                                              

";
        }//End Default CTOR

        //Methods
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
            //return base.CalcDamage();//returns 0, not what we want.
            return new Random().Next(MinDamage, MaxDamage + 1);// + 1 because it's exclusive
        }//end CalcDamage()

        public static Monster GetMonster()
        {
            Monster mustache = new Monster();
            Monster vampire = new Monster("Jeremy", 30, 30, 70, 8, 8, 1, "The father of C# OOOH SPOOKY");
            Monster turtle = new Monster("Danielle", 17, 25, 50, 10, 4, 1, "Master of CodeSharing");
            Monster dragon = new Monster("Frank", 10, 20, 65, 20, 15, 1, "Don't Let the name fool you, he's very very dangerous");
            Monster rabbit = new Monster("Jake The Dog", 25, 25, 50, 20, 8, 2, "Super Stretchy Dog!!!");
         
            List<Monster> monsters = new List<Monster>()
            {
        
                
            };
            
            return monsters[new Random().Next(monsters.Count)];
        }
    }
}