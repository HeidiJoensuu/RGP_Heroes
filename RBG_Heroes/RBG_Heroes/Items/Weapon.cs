using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Items
{
    public class Weapon: Item
    {
        private int weaponDamage;

        public int WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public WeaponType WeaponType { get; set; }
        public Weapon(string name, int requiredLevel, int weaponDamage, WeaponType weaponType) : base(name, requiredLevel, SlotType.Weapon)
        {
            this.WeaponDamage = weaponDamage;
            this.WeaponType = weaponType;
        }
    }
}
