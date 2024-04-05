using MiniGameFramework.Creatures.CombatStrategy;
using MiniGameFramework.Items;
using MiniGameFramework.Items.Armor;
using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.Logging;
using MiniGameFramework.WorldClasses;
using System.Reflection;

namespace MiniGameFramework.Creatures
{
    public abstract class Creature : WorldObject
    {
        public int Health { get; set; }
        public int BaseDefense { get; set; }
        public int BaseAttack { get; set; }

        public int ArmorDefenseSum 
        { 
            get 
            {
                int sum = 0;

                // Get all properties of the creature
                PropertyInfo[] properties = GetType().GetProperties();

                // Iterate through all properties
                foreach (PropertyInfo property in properties)
                {
                    // Check if the property type implements the IArmor interface
                    if (typeof(IArmor).IsAssignableFrom(property.PropertyType))
                    {
                        // Get the value of the property
                        object? armor = property.GetValue(this);

                        // If the armor is not null, add its defense value to the sum
                        if (armor != null)
                        {
                            sum += ((IArmor)armor).Defense;
                        }
                    }
                }

                return sum;
            }
        }
        public int WeaponsAttackSum 
        { 
            get
            {
                int sum = 0;

                // Get all properties of the creature
                PropertyInfo[] properties = GetType().GetProperties();

                // Iterate through all properties
                foreach (PropertyInfo property in properties)
                {
                    // Check if the property type implements the IWeapon interface
                    if (typeof(IWeapon).IsAssignableFrom(property.PropertyType))
                    {
                        // Get the value of the property
                        object? weapon = property.GetValue(this);

                        // If the weapon is not null, add its damage value to the sum
                        if (weapon != null)
                        {
                            sum += ((IWeapon)weapon).Damage;
                        }
                    }
                }

                return sum;
            }
        }

        public IInventory Inventory { get; set; }
        public ICombatStrategy CombatStrategy { get; set; }

        public Creature(string name, int health, int baseDefense, int baseAttack) : base(name)
        {
            Name = name;
            Health = health;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
            Inventory = new Inventory();
            CombatStrategy = new CombatStrategyNormal();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public void Attack(Creature target)
        {
            int damage = CombatStrategy.CalculateDamage(this);
            GameLogger.Log($"{Name}{CombatStrategy.GetType()} attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        public void ReceiveDamage(int damage)
        {
            int defense = CombatStrategy.CalculateDefense(this);
            int actualDamage = Math.Max(0, damage - defense); // Ensure damage taken is not negative'
            Health -= actualDamage;
            GameLogger.Log($"{Name}{CombatStrategy.GetType()} has {defense} and receives {actualDamage} damage. Remaining health: {Health}");
        }

        public int Attack()
        {
            return CombatStrategy.CalculateDamage(this);
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
