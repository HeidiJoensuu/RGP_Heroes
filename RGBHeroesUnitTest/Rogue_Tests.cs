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
    public class Rogue_Tests
    {
        readonly Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);
        readonly Armor mailHelmet = new Armor("Common Mail Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
        readonly Armor plateLegs = new Armor("Common Mail Legs", 1, SlotType.Legs, ArmorType.Plate, 1, 3, 3);
        readonly Armor leatherArmor = new Armor("Common leather plate", 1, SlotType.Body, ArmorType.Leather, 0, 4, 2);
        readonly Armor clothArmor = new Armor("Common cloth robe", 1, SlotType.Body, ArmorType.Cloth, 4, 2, 1);
        readonly Weapon sword = new Weapon("Rusty Sword", 1, 15, WeaponType.Sword);
        readonly Weapon staff = new Weapon("Short Staff", 1, 15,WeaponType.Staff);
        readonly Weapon dagger = new Weapon("Rusty Dagger", 1, 10, WeaponType.Dagger);
        readonly Weapon wand = new Weapon("Normal Wand", 1, 10, WeaponType.Wand);
        readonly Weapon bow = new Weapon("Steppe Bow", 1, 13, WeaponType.Bow);
        readonly Weapon axe = new Weapon("Hammer", 1, 5, WeaponType.Axe);
        readonly Weapon hammer = new Weapon("Hammer", 1, 5, WeaponType.Hammer);

        [Fact]
        public void RogueCanBeCreated_IsCorrect()
        {
            //Arrage
            var rogue = new Rogue("Mike the Brave");
            var expected = new List<int> { 1, 1, 2, 6 };
            var actual = new List<int> { rogue.Level, rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal("Mike the Brave", rogue.Name);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void LevelUpWorks()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");
            var expected = new List<int> { 2, 2, 3, 10 };

            //Act
            rogue.LevelUp();
            var actual = new List<int> { rogue.Level, rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

        }
        
        [Fact]
        public void CannotWearPlateArmor()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(plateArmor));
        }

        [Fact]
        public void CanWearMailArmor()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");
            var expected = new List<int> { 1, 6, 7 };

            //Act
            rogue.EquipArmor(mailHelmet);
            var actual = new List<int> { rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanWearLeatherArmor()
        {
            Rogue rogue = new Rogue("Mike");
            var expected = new List<int> { 1, 6, 7 };

            //Act
            rogue.EquipArmor(mailHelmet);
            var actual = new List<int> { rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

            //Act & Assert
            
        }
        [Fact]
        public void CannotWearClothArmor()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(clothArmor));
        }

        [Fact]
        public void CannotWearArmorOverTheirLevel()
        {
            //Arrage
            Armor overSized = new Armor("Giant Armor", 5, SlotType.Body, ArmorType.Mail, 0, 2, 3);
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(overSized));
        }

        [Fact]
        public void TotalAttributesAreCalculatedCorretly()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate", 1, SlotType.Body, ArmorType.Leather, 0, 2, 3);
            Armor mailHelmet = new Armor("Common Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
            Armor plateLegs = new Armor("Common Legs", 1, SlotType.Legs, ArmorType.Leather, 1, 3, 3);
            Rogue rogue = new Rogue("Mike");
            var expected = new List<int> { 2, 12, 12 };

            //Act
            rogue.EquipArmor(plateArmor);
            rogue.EquipArmor(mailHelmet);
            rogue.EquipArmor(plateLegs);
            var actual = new List<int> { rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ArmorInSameSlotReplacesOldOne_CorrectAttributes()
        {
            //Arrage
            Armor mailArmor = new Armor("Common Mail Plate", 1, SlotType.Body, ArmorType.Mail, 0, 1, 4);
            Rogue rogue = new Rogue("Mike");
            var expected = new List<int> { 1, 6, 7 };

            //Act
            rogue.EquipArmor(leatherArmor);
            rogue.EquipArmor(mailArmor);
            var actual = new List<int> { rogue.TotalAttributes().Intelligence, rogue.TotalAttributes().Strength, rogue.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CannotWearBowWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(bow));
        }
        [Fact]
        public void CannotWearStaffWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(staff));
        }
        [Fact]
        public void CannotWearAxeWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(axe));
        }
        [Fact]
        public void CannotWearHammerWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(hammer));
        }
        [Fact]
        public void CannotWearWandWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(wand));
        }

        [Fact]
        public void CannotWearWeaponOverTheirLevel()
        {
            //Arrage
            Weapon giantsSword = new Weapon("Giants Sword", 3, 1000, WeaponType.Sword);
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(giantsSword));
        }


        [Fact]
        public void DamageIsCorrect_NotWearingWeapon()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act & Assert
            Assert.Equal(1.06, rogue.Damage());
        }

        [Fact]
        public void DamageIsCorrect_WearingSword()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act
            rogue.EquipWeapon(sword);

            //Assert
            Assert.Equal(15.9, rogue.Damage());
        }
        [Fact]
        public void DamageIsCorrect_WearingDagger()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");

            //Act
            rogue.EquipWeapon(dagger);

            //Assert
            Assert.Equal(10.6, rogue.Damage());
        }

        [Fact]
        public void WearedWeaponCanBeReplaced_DamageIsCorrect()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");
            Weapon ironSword = new Weapon("Iron Sword", 1, 25, WeaponType.Sword);

            //Act
            rogue.EquipWeapon(sword);
            rogue.EquipWeapon(ironSword);

            //Assert
            Assert.Equal(26.5, rogue.Damage());

        }
        
        [Fact]
        public void WearingWeaponAndArmourIncreacesDamage()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");
            Weapon ironSword = new Weapon("Iron Sword", 1, 25, WeaponType.Sword);
            Armor elitePlate = new Armor("elitePlate", 1, SlotType.Body, ArmorType.Mail, 0, 100, 100);
            Armor eliteHelmet = new Armor("eliteHelmet", 1, SlotType.Head, ArmorType.Mail, 0, 20, 20);

            //Act
            rogue.EquipWeapon(ironSword);
            rogue.EquipArmor(elitePlate);
            rogue.EquipArmor(eliteHelmet);

            //Assert
            Assert.Equal(56.5, rogue.Damage());

        }
        [Fact]
        public void DisplayISCorrect()
        {
            //Arrage
            Rogue rogue = new Rogue("Mike");
            StringBuilder display = new StringBuilder();
            display.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
            "Mike", "Rogue", 1, 2, 6, 1, 1.06);

            //Assert
            Assert.Equal(display.ToString(), rogue.Display());
        }
    }
}
