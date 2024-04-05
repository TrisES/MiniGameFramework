namespace MiniGameFramework.Creatures.CombatStrategy
{
    /// <summary>
    /// Interface for the combat strategy/behaviour of a creature.
    /// Contains methods for calculating damage and defense.
    /// Can be implemented by different concrete strategy classes to provide different combat behaviours, like half damage, double damage, etc.
    /// </summary>
    public interface ICombatStrategy
    {
        /// <summary>
        /// Calculate the damage to be dealt by the attacking creature.
        /// </summary>
        /// <param name="attacker">The creature attacking.</param>
        /// <returns>The amount of damage to be dealt.</returns>
        int CalculateDamage(Creature attacker);

        /// <summary>
        /// Calculate the defense to be applied to the defending creature.
        /// </summary>
        /// <param name="defender">The creature receiving the damage.</param>
        /// <returns>The amount of defense to be applied.</returns>
        int CalculateDefense(Creature defender);
    }
}
