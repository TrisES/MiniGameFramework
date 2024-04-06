namespace MiniGameFramework.Creatures.CombatStrategy
{
    /// <summary>
    /// A normal combat strategy for creatures.
    /// </summary>
    public class CombatStrategyNormal : ICombatStrategy
    {
        public string Name { get { return "Normal"; } }

        /// <summary>
        /// Sums the base attack and weapons attack of the attacker to calculate the damage.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int CalculateDamage(Creature attacker)
        {
            // Normal attack calculation logic
            return attacker.BaseAttack + attacker.WeaponsAttackSum;
        }

        /// <summary>
        /// Sums the base defense and armor defense of the defender to calculate the defense.
        /// </summary>
        /// <param name="defender"></param>
        /// <returns></returns>
        public int CalculateDefense(Creature defender)
        {
            // Normal defense calculation logic
            return defender.BaseDefense + defender.ArmorDefenseSum;
        }
    }
}
