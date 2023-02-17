# RGP_Heroes

Idea of this project was to create console application by using C#.
The goal was to be able to create new heroes, armours and weapons.

## Class interaction diagram (current)
![alt text](/ClassInteractionDiagram.PNG)

## Folder structure

```
.
│   RBG_Heroes.sln
│   README.md
│
├───Assets
│       ClassInteractionDiagram.PNG             # Readme's diagram picture
│
├───RBG_Heroes
│   │   Program.cs
│   │   RBG_Heroes.csproj
│   │
│   ├───Attributes
│   │       HeroAttributes.cs                   # Hero attributes class
│   │
│   ├───Exceptions                              # Custom exceptions
│   │       InvalidArmorException.cs
│   │       InvalidWeaponException.cs
│   │
│   ├───Heroes                      
│   │       Hero.cs                             # Abstract Hero class implements IHero
│   │       IHero.cs                            # Hero interface
│   │       Mage.cs                             # Mage class exstens Hero
│   │       Ranger.cs                           # Ranger class exstens Hero
│   │       Rogue.cs                            # Rogue class exstens Hero
│   │       Warrior.cs                          # Warrior class exstens Hero
│   │
│   └───Items
│          Armor.cs                             # Armor class extens Item class
│          ArmorType.cs                         # Enum class of Armor types
│          Item.cs                              # Abstraxct Item class
│          SlotType.cs                          # Enum class of Slot types
│          Weapon.cs                            # Weapon class extens Item class
│          WeaponType.cs                        # Enum class of Weapon types
│   
└───RGBHeroesUnitTest                           # Contains tests for classes.
       ItemTests.cs
       Mage_Tests.cs
       RangerTests.cs
       RGBHeroesUnitTest.csproj
       Rogue_Tests.cs
       Usings.cs
       Warrior_Tests.cs
    
 
```


Possible TODO in future:
Refactoring Items folder to be made by builder-method.
.gitIgnore