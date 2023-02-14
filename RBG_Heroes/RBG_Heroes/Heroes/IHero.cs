using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    internal interface IHero
    {
        void LevelUp();
        void EquipArmor(Armor armor);
        void EquipWeapon(Weapon weapon);
        Attributes.HeroAttributes TotalAttributes();

        double Damage();

        string Display();
    }
}
