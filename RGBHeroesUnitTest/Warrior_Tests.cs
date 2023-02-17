using RBG_Heroes.Exceptions;
using RBG_Heroes.Heroes;
using RBG_Heroes.Items;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace RGBHeroesUnitTest
{
    public class Warrior_Tests
    {
        readonly Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);
        readonly Armor mailHelmet = new Armor("Common Mail Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
        readonly Armor plateLegs = new Armor("Common Mail Legs", 1, SlotType.Legs, ArmorType.Plate, 1, 3, 3);
        readonly Armor leatherArmor = new Armor("Common leather plate", 1, SlotType.Body, ArmorType.Leather, 0, 4, 2);
        readonly Armor clothArmor = new Armor("Common cloth robe", 1, SlotType.Body, ArmorType.Cloth, 4, 2, 1);
        readonly Weapon rustySword = new Weapon("Rusty Sword", 1, 15, WeaponType.Sword);
        readonly Weapon shortStaff = new Weapon("Short Staff", 1, 15,WeaponType.Staff);
        readonly Weapon rustyDagger = new Weapon("Rusty Dagger", 1, 10, WeaponType.Dagger);
        readonly Weapon normalWand = new Weapon("Normal Wand", 1, 10, WeaponType.Wand);
        readonly Weapon steppeBow = new Weapon("Steppe Bow", 1, 13, WeaponType.Bow);
        readonly Weapon axe = new Weapon("Hammer", 1, 5, WeaponType.Axe);
        readonly Weapon hammer = new Weapon("Hammer", 1, 5, WeaponType.Hammer);

        [Fact]
        public void WarriorCanBeCreated_IsCorrect()
        {
            //Arrage
            var warrior = new Warrior("Mike the Brave");
            var expected = new List<int> { 1, 1, 5, 2 };
            var actual = new List<int> { warrior.Level, warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal("Mike the Brave", warrior.Name);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void LevelUpWorks()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            var expected = new List<int> { 2, 2, 8, 4 };

            //Act
            warrior.LevelUp();
            var actual = new List<int> { warrior.Level, warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);

        }
        
        [Fact]
        public void CanWearPlateArmor()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            var expected = new List<int> { 1, 8, 4 };

            //Act
            warrior.EquipArmor(plateArmor);
            var actual = new List<int> { warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanWearMailArmor()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            var expected = new List<int> { 1, 9, 3 };

            //Act
            warrior.EquipArmor(mailHelmet);
            var actual = new List<int> { warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CannotWearLeatherArmor()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(leatherArmor));
        }
        [Fact]
        public void CannotWearClothArmor()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(clothArmor));
        }

        [Fact]
        public void CannotWearArmorOverTheirLevel()
        {
            //Arrage
            Armor overSized = new Armor("Giant Armor", 5, SlotType.Body, ArmorType.Plate, 0, 2, 3);
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(overSized));
        }

        [Fact]
        public void TotalAttributesAreCalculatedCorretly()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);
            Armor mailHelmet = new Armor("Common Mail Helmet", 1, SlotType.Head, ArmorType.Mail, 0, 1, 4);
            Armor plateLegs = new Armor("Common Mail Legs", 1, SlotType.Legs, ArmorType.Plate, 1, 3, 3);
            Warrior warrior = new Warrior("Mike");
            var expected = new List<int> { 2, 15, 8 };

            //Act
            warrior.EquipArmor(plateArmor);
            warrior.EquipArmor(mailHelmet);
            warrior.EquipArmor(plateLegs);
            var actual = new List<int> { warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ArmorInSameSlotReplacesOldOne_CorrectAttributes()
        {
            //Arrage
            Armor mailArmor = new Armor("Common Mail Plate", 1, SlotType.Body, ArmorType.Mail, 0, 1, 4);
            Warrior warrior = new Warrior("Mike");
            var expected = new List<int> { 1, 9, 3 };

            //Act
            warrior.EquipArmor(plateArmor);
            warrior.EquipArmor(mailArmor);
            var actual = new List<int> { warrior.TotalAttributes().Intelligence, warrior.TotalAttributes().Strength, warrior.TotalAttributes().Dexterity };

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CannotWearBowWeapon()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(steppeBow));
        }
        [Fact]
        public void CannotWearStaffWeapon()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(shortStaff));
        }
        [Fact]
        public void CannotWearDaggerWeapon()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(rustyDagger));
        }

        [Fact]
        public void CannotWearWandWeapon()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(normalWand));
        }

        [Fact]
        public void CannotWearWeaponOverTheirLevel()
        {
            //Arrage
            Weapon giantsSword = new Weapon("Giants Sword", 3, 1000, WeaponType.Sword);
            Warrior warrior = new Warrior("Mike");

            //Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(giantsSword));
        }


        [Fact]
        public void DamageIsCorrect_NotWearingWeapon()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Assert
            Assert.Equal(1.05, warrior.Damage());
        }

        [Fact]
        public void DamageIsCorrect_WearingSword()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act
            warrior.EquipWeapon(rustySword);

            //Assert
            Assert.Equal(15.75, warrior.Damage());
        }
        [Fact]
        public void DamageIsCorrect_WearingAxe()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act
            warrior.EquipWeapon(axe);

            //Assert
            Assert.Equal(5.25, warrior.Damage());
        }
        [Fact]
        public void DamageIsCorrect_WearingHammer()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");

            //Act
            warrior.EquipWeapon(hammer);

            //Assert
            Assert.Equal(5.25, warrior.Damage());
        }

        [Fact]
        public void WearedWeaponCanBeReplaced_DamageIsCorrect()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            Weapon ironSword = new Weapon("Iron Sword", 1, 25, WeaponType.Sword);

            //Act
            warrior.EquipWeapon(rustySword);
            warrior.EquipWeapon(ironSword);

            //Assert
            Assert.Equal(26.25, warrior.Damage());

        }
        
        [Fact]
        public void WearingWeaponAndArmourIncreacesDamage()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            Weapon ironSword = new Weapon("Iron Sword", 1, 25, WeaponType.Sword);
            Armor elitePlate = new Armor("elitePlate", 1, SlotType.Body, ArmorType.Plate, 0, 6, 100);
            Armor eliteHelmet = new Armor("eliteHelmet", 1, SlotType.Head, ArmorType.Plate, 0, 6, 20);

            //Act
            warrior.EquipWeapon(ironSword);
            warrior.EquipArmor(elitePlate);
            warrior.EquipArmor(eliteHelmet);

            //Assert
            Assert.Equal(56.25, warrior.Damage());

        }
        [Fact]
        public void DisplayISCorrect()
        {
            //Arrage
            Warrior warrior = new Warrior("Mike");
            StringBuilder display = new StringBuilder();
            display.AppendFormat("Name: {0}\nClass: {1}\nLevel: {2}\nTotal strength: {3}\nTotal dexterity: {4}\nTotal intelligence: {5}\nDamage: {6}",
            "Mike", "Warrior", 1, 5, 2, 1, 1.05);

            //Assert
            Assert.Equal(display.ToString(), warrior.Display());
        }
    }
}