namespace MiniGameFramework.Creatures.CombatStrategy
{
    /// <summary>
    /// A combat strategy that focuses on defense.
    /// </summary>
    public class CombatStrategyDefensive : ICombatStrategy
    {
        /// <summary>
        /// Halves the sum of the base attack and weapons attack of the attacker to calculate the damage.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int CalculateDamage(Creature attacker)
        {
            // Defensive attack calculation logic
            return (attacker.BaseAttack + attacker.WeaponsAttackSum) / 2;
        }

        /// <summary>
        /// Doubles the sum of the base attack and weapons attack of the defender to calculate the defense.
        /// </summary>
        /// <param name="defender"></param>
        /// <returns></returns>
        public int CalculateDefense(Creature defender)
        {
            // Defensive defense calculation logic
            return (defender.BaseAttack + defender.WeaponsAttackSum) * 2;
        }
    }
}
