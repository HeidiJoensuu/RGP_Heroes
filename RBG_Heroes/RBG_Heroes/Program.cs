using RBG_Heroes.Heroes;
using RBG_Heroes.Items;

Console.WriteLine("");
Rogue rogue = new Rogue("Mike");
Console.WriteLine(rogue.Damage());
Weapon ironSword = new Weapon("Iron Sword", 1, 25, WeaponType.Sword);
Armor elitePlate = new Armor("elitePlate", 1, SlotType.Body, ArmorType.Leather, 0, 6, 100);
Armor eliteHelmet = new Armor("eliteHelmet", 1, SlotType.Head, ArmorType.Mail, 0, 6, 20);

rogue.EquipWeapon(ironSword);
rogue.EquipArmor(elitePlate);
rogue.EquipArmor(eliteHelmet);


Console.WriteLine(rogue.Damage());
