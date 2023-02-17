using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    /// <summary>
    /// Weapon class. Extends <see cref="Item"/>.
    /// </summary>
    public class Weapon: Item
    {
        private int weaponDamage;

        public int WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Weapon"/>-item
        /// </summary>
        /// <param name="name">String - Item's name</param>
        /// <param name="requiredLevel">Integer - Required level that hero must have to wear this item.</param>
        /// <param name="weaponDamage">Integer - Weapon's damage</param>
        /// <param name="weaponType">WeaponType - Weapon's type</param>
        public Weapon(string name, int requiredLevel, int weaponDamage, WeaponType weaponType) : base(name, requiredLevel, SlotType.Weapon)
        {
            this.WeaponDamage = weaponDamage;
            this.WeaponType = weaponType;
        }
    }
}
