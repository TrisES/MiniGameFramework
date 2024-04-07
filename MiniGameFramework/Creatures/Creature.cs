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
        #region Properties
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int BaseDefense { get; set; }
        public int BaseAttack { get; set; }

        /// <summary>
        /// Gets the sum of the defense values of all armor items equipped by the creature.
        /// If the creature has no armor equipped, the sum is 0.
        /// Foreach property in the runtime class, check if it implements the IArmor interface and if it does, add the defense value to the sum.
        /// For better performance, could be overridden in derived classes to avoid reflection.
        /// </summary>
        public virtual int ArmorDefenseSum 
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

        /// <summary>
        /// Gets the sum of the attack values of all weapon items equipped by the creature.
        /// If the creature has no weapons equipped, the sum is 0.
        /// Foreach property in the runtime class, check if it implements the IWeapon interface and if it does, add the damage value to the sum.
        /// For better performance, could be overridden in derived classes to avoid reflection.
        /// </summary>
        public virtual int WeaponsAttackSum 
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
        #endregion

        public Creature(string name, int maxHealth = 100, int baseDefense = 10, int baseAttack = 10) : base(name)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
            Inventory = new Inventory();
            CombatStrategy = new CombatStrategyNormal();
        }


        public void Attack(Creature target)
        {
            int damage = CombatStrategy.CalculateDamage(this);
            GameLogger.Log($"{Name}({CombatStrategy.Name}) attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        public void ReceiveDamage(int damage)
        {
            int defense = CombatStrategy.CalculateDefense(this);
            int actualDamage = Math.Max(0, damage - defense); // Ensure damage taken is not negative using Math.Max
            Health -= actualDamage;
            GameLogger.Log($"{Name}({CombatStrategy.Name}) has {defense} defense and receives {actualDamage} damage. Remaining health: {Health}");
        }

        public int Attack()
        {
            return CombatStrategy.CalculateDamage(this);
        }

        public int Defend()
        {
            return CombatStrategy.CalculateDefense(this);
        }

        public void RecieveHealing(int healing)
        {
            Health = Math.Min(MaxHealth, Health + healing); // Ensure health does not exceed max health using Math.Min
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
