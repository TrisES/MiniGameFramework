using MiniGameFramework.Creatures.CombatStrategy;
using MiniGameFramework.Items;
using MiniGameFramework.Items.Armor.Interfaces;
using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.Logging;
using MiniGameFramework.MarkerInterfaces;
using MiniGameFramework.Repository.Base;
using MiniGameFramework.Repository.Interfaces;
using MiniGameFramework.WorldClasses;
using System.Reflection;

namespace MiniGameFramework.Creatures
{
    /// <summary>
    /// Represents a creature in the game world.
    /// </summary>
    public abstract class Creature : IHasName, IWorldObject
    {
        #region Properties
        /// <inheritdoc/>
        public string Name { get; set; }
        /// <inheritdoc/>
        public Tile? CurrentTile { get; set; }

        /// <summary>
        /// Gets or sets the health of the creature.
        /// </summary>
        public virtual int Health { get; set; }
        /// <summary>
        /// Gets or sets the maximum health of the creature.
        /// </summary>
        public virtual int MaxHealth { get; set; }
        /// <summary>
        /// Gets or sets the base defense of the creature.
        /// </summary>
        public virtual int BaseDefense { get; set; }
        /// <summary>
        /// Gets or sets the base attack of the creature.
        /// </summary>
        public virtual int BaseAttack { get; set; }

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

        /// <summary>
        /// Returns a boolean indicating if the creature is dead.
        /// </summary>
        /// returns>True if the creature is dead; Otherwise, False</returns>
        public virtual bool IsDead => Health <= 0;

        /// <summary>
        /// Gets or sets the inventory of the creature.
        /// </summary>
        public virtual IRepositoryGUID<IItem> Inventory { get; set; }

        /// <summary>
        /// Gets or sets the combat strategy of the creature.
        /// </summary>
        public virtual ICombatStrategy CombatStrategy { get; set; }

        private readonly IGameLogger _logger;
        #endregion

        /// <summary>
        /// Initializes a new instance of the Creature class.
        /// </summary>
        public Creature(
            string name, int maxHealth = 100, int baseDefense = 10, int baseAttack = 10, 
            IRepositoryGUID<IItem>? inventory = null, ICombatStrategy? combatStrategy = null, IGameLogger? logger = null, int? currentHealth = null)
        {
            if (currentHealth != null)
            {
                Health = currentHealth.Value;
            } else
            {
                Health = maxHealth;
            }

            MaxHealth = maxHealth;

            Name = name;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;

            // the inventory is optional, if not provided, use the default one (which is GuidRepoBaseDictionary<IItem> for now)
            Inventory = inventory ?? new GuidRepoBaseDictionary<IItem>();

            // the combat strategy is optional, if not provided, use the default one
            CombatStrategy = combatStrategy ?? new CombatStrategyNormal();

            // the logger is optional, if not provided, use the default one
            _logger = logger ?? GameLogger.Instance;
        }

        /// <summary>
        /// Updates the creature.
        /// </summary>
        //public override abstract void Update(); // Implement logic for creature updates. This could include AI logic, movement, etc.

        /// <summary>
        /// Makes the creature attack a target.
        /// </summary>
        public virtual void Attack(Creature target)
        {
            int damage = CombatStrategy.CalculateDamage(this);
            _logger.Log($"{Name}({CombatStrategy.Name}) attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        /// <summary>
        /// Makes the creature receive damage.
        /// </summary>
        public virtual void ReceiveDamage(int damage)
        {
            int defense = CombatStrategy.CalculateDefense(this);
            int actualDamage = Math.Max(0, damage - defense); // Ensure damage taken is not negative using Math.Max
            Health -= actualDamage;
            _logger.Log($"{Name}({CombatStrategy.Name}) has {defense} defense and receives {actualDamage} damage. Remaining health: {Health}");
        }

        /// <summary>
        /// Makes the creature attack.
        /// </summary>
        public virtual int Attack()
        {
            return CombatStrategy.CalculateDamage(this);
        }

        /// <summary>
        /// Makes the creature defend.
        /// </summary>
        public virtual int Defend()
        {
            return CombatStrategy.CalculateDefense(this);
        }

        /// <summary>
        /// Makes the creature receive healing.
        /// </summary>
        public virtual void RecieveHealing(int healing)
        {
            Health = Math.Min(MaxHealth, Health + healing); // Ensure health does not exceed max health using Math.Min
        }

        /// <summary>
        /// Fully heals the creature.
        /// </summary>
        public virtual void FullHeal()
        {
            Health = MaxHealth;
        }

        /// <summary>
        /// Makes the creature move to a destination tile.
        /// </summary>
        public virtual bool MoveTo(Tile destinationTile)
        {
            // Check if the destination tile is valid and not blocked
            if (destinationTile == null || !CanMoveTo(destinationTile))
            {
                return false;
            }

            // Remove the creature from the current tile
            CurrentTile?.Contents.Remove(this);

            // Update the creature's current tile and add it to the new tile
            CurrentTile = destinationTile;
            CurrentTile.Contents.Add(this);
            return true;
        }

        /// <summary>
        /// Checks if the creature can move to a tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>True if creatue can move to tile; Otherwise, False</returns>
        private bool CanMoveTo(Tile tile)
        {
            // Implement logic to check if the tile is walkable. Could include conditions like checking for other creatures, terrain, etc.
            return tile.Contents.All(obj => obj is not Creature); // Example condition: no other creatures on the tile
        }

        /// <summary>
        /// Equip an item to the creature.
        /// </summary>
        /// <param name="equipment">The item to equip</param>
        /// <returns>True if item was equipped; Otherwise, False</returns>
        public abstract bool Equip(IItem equipment); //{ throw new NotImplementedException();}

        /// <summary>
        /// Loot items on the ground(current tile) to the creature's inventory, removing them from the tile.
        /// </summary>
        public virtual void Loot()
        {
            // if current tile is not null, add all items on the tile to the creature's inventory and remove them from the tile accordingly
            if (CurrentTile == null) return;

            // Create a list to store the items to be removed (to avoid modifying the collection while iterating)
            List<IItem> itemsToRemove = new List<IItem>();

            // Iterate through all objects on the tile
            foreach (IWorldObject obj in CurrentTile.Contents)
            {
                if (obj is IItem item)
                {
                    // Add the item to the inventory
                    Inventory.Add(item);

                    // Add the item to the list of items to be removed
                    itemsToRemove.Add(item);
                }
            }

            // Remove the items from the tile
            foreach (IItem itemToRemove in itemsToRemove)
            {
                CurrentTile.Contents.Remove(itemToRemove);
            }
        }
    }
}
