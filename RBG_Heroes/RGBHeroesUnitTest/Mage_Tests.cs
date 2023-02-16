using RBG_Heroes.Exceptions;
using RBG_Heroes.Heroes;
using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBHeroesUnitTest
{
    public class Mage_Tests
    {
        readonly Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);
        readonly Armor mailHelmet = new Armor("Common Mail Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
        readonly Armor plateLegs = new Armor("Common Mail Legs", 1, SlotType.Legs, ArmorType.Plate, 1, 3, 3);
        readonly Armor leatherArmor = new Armor("Common leather plate", 1, SlotType.Body, ArmorType.Leather, 0, 4, 2);
        readonly Armor clothArmor = new Armor("Common cloth robe", 1, SlotType.Body, ArmorType.Cloth, 4, 2, 1);
        readonly Weapon sword = new Weapon("Rusty Sword", 1, 15, WeaponType.Sword);
        readonly Weapon staff = new Weapon("Short Staff", 1, 15, WeaponType.Staff);
        readonly Weapon dagger = new Weapon("Rusty Dagger", 1, 10, WeaponType.Dagger);
        readonly Weapon wand = new Weapon("Normal Wand", 1, 10, WeaponType.Wand);
        readonly Weapon bow = new Weapon("Steppe Bow", 1, 13, WeaponType.Bow);
        readonly Weapon axe = new Weapon("Hammer", 1, 5, WeaponType.Axe);
        readonly Weapon hammer = new Weapon("Hammer", 1, 5, WeaponType.Hammer);

        [Fact]
        public void RogueCanBeCreated_IsCorrect()
        {
            //Arrage
            var mage = new Mage("Mike");
            var expected = new List<int> { 1, 8, 1, 1 };
            var actual = new List<int> { mage.Level, mage.TotalAttributes().Intelligence, mage.TotalAttributes().Strength, mage.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal("Mike", mage.Name);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUpWorks()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            var expected = new List<int> { 2, 13, 2, 2 };

            //Act
            mage.LevelUp();
            var actual = new List<int> { mage.Level, mage.TotalAttributes().Intelligence, mage.TotalAttributes().Strength, mage.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void CannotWearPlateArmor()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(plateArmor));
        }

        [Fact]
        public void CannotWearMailArmor()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            
            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(mailHelmet));
        }

        [Fact]
        public void CannotWearLeatherArmor()
        {
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(leatherArmor));

        }
        [Fact]
        public void CanWearClothArmor()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            var expected = new List<int> { 12, 2, 3 };

            //Act
            mage.EquipArmor(clothArmor);
            var actual = new List<int> { mage.TotalAttributes().Intelligence, mage.TotalAttributes().Strength, mage.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CannotWearArmorOverTheirLevel()
        {
            //Arrage
            Armor overSized = new Armor("Giant Armor", 5, SlotType.Body, ArmorType.Cloth, 0, 2, 3);
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(overSized));
        }

        [Fact]
        public void TotalAttributesAreCalculatedCorretly()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate", 1, SlotType.Body, ArmorType.Cloth, 0, 2, 3);
            Armor helmet = new Armor("Common Helmet", 1, SlotType.Head, ArmorType.Cloth, 0, 1, 4);
            Armor legs = new Armor("Common Legs", 1, SlotType.Legs, ArmorType.Cloth, 1, 3, 3);
            Mage mage = new Mage("Mike");
            var expected = new List<int> { 9, 11, 7 };

            //Act
            mage.EquipArmor(plateArmor);
            mage.EquipArmor(helmet);
            mage.EquipArmor(legs);
            var actual = new List<int> { mage.TotalAttributes().Intelligence, mage.TotalAttributes().Strength, mage.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArmorInSameSlotReplacesOldOne_CorrectAttributes()
        {
            //Arrage
            Armor armor = new Armor("Common Mail Plate", 1, SlotType.Body, ArmorType.Cloth, 0, 1, 4);
            Mage mage = new Mage("Mike");
            var expected = new List<int> { 8, 5, 2 };

            //Act
            mage.EquipArmor(clothArmor);
            mage.EquipArmor(armor);
            var actual = new List<int> { mage.TotalAttributes().Intelligence, mage.TotalAttributes().Strength, mage.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CannotWearBowWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(bow));
        }
        [Fact]
        public void CannotWearSwortWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(sword));
        }
        [Fact]
        public void CannotWearAxeWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(axe));
        }
        [Fact]
        public void CannotWearHammerWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(hammer));
        }
        [Fact]
        public void CannotWearDaggerWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(dagger));
        }

        [Fact]
        public void CannotWearWeaponOverTheirLevel()
        {
            //Arrage
            Weapon giantsSword = new Weapon("Giants Staff", 3, 1000, WeaponType.Staff);
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(giantsSword));
        }

        [Fact]
        public void DamageIsCorrect_NotWearingWeapon()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act & Assert
            Assert.Equal(1.08, mage.Damage());
        }

        [Fact]
        public void DamageIsCorrect_WearingStaff()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act
            mage.EquipWeapon(staff);

            //Assert
            Assert.Equal(16.2, mage.Damage());
        }
        [Fact]
        public void DamageIsCorrect_WearingWand()
        {
            //Arrage
            Mage mage = new Mage("Mike");

            //Act
            mage.EquipWeapon(wand);

            //Assert
            Assert.Equal(10.8, mage.Damage());
        }

        [Fact]
        public void WearedWeaponCanBeReplaced_DamageIsCorrect()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            Weapon ironStaff = new Weapon("Iron staff", 1, 25, WeaponType.Staff);

            //Act
            mage.EquipWeapon(wand);
            mage.EquipWeapon(ironStaff);

            //Assert
            Assert.Equal(27, mage.Damage());

        }

        [Fact]
        public void WearingWeaponAndArmourIncreacesDamage()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            Weapon ironStaff = new Weapon("Iron Sword", 1, 25, WeaponType.Staff);
            Armor elitePlate = new Armor("elitePlate", 1, SlotType.Body, ArmorType.Cloth, 100, 100, 100);
            Armor eliteHelmet = new Armor("eliteHelmet", 1, SlotType.Head, ArmorType.Cloth, 20, 20, 20);

            //Act
            mage.EquipWeapon(ironStaff);
            mage.EquipArmor(elitePlate);
            mage.EquipArmor(eliteHelmet);

            //Assert
            Assert.Equal(57, mage.Damage());

        }
        [Fact]
        public void DisplayISCorrect()
        {
            //Arrage
            Mage mage = new Mage("Mike");
            StringBuilder display = new StringBuilder();
            display.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
            "Mike", "Mage", 1, 1, 1, 8, 1.08);

            //Assert
            Assert.Equal(display.ToString(), mage.Display());
        }
    }
}
