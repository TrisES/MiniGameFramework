using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGameFramework.Creatures;
using MiniGameFramework.Creatures.CombatStrategy;
using MiniGameFramework.Creatures.Concrete;
using MiniGameFramework.Creatures.Decorator;
using MiniGameFramework.Items;
using MiniGameFramework.Items.Armor.Factory;
using MiniGameFramework.Items.Weapons.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameFrameworkTests.Creatures.Tests
{
    [TestClass()]
    public class CreatureTests
    {
        [TestMethod()]
        public void AttackTest()
        {
            // Arrange
            Creature attacker = new HumanSoldier("Soldier A", 100, 10, 20);
            Creature defender = new HumanSoldier("Soldier B", 100, 10, 20);

            // Act
            attacker.Attack(defender);

            // Assert
            Assert.IsTrue(defender.Health < 100);
            Assert.AreEqual(90, defender.Health);
        }

        [TestMethod()]
        public void StrategyTest()
        {
            // Arrange
            Creature attacker = new HumanSoldier("Soldier A", 100, 10, 20);
            Creature defender = new HumanSoldier("Soldier B", 100, 10, 20);

            // Act
            attacker.CombatStrategy = new CombatStrategyOffensive(); // double damage given and taken
            attacker.Attack(defender);
            defender.Attack(attacker);

            // Assert
            Assert.AreEqual(70, defender.Health);
            Assert.AreEqual(85, attacker.Health);


            // Arrange
            attacker = new HumanSoldier("Soldier A", 100, 10, 20);
            defender = new HumanSoldier("Soldier B", 100, 10, 20);

            // Act
            attacker.CombatStrategy = new CombatStrategyDefensive(); // halves damage given and taken
            attacker.Attack(defender);
            defender.Attack(attacker);

            // Assert
            Assert.AreEqual(100, defender.Health);
            Assert.AreEqual(100, attacker.Health);
        }

        [TestMethod()]
        public void DecoratorTest()
        {
            // Arrange
            Creature attacker = new HumanSoldier("Soldier AAA", 100, 0, 10);
            Creature defender = new HumanSoldier("Soldier BBB", 100, 0, 10);

            // Act (attack buff (buffs baseAttack)
            attacker = new AttackBuff(attacker, 10); // +10 damage, +10 health
            attacker.Attack(defender);

            // Assert
            Assert.AreEqual(80, defender.Health);

            // Act (defense buff (buffs baseDef))
            defender = new DefenseBuff(defender, 10); // +10 defense
            attacker.Attack(defender);

            // Assert
            Assert.AreEqual(70, defender.Health);

            // Act (health buff (buffs current- and max- health))
            defender = new HealthBuff(defender, 10); // +10 health

            // Assert
            Assert.AreEqual(80, defender.Health);
            Assert.AreEqual(110, defender.MaxHealth);
        }

        [TestMethod()]
        public void InventoryAndFactoryTest()
        {
            // Arrange (create, armor and weapon factories)
            Creature creature = new HumanSoldier("Soldier AAA", 100, 10, 10);
            IArmorFactoryMethod armorFactory = new ArmorFactory();
            IWeaponFactoryMethod weaponFactory = new WeaponFactoryMedieval();

            // Act
            creature.Inventory.Add(armorFactory.CreateArmor("Iron Helmet"));
            creature.Inventory.Add(weaponFactory.CreateWeapon(WeaponEnum.Dagger));

            // Assert
            Assert.AreEqual(2, creature.Inventory.Count);

            // Act
            creature.Inventory.Delete(creature.Inventory.GetFirst(item => item.Name == "Iron Helmet").Id);

            // Assert
            Assert.AreEqual(1, creature.Inventory.Count);
        }

        [TestMethod()]
        public void FightWithEquipmentTest()
        {
            // Arrange (create, armor and weapon factories)
            Creature attacker = new HumanSoldier("Soldier AAA", 100, 10, 10);
            Creature defender = new HumanSoldier("Soldier BBB", 100, 10, 10);
            IArmorFactoryMethod armorFactory = new ArmorFactory();
            IWeaponFactoryMethod weaponFactory = new WeaponFactoryMedieval();

            // Act
            attacker.Inventory.Add(armorFactory.CreateArmor("Iron Helmet")); // +3 defense
            attacker.Inventory.Add(weaponFactory.CreateWeapon(WeaponEnum.Dagger)); // +5 attack
            attacker.Attack(defender);

            // Assert
            Assert.AreEqual(90, defender.Health);
        }
    }
}