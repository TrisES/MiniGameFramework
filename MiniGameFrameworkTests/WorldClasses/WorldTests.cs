﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGameFramework.Creatures;
using MiniGameFramework.Creatures.Concrete;
using MiniGameFramework.Items.Armor.Factory;
using MiniGameFramework.Items.Weapons.Factory;
using MiniGameFramework.WorldClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameFramework.WorldClasses.Tests
{
    [TestClass()]
    public class WorldTests
    {
        [TestMethod()]
        public void TestInitializeWorld()
        {
            // Arrange (create a world)
            int width = 10;
            int height = 10;
            World world = new World(width, height);

            // Assert (check if the world has the correct dimensions and all tiles are initialized)
            Assert.AreEqual(width, world.Width);
            Assert.AreEqual(height, world.Height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Assert.IsNotNull(world.GetTile(x, y));
                }
            }
        }

        [TestMethod()] public void TestInitializeWorldFromConfig() 
        { 
            // Arrange (create a world from a config file) 
            string configFilePath = @"C:\Temp\Config\WorldConfig.xml"; // assuming this file exists in the directory, with the correct format and values.
            World world = new World(configFilePath); 

            // Assert (check if the world has the correct dimensions and all tiles are initialized) 
            Assert.AreEqual(10, world.Width); 
            Assert.AreEqual(10, world.Height); 

            for (int x = 0; x < world.Width; x++)
            {
                for (int y = 0; y < world.Height; y++)
                {
                    Assert.IsNotNull(world.GetTile(x, y)); 
                } 
            } 
        }

        [TestMethod()]
        public void TestAddCreatures()
        {
            // Arrange (create a world and two creatures)
            World world = new World(10, 10);
            IWorldObject creature1 = new HumanSoldier("Soldier AAA", 100, 10, 10);
            IWorldObject creature2 = new HumanSoldier("Soldier BBB", 100, 10, 10);

            // Act (add the creatures to the world)
            world.AddObject(creature1, 1, 1);
            world.AddObject(creature2, 2, 2);

            // Assert (check if the creatures are in the correct tiles)
            // Through world
            Assert.AreEqual(creature1, world.GetTile(1, 1).Contents.First());
            Assert.AreEqual(creature2, world.GetTile(2, 2).Contents.First());
            // Through creature
            Assert.AreEqual(1, creature1.CurrentTile.X);
            Assert.AreEqual(1, creature1.CurrentTile.Y);
        }

        [TestMethod()]
        public void TestMoveCreature()
        {
            // Arrange (create a world and a creature)
            World world = new World(10, 10);
            IWorldObject creature = new HumanSoldier("Soldier AAA", 100, 10, 10);

            // Act (add the creature to the world)
            world.AddObject(creature, 1, 1);
            world.RemoveObject(creature);
            world.AddObject(creature, 2, 2);

            // Assert (check if the creature is in the correct tile)
            Assert.AreEqual(creature, world.GetTile(2, 2).Contents.First());
            // Check if the creature is not in the previous tile
            Assert.IsFalse(world.GetTile(1, 1).Contents.Contains(creature));
        }

        [TestMethod()]
        public void TestMoveCreature2ndApproach()
        {
            // Arrange (create a world and a creature)
            World world = new World(10, 10);
            Creature creature = new HumanSoldier("Soldier AAA", 100, 10, 10);

            // Act (add the creature to the world)
            world.AddObject(creature, 1, 1);
            // Move the creature (using Creatures methods)
            creature.MoveTo(world.GetTile(2, 2));

            // Assert (check if the creature is in the correct tile)
            Assert.AreEqual(creature, world.GetTile(2, 2).Contents.First());
            // Check if the creature is not in the previous tile
            Assert.IsFalse(world.GetTile(1, 1).Contents.Contains(creature));
        }

        [TestMethod()]
        public void CreatureLootsItemsOnTileTest()
        {
            // Arrange (create Tile, creature and items)
            Tile tile = new Tile(0, 0);
            Creature creature = new HumanSoldier("Soldier AAA", 100, 10, 10);
            IArmorFactoryMethod armorFactory = new ArmorFactory();
            IWeaponFactoryMethod weaponFactory = new WeaponFactoryMedieval();

            // Act (add the creature and some items on the tile)
            tile.AddObject(creature);
            tile.AddObject(armorFactory.CreateArmor("Iron Helmet"));
            tile.AddObject(weaponFactory.CreateWeapon(WeaponEnum.Dagger));

            // Assert (check if the creature has the items in its inventory after looting the tile)
            Assert.AreEqual(0, creature.Inventory.Count);
            creature.Loot();
            Assert.AreEqual(2, creature.Inventory.Count);
        }

    }
}