using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGameFramework.Creatures;
using MiniGameFramework.Creatures.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameFramework.Creatures.Tests
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
    }
}