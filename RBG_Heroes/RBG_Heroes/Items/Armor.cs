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

        public Armor() {}
    }
}
