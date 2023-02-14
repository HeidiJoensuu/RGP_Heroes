using RBG_Heroes.Attributes;
using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            base.levelAttributes.Dexterity = 2;
            base.levelAttributes.Strength = 5;
            base.validArmorTypes.AddRange(new List<Enum> { ArmorType.Mail, ArmorType.Plate });
            base.validWeaponTypes.AddRange(new List<Enum> { WeaponType.Sword, WeaponType.Axe, WeaponType.Hammer });
        }

        public override void LevelUp()
        {
            level++;
            levelAttributes.IncreaseAttributes(strength: 3, dexterity: 2, intelligence: 1);
        }

        public override double Damage()
        {
            int weaponDamage = 1;
            if (equipment[SlotType.Weapon] != null)
            {
                Weapon weapon = (Weapon)equipment[SlotType.Weapon];
                weaponDamage = weapon.WeaponDamage;
                
            }
            double heroDamage = weaponDamage * (1+ TotalAttributes().Strength/100);
            return heroDamage;

        }

        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}\n", Name);
            sb.AppendFormat("Class: {0}\n", "Warrior");
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
