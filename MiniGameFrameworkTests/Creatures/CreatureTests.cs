using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGameFramework.Creatures;
using MiniGameFramework.Creatures.CombatStrategy;
using MiniGameFramework.Creatures.Concrete;
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
    }
}