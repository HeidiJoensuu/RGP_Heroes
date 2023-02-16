using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Attributes
{
    public class HeroAttributes
    {
        private int strength;
        private int dexterity;
        private int intelligence;

        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }

        public HeroAttributes()
        {
        }
        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }
        

        public void IncreaseAttributes(int strength, int dexterity, int intelligence)
        {
            this.strength += strength;
            this.dexterity += dexterity;
            this.intelligence += intelligence;
        }
    }
}
