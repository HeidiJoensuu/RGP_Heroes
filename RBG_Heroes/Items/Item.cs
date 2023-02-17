using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    /// <summary>
    /// Item abstact class
    /// </summary>
    public abstract class Item
    {
        protected string name;
        protected int requiredLevel;
        protected SlotType slot;

        public string Name { get => name;}
        public int RequiredLevel { get => requiredLevel;}
        public SlotType Slot { get; }

        /// <summary>
        /// Initializes new <see cref="Item"/> instances
        /// </summary>
        /// <param name="name">String - Item's name</param>
        /// <param name="requiredLevel">Integer - Required level that hero must have to wear this item.</param>
        /// <param name="slot">SlotType - Placement of the item</param>
        public Item(string name, int requiredLevel, SlotType slot)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            this.Slot = slot;
        }
    }
}
