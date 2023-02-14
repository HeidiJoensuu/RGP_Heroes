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
        public Weapon() 
        {
            base.Slot = SlotType.Weapon;
        }
    }
}
