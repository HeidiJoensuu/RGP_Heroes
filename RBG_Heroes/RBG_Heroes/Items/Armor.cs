using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    /// <summary>
    /// Armor class. Extends <see cref="Item"/>.
    /// </summary>
    public class Armor: Item
    {
        public ArmorType ArmorType { get; set; }

        public Attributes.HeroAttributes ArmorAttribute;

        /// <summary>
        /// Creates new instance of <see cref="Armor"/>-item
        /// </summary>
        /// <param name="name"> Neme of the new item</param>
        /// <param name="requiredLevel">Integer - Required level that hero must have to wear this item.</param>
        /// <param name="slotType">SlotType - Placement of the item</param>
        /// <param name="armorType">ArmorType - Armor's type</param>
        /// <param name="intelligence"></param>
        /// <param name="dexterity"></param>
        /// <param name="strength"></param>
        public Armor(string name, int requiredLevel, SlotType slotType, ArmorType armorType, int intelligence, int dexterity, int strength): base(name, requiredLevel, slotType)
        {
            this.ArmorType= armorType;
            ArmorAttribute = new Attributes.HeroAttributes(strength, dexterity, intelligence);
        }
    }
}
