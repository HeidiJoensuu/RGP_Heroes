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
    public class RangerTests
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
            var ranger = new Ranger("Mike the Brave");
            var expected = new List<int> { 1, 1, 1, 7 };
            var actual = new List<int> { ranger.Level, ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal("Mike the Brave", ranger.Name);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUpWorks()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");
            var expected = new List<int> { 2, 2, 2, 12 };

            //Act
            ranger.LevelUp();
            var actual = new List<int> { ranger.Level, ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void CannotWearPlateArmor()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(plateArmor));
        }

        [Fact]
        public void CanWearMailArmor()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");
            var expected = new List<int> { 1, 5, 8 };

            //Act
            ranger.EquipArmor(mailHelmet);
            var actual = new List<int> { ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanWearLeatherArmor()
        {
            Ranger ranger = new Ranger("Mike");
            var expected = new List<int> { 1, 5, 8 };

            //Act
            ranger.EquipArmor(mailHelmet);
            var actual = new List<int> { ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

            //Act & Assert

        }
        [Fact]
        public void CannotWearClothArmor()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(clothArmor));
        }

        [Fact]
        public void CannotWearArmorOverTheirLevel()
        {
            //Arrage
            Armor overSized = new Armor("Giant Armor", 5, SlotType.Body, ArmorType.Mail, 0, 2, 3);
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(overSized));
        }

        [Fact]
        public void TotalAttributesAreCalculatedCorretly()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate", 1, SlotType.Body, ArmorType.Leather, 0, 2, 3);
            Armor mailHelmet = new Armor("Common Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
            Armor plateLegs = new Armor("Common Legs", 1, SlotType.Legs, ArmorType.Leather, 1, 3, 3);
            Ranger ranger = new Ranger("Mike");
            var expected = new List<int> { 2, 11, 13 };

            //Act
            ranger.EquipArmor(plateArmor);
            ranger.EquipArmor(mailHelmet);
            ranger.EquipArmor(plateLegs);
            var actual = new List<int> { ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ArmorInSameSlotReplacesOldOne_CorrectAttributes()
        {
            //Arrage
            Armor mailArmor = new Armor("Common Mail Plate", 1, SlotType.Body, ArmorType.Mail, 0, 1, 4);
            Ranger ranger = new Ranger("Mike");
            var expected = new List<int> { 1, 5, 8 };

            //Act
            ranger.EquipArmor(leatherArmor);
            ranger.EquipArmor(mailArmor);
            var actual = new List<int> { ranger.TotalAttributes().Intelligence, ranger.TotalAttributes().Strength, ranger.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CannotWearDaggerWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(dagger));
        }
        [Fact]
        public void CannotWearStaffWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(staff));
        }
        [Fact]
        public void CannotWearAxeWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(axe));
        }
        [Fact]
        public void CannotWearSwordWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(sword));
        }
        [Fact]
        public void CannotWearHammerWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(hammer));
        }
        [Fact]
        public void CannotWearWandWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(wand));
        }

        [Fact]
        public void CannotWearWeaponOverTheirLevel()
        {
            //Arrage
            Weapon giantsBow = new Weapon("Giants Bow", 3, 1000, WeaponType.Bow);
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(giantsBow));
        }


        [Fact]
        public void DamageIsCorrect_NotWearingWeapon()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act & Assert
            Assert.Equal(1.07, ranger.Damage());
        }

        [Fact]
        public void DamageIsCorrect_WearingBow()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");

            //Act
            ranger.EquipWeapon(bow);

            //Assert
            Assert.Equal(13.91, ranger.Damage());
        }

        [Fact]
        public void WearedWeaponCanBeReplaced_DamageIsCorrect()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");
            Weapon ironBow = new Weapon("Iron Bow", 1, 25, WeaponType.Bow);

            //Act
            ranger.EquipWeapon(bow);
            ranger.EquipWeapon(ironBow);

            //Assert
            Assert.Equal(26.75, ranger.Damage());

        }

        [Fact]
        public void WearingWeaponAndArmourIncreacesDamage()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");
            Weapon ironBow = new Weapon("Iron Bow", 1, 25, WeaponType.Bow);
            Armor elitePlate = new Armor("elitePlate", 1, SlotType.Body, ArmorType.Mail, 0, 100, 100);
            Armor eliteHelmet = new Armor("eliteHelmet", 1, SlotType.Head, ArmorType.Mail, 0, 20, 20);

            //Act
            ranger.EquipWeapon(ironBow);
            ranger.EquipArmor(elitePlate);
            ranger.EquipArmor(eliteHelmet);

            //Assert
            Assert.Equal(56.75, ranger.Damage());

        }
        [Fact]
        public void DisplayISCorrect()
        {
            //Arrage
            Ranger ranger = new Ranger("Mike");
            StringBuilder display = new StringBuilder();
            display.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
            "Mike", "Ranger", 1, 1, 7, 1, 1.07);

            //Assert
            Assert.Equal(display.ToString(), ranger.Display());
        }
    }
}
