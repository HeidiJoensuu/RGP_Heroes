using RBG_Heroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBHeroesUnitTest
{
    public class ItemTests
    {
        [Fact]
        public void ArmorCanBeCreated_HasCorrectName()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);

            // Assert
            Assert.Equal("Common Breastplate plate", plateArmor.Name);
        }

        [Fact]
        public void ArmorCanBeCreated_HasCorrectRequiredLevel()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);

            // Assert
            Assert.Equal(1, plateArmor.RequiredLevel);
        }

        [Fact]
        public void ArmorCanBeCreated_HasCorrectArmorType()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);

            // Assert
            Assert.Equal(ArmorType.Plate, plateArmor.ArmorType);
        }

        [Fact]
        public void ArmorCanBeCreated_HasCorrectSlot()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);

            // Assert
            Assert.Equal(SlotType.Body, plateArmor.Slot);
        }

        [Fact]
        public void ArmorCanBeCreated_HasCorrectArmorAttributes()
        {
            //Arrage
            Armor plateArmor = new Armor("Common Breastplate plate", 1, SlotType.Body, ArmorType.Plate, 0, 2, 3);
            var expected = new List<int> { 0, 2, 3 };
            var actual = new List<int> { plateArmor.ArmorAttribute.Intelligence, plateArmor.ArmorAttribute.Dexterity, plateArmor.ArmorAttribute.Strength };

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WeaponCanBeCreated_HasCorrectName()
        {
            //Arrage
            Weapon sword = new Weapon("Sword", 2, 22, WeaponType.Sword);

            Assert.Equal("Sword", sword.Name);
        }

        [Fact]
        public void WeaponCanBeCreated_HasCorrectRequiredLevel()
        {
            //Arrage
            Weapon sword = new Weapon("Sword", 2, 22, WeaponType.Sword);
            // Assert
            Assert.Equal(2, sword.RequiredLevel);
        }

        [Fact]
        public void WeaponCanBeCreated_HasCorrectSlot()
        {
            //Arrage
            Weapon sword = new Weapon("Sword", 2, 22, WeaponType.Sword);
            
            // Assert
            Assert.Equal(SlotType.Weapon, sword.Slot);
        }

        [Fact]
        public void WeaponCanBeCreated_HasCorrectWeaponType()
        {
            //Arrage
            Weapon sword = new Weapon("Sword", 2, 22, WeaponType.Sword);

            // Assert
            Assert.Equal(WeaponType.Sword, sword.WeaponType);
        }

        [Fact]
        public void WeaponCanBeCreated_HasCorrectDamage()
        {
            //Arrage
            Weapon sword = new Weapon("Sword", 2, 22, WeaponType.Sword);
            // Assert
            Assert.Equal(22, sword.WeaponDamage);
        }

    }
}
