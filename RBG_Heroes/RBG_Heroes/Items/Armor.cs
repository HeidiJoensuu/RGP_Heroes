using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    public class Armor: Item
    {
        public ArmorType ArmorType { get; set; }

        public Attributes.HeroAttributes ArmorAttribute = new Attributes.HeroAttributes();

        public Armor(string name, int requiredLevel, SlotType slotType, ArmorType armorType, int intelligence, int dexterity, int strength): base(name, requiredLevel, slotType)
        {
            this.ArmorType= armorType;
            this.ArmorAttribute.Dexterity = dexterity;
            this.ArmorAttribute.Strength = strength;
            this.ArmorAttribute.Intelligence = intelligence;
        }
    }
}
