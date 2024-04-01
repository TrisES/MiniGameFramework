namespace MiniGameFramework.Creatures.CreatureState
{
    /// <summary>
    /// Interface for the combat state/behaviour of a creature.
    /// Contains methods for attacking and receiving damage.
    /// Can be implemented by different state classes to provide different combat behaviours, like half damage, double damage, etc.
    /// </summary>
    public interface ICreatureCombatState
    {
        /// <summary>
        /// Attack a target creature.
        /// </summary>
        /// <param name="creature">The attacking creature.</param>
        /// <param name="target">The target creature to attack.</param>
        void Hit(Creature creature, Creature target);

        /// <summary>
        /// Receive damage by the attacking creature.
        /// </summary>
        /// <param name="creature">The creature receiving the damage.</param>
        /// <param name="damage">The amount of damage incoming.</param>
        void RecieveHit(Creature creature, int damage);
    }
}
