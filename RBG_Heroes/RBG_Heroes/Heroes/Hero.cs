using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    public abstract class Hero : IHero
    {
        protected string name;
        protected int level = 1;
        protected Dictionary<SlotType, object?> equipment = new Dictionary<SlotType, object?>()
        {
            {SlotType.Head, null },
            {SlotType.Body, null },
            {SlotType.Weapon, null },
            {SlotType.Legs, null }
        };
        protected List<Enum> validWeaponTypes = new List<Enum>();
        protected List<Enum> validArmorTypes = new List<Enum>();

        public string Name { get => name; set => name = value; }
        public int Level { get => level; }

        public Attributes.HeroAttributes levelAttributes = new Attributes.HeroAttributes { Dexterity=1, Intelligence=1, Strength=1 };
       

        public Hero() { }

        public Hero(string name, int level) 
        {
            this.name = name;
            this.level = level;
            this.equipment = new Dictionary<SlotType, object?>();
            this.validWeaponTypes = new List<Enum>();
            this.validArmorTypes = new List<Enum>();
        }

        public abstract void LevelUp();

        public void EquipArmor(Armor armor)
        {
            if (validArmorTypes.Contains(armor.ArmorType) && this.level >= armor.RequiredLevel)
            {
                equipment[armor.Slot] = armor;
            }
            else
            {
                throw new Exception("InvalidArmorException ");
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (validWeaponTypes.Contains(weapon.WeaponType) && this.level >= weapon.RequiredLevel)
            {
                equipment[SlotType.Weapon] = weapon;
            }
            else
            {
                throw new Exception("InvalidWeaponException ");
            }
        }

        public Attributes.HeroAttributes TotalAttributes()
        {
            int totalStrenght = levelAttributes.Strength;
            int totalDexterity = levelAttributes.Dexterity;
            int totalIntelligence = levelAttributes.Intelligence;
            foreach (KeyValuePair<SlotType, object?> item in equipment) 
            {
                if (item.Value != null && item.Key != SlotType.Weapon)
                {
                    Armor currentItem = (Armor)item.Value;
                    totalStrenght += currentItem.ArmorAttribute.Strength;
                    totalDexterity += currentItem.ArmorAttribute.Dexterity;
                    totalIntelligence += currentItem.ArmorAttribute.Intelligence;
                }
            }
            Attributes.HeroAttributes totalAttributes = new Attributes.HeroAttributes
            {
                Dexterity = totalDexterity,
                Intelligence = totalIntelligence,
                Strength = totalStrenght
            };
            return totalAttributes;
        }

        public abstract double Damage();

        public abstract string Display();
        
    }
}
