﻿using MiniGameFramework.Creatures.CreatureState;
using MiniGameFramework.Items;
using MiniGameFramework.WorldClasses;

namespace MiniGameFramework.Creatures
{
    public abstract class Creature : WorldObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int BaseDefense { get; set; }
        public int BaseAttack { get; set; }
        public Inventory Inventory { get; set; }
        public ICreatureCombatState State { get; set; }

        public Creature(string name, int health, int baseDefense, int baseAttack) : base(name)
        {
            Name = name;
            Health = health;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
            Inventory = new Inventory();
            State = new NormalCombatState();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public void Attack(Creature target)
        {
            State.Hit(this, target);
        }

        public void ReceiveDamage(int damage)
        {
            State.RecieveHit(this, damage);
        }

        public bool MoveTo(Tile destinationTile)
        {
            // Check if the destination tile is valid and not blocked
            if (destinationTile == null || !CanMoveTo(destinationTile))
            {
                return false;
            }

            // Remove the creature from the current tile
            CurrentTile?.Contents.Remove(this);

            // Update the creature's current tile
            CurrentTile = destinationTile;
            CurrentTile.Contents.Add(this);
            return true;
        }

        private bool CanMoveTo(Tile tile)
        {
            // Implement logic to check if the tile is walkable. This could include checking for obstacles.
            return tile.Contents.All(obj => obj is not Creature); // Example condition: no other creatures on the tile
        }
    }
}
