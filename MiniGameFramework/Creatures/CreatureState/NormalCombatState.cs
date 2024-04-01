namespace MiniGameFramework.Creatures.CreatureState
{
    public class NormalCombatState : ICreatureCombatState
    {
        public void Hit(Creature creature, Creature target)
        {
            // Normal attack logic
            int damage = creature.BaseAttack;
            Console.WriteLine($"{creature.Name} attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        public void RecieveHit(Creature creature, int damage)
        {
            // Normal damage reception logic
            creature.Health -= damage;
            Console.WriteLine($"{creature.Name} receives {damage} damage.");
        }
    }
}
