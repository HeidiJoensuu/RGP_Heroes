using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    public abstract class Item
    {
        protected string name;
        protected int requiredLevel;
        protected SlotType slot;

        public string Name { get => name; set => name = value; }
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
        public SlotType Slot { get; set; }
        public Item() { }

        public Item(string name, int requiredLevel, string slot)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
        }
    }
}
