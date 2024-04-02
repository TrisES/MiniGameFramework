namespace MiniGameFramework.Creatures.CreatureState
{
    /// <summary>
    /// Interface for the combat state/behaviour of a creature.
    /// Contains methods for calculating damage and defense.
    /// Can be implemented by different state classes to provide different combat behaviours, like half damage, double damage, etc.
    /// </summary>
    public interface ICreatureCombatState
    {
        /// <summary>
        /// Attack a target creature.
        /// </summary>
        /// <param name="attacker">The creature attacking.</param>
        /// <returns>The amount of damage to be dealt.</returns>
        int CalculateDamage(Creature attacker);

        /// <summary>
        /// Receive damage by the attacking creature.
        /// </summary>
        /// <param name="defender">The creature receiving the damage.</param>
        int CalculateDefense(Creature defender);
    }
}
