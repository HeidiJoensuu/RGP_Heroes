using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    /// <summary>
    /// Rogue class. Extends <see cref="Item"/>
    /// </summary>
    public class Rogue : Hero
    {
        /// <summary>
        /// Creates new instance of <see cref="Rogue"/>-hero
        /// </summary>
        /// <param name="name">Hero's new name</param>
        public Rogue(string name): base(name, 1,6,2,1, new List<Enum> { WeaponType.Sword, WeaponType.Dagger }, new List<Enum> { ArmorType.Mail, ArmorType.Leather }) {}

        public override void LevelUp()
        {
            level++;
            levelAttributes.IncreaseAttributes(strength: 1, dexterity: 4, intelligence: 1);
        }

        public override double Damage()
        {
            int weaponDamage = 1;
            if (equipment.ContainsKey(SlotType.Weapon) && equipment[SlotType.Weapon] != null)
            {
                Weapon weapon = (Weapon)equipment[SlotType.Weapon];
                weaponDamage = weapon.WeaponDamage;
            }
            double heroDamage = Math.Round(weaponDamage * (double)(1 + (double)TotalAttributes().Dexterity / 100),2);
            return heroDamage;

        }

        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
                Name, "Rogue", Level, TotalAttributes().Strength, TotalAttributes().Dexterity, TotalAttributes().Intelligence, Damage());
            return sb.ToString();
        }
    }
}
