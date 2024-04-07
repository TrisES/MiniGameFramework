namespace MiniGameFramework.Creatures.Decorator
{
    /// <summary>
    /// Decorator that adds additional base attack to a creature.
    /// </summary>
    public class AttackBuff : CreatureDecorator
    {
        private int _additionalAttack;
        public AttackBuff(Creature creature, int additionalAttack) : base(creature)
        {
            _additionalAttack = additionalAttack;
        }

        public override int BaseAttack => _creature.BaseAttack + _additionalAttack;
    }

    /// <summary>
    /// Decorator that adds additional base defense to a creature.
    /// </summary>
    public class DefenseBuff : CreatureDecorator
    {
        private int _additionalDefense;
        public DefenseBuff(Creature creature, int additionalDefense) : base(creature)
        {
            _additionalDefense = additionalDefense;
        }

        public override int BaseDefense => _creature.BaseDefense + _additionalDefense;
    }

    /// <summary>
    /// Decorator that adds additional health and maxHealth to a creature.
    /// </summary>
    public class HealthBuff : CreatureDecorator
    {
        private int _additionalHealth;
        public HealthBuff(Creature creature, int additionalHealth) : base(creature)
        {
            _additionalHealth = additionalHealth;
        }

        public override int Health => _creature.Health + _additionalHealth;
        public override int MaxHealth => _creature.MaxHealth + _additionalHealth;
    }

}
