namespace MiniGameFramework.Creatures.CreatureState
{
    public class DefensiveCombatState : ICreatureCombatState
    {
        public void Hit(Creature creature, Creature target)
        {
            // Defensive attack logic
            int damage = creature.BaseAttack / 2;
            Console.WriteLine($"{creature.Name} attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        public void RecieveHit(Creature creature, int damage)
        {
            // Defensive damage reception logic
            int actualDamage = damage / 2;
            creature.Health -= actualDamage;
            Console.WriteLine($"{creature.Name} receives {damage} damage.");
        }
    }

}
