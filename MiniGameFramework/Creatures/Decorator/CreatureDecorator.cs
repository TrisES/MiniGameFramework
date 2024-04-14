namespace MiniGameFramework.Creatures.Decorator
{
    /// <summary>
    /// Base class for creature decorators.
    /// Enables additional functionality to be added to creatures dynamically.
    /// Like adding a new behavior or adding a new property, like a temporary (de)buff.
    /// </summary>
    public abstract class CreatureDecorator : Creature
    {
        protected Creature _creature;

        public CreatureDecorator(Creature creature) : base(creature.Name, creature.MaxHealth, creature.BaseDefense, creature.BaseAttack, creature.Inventory, creature.CombatStrategy, currentHealth:creature.Health)
        {
            _creature = creature;
        }
    }
}
