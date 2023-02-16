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
        public Mage(string name) : base(name, 1, 1, 1, 8, new List<Enum> { WeaponType.Staff, WeaponType.Wand }, new List<Enum> { ArmorType.Cloth }){}

        public override void LevelUp()
        {
            level++;
            levelAttributes.IncreaseAttributes(strength: 1, dexterity: 1, intelligence: 5);
        }

        public override double Damage()
        {
            int weaponDamage = 1;
            if (equipment.ContainsKey(SlotType.Weapon) && equipment[SlotType.Weapon] != null)
            {
                Weapon weapon = (Weapon)equipment[SlotType.Weapon];
                weaponDamage = weapon.WeaponDamage;
            }
            double heroDamage = Math.Round(weaponDamage * (double)(1 + (double)TotalAttributes().Intelligence / 100),2);
            return heroDamage;

        }

        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
                Name, "Mage", Level, TotalAttributes().Strength, TotalAttributes().Dexterity, TotalAttributes().Intelligence, Damage());
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
