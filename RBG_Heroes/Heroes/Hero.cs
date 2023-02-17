using RBG_Heroes.Exceptions;
using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Heroes
{
    /// <summary>
    /// Hero abstract class. Implements IHero interface.
    /// </summary>
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

        public Attributes.HeroAttributes levelAttributes = new Attributes.HeroAttributes(1,1,1);

        /// <summary>
        /// Initializes new <see cref="Hero"/> instance.
        /// </summary>
        /// <param name="name">Hero's new name</param>
        /// <param name="level">Starting level </param>
        /// <param name="dexterity">Starting dexterity skill</param>
        /// <param name="strength">Starting strength skill</param>
        /// <param name="intelligence">Starting intelligence skill</param>
        /// <param name="weaponTypes">Hero's weapon type that they can wear</param>
        /// <param name="armorTypes"> Hero's armor types that they can wear</param>
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

        /// <summary>
        /// Method for leveling up the hero.
        /// </summary>
        public abstract void LevelUp();

        /// <summary>
        /// Method for wearing new armor
        /// </summary>
        /// <param name="armor">Armor to wear.</param>
        /// <exception cref="InvalidArmorException"></exception>
        public void EquipArmor(Armor armor)
        {
            if (validArmorTypes.Contains(armor.ArmorType) && this.level >= armor.RequiredLevel)
            {
                equipment[armor.Slot] = armor;
            }
            else
            {
                throw new InvalidArmorException();
            }
        }

        /// <summary>
        /// Method for wearing weapon.
        /// </summary>
        /// <param name="weapon">Weapon to wear</param>
        /// <exception cref="InvalidWeaponException"></exception>
        public void EquipWeapon(Weapon weapon)
        {
            if (validWeaponTypes.Contains(weapon.WeaponType) && this.level >= weapon.RequiredLevel)
            {
                equipment[SlotType.Weapon] = weapon;
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        /// <summary>
        /// Counts all skills together and summaries new <see cref="Attributes.HeroAttributes" from them./>
        /// </summary>
        /// <returns> <see cref="Attributes.HeroAttributes"/></returns>
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
            Attributes.HeroAttributes totalAttributes = new Attributes.HeroAttributes(totalStrenght, totalDexterity, totalIntelligence);
            return totalAttributes;
        }

        /// <summary>
        /// Method for counting hero's damage.
        /// </summary>
        /// <returns> Integer - Hero's damage</returns>
        public abstract double Damage();

        /// <summary>
        /// Combines info about the hero and summaries then into one string output.
        /// </summary>
        /// <returns> String - Display of the hero</returns>
        public abstract string Display();
        
    }
}
