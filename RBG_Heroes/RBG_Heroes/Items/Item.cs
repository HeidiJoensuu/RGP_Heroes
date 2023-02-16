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

        public string Name { get => name;}
        public int RequiredLevel { get => requiredLevel;}
        public SlotType Slot { get; }

        public Item(string name, int requiredLevel, SlotType slot)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            this.Slot = slot;
        }
    }
}
