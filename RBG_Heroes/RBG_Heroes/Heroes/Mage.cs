using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    public class Mage : Hero
    {
        public Mage()
        {
            base.levelAttributes.Intelligence= 6;
            base.validArmorTypes.AddRange(new List<Enum> { ArmorType.Cloth});
            base.validWeaponTypes.AddRange(new List<Enum> { WeaponType.Staff, WeaponType.Wand });
        }

        public override void LevelUp()
        {
            level++;
            levelAttributes.IncreaseAttributes(strength: 5, dexterity: 1, intelligence: 1);
        }

        public override double Damage()
        {
            int weaponDamage = 1;
            if (equipment[SlotType.Weapon] != null)
            {
                Weapon weapon = (Weapon)equipment[SlotType.Weapon];
                weaponDamage = weapon.WeaponDamage;

            }
            double heroDamage = weaponDamage * (1 + TotalAttributes().Intelligence / 100);
            return heroDamage;

        }

        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}\n", Name);
            sb.AppendFormat("Class: {0}\n", "Mage");
            sb.AppendFormat("Level: {0}\n", Level);
            sb.AppendFormat("Total strength: {0}\n", TotalAttributes().Strength);
            sb.AppendFormat("Total dexterity: {0}\n", TotalAttributes().Dexterity);
            sb.AppendFormat("Total intelligence: {0}\n", TotalAttributes().Intelligence);
            sb.AppendFormat("Damage: {0}\n", Damage());
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
