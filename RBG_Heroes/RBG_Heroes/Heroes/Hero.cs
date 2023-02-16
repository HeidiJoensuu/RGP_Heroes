using RBG_Heroes.Exceptions;
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

        public Hero(string name, int level, int dexterity, int strength, int intelligence, List<Enum> weaponTypes, List<Enum> armorTypes) 
        {
            this.name = name;
            this.level = level;
            this.levelAttributes.Dexterity = dexterity;
            this.levelAttributes.Strength = strength;
            this.levelAttributes.Intelligence= intelligence;
            this.validWeaponTypes.AddRange(weaponTypes);
            this.validArmorTypes.AddRange(armorTypes);
        }

        public abstract void LevelUp();

        public void EquipArmor(Armor armor)
        {
            if (validArmorTypes.Contains(armor.ArmorType) && this.level >= armor.RequiredLevel)
            {
                equipment[armor.Slot] = armor;
                //Console.WriteLine(equipment[armor.Slot]);
            }
            else
            {
                throw new InvalidArmorException();
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (validWeaponTypes.Contains(weapon.WeaponType) && this.level >= weapon.RequiredLevel)
            {
                Console.WriteLine($"{string.Join(", ", weapon)}, wohooo");
                equipment[SlotType.Weapon] = weapon;
            }
            else
            {
                throw new InvalidWeaponException();
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
                    Console.WriteLine($"armor: {currentItem.Name}");
                    totalStrenght += currentItem.ArmorAttribute.Strength;
                    totalDexterity += currentItem.ArmorAttribute.Dexterity;
                    totalIntelligence += currentItem.ArmorAttribute.Intelligence;
                }
            }
            Console.WriteLine($"s: {totalStrenght} d: {totalDexterity} i: {totalIntelligence}");
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
