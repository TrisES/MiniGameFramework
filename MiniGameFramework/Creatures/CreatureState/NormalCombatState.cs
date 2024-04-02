namespace MiniGameFramework.Creatures.CreatureState
{
    public class NormalCombatState : ICreatureCombatState
    {
        public int CalculateDamage(Creature attacker)
        {
            // Normal attack calculation logic
            return attacker.BaseAttack + attacker.WeaponsAttackSum;
            
        }

        public int CalculateDefense(Creature defender)
        {
            // Normal defense calculation logic
            return defender.BaseDefense + defender.ArmorDefenseSum;
        }
    }
}
