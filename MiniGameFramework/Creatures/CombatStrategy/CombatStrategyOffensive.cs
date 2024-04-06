namespace MiniGameFramework.Creatures.CombatStrategy
{
    /// <summary>
    /// A combat strategy that focuses on offense.
    /// </summary>
    public class CombatStrategyOffensive : ICombatStrategy
    {
        public string Name { get { return "Offensive"; } }    

        /// <summary>
        /// Doubles the sum of the base attack and weapons attack of the attacker to calculate the damage.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int CalculateDamage(Creature attacker)
        {
            return (attacker.BaseAttack + attacker.WeaponsAttackSum) * 2;
        }

        /// <summary>
        /// Halves the sum of the base defense and armor defense of the defender to calculate the defense.
        /// </summary>
        /// <param name="defender"></param>
        /// <returns></returns>
        public int CalculateDefense(Creature defender)
        {
            return (defender.BaseDefense + defender.ArmorDefenseSum) / 2;
        }
    }
}
