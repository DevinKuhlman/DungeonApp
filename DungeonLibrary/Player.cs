using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{   
    public sealed class Player : Character 
    {
        private Race _characterRace;
        //prop
        public Race CharacterRace
        {
            get { return _characterRace; }
            set { _characterRace = value; }
        }     
        private Weapon _equippedWeapon;
        public Weapon EquippedWeapon
        {
            
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }
        public Player(string name, int hitChance, int block, int maxLife, int life, Race characterRace, Weapon equippedWeapon)
            : base(name, hitChance, block, maxLife, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            switch (CharacterRace)
            {
                case Race.Orc:
                    MaxLife += 10;
                    Life += 10;                    
                    break;
                case Race.Human:
                    HitChance += (HitChance / 20); 
                    break;
                case Race.Elf:
                    Block += 3;
                    HitChance += 5;
                    break;
                case Race.Dwarf:
                    MaxLife += 5;
                    Life += 5;
                    Block += 5;
                    break;
            }            
        }
        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                default:
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" + description;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
        public override int CalcDamage()
        {
           
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;            
        }
    }
}
