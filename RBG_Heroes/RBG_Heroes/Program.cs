using RBG_Heroes.Heroes;
using RBG_Heroes.Items;

var warrior = new Warrior { Name = "Mike"};
warrior.LevelUp();
var newAxe = new Weapon { Name = "Axe", RequiredLevel = 1, WeaponDamage = 2, WeaponType= WeaponType.Axe};
Armor keke = new Armor { ArmorAttribute = { Dexterity = 1, Intelligence = 2, Strength = 2 }, Name = "koke", Slot = SlotType.Head, ArmorType = ArmorType.Mail, RequiredLevel = 1 };

warrior.EquipArmor( keke );
warrior.EquipWeapon(newAxe);


warrior.TotalAttributes();

warrior.Display();