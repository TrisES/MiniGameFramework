using MiniGameFramework.Creatures.CreatureState;
using MiniGameFramework.Items;
using MiniGameFramework.Logging;
using MiniGameFramework.WorldClasses;

namespace MiniGameFramework.Creatures
{
    public abstract class Creature : WorldObject
    {
        public int Health { get; set; }
        public int BaseDefense { get; set; }
        public int BaseAttack { get; set; }

        public abstract int ArmorDefenseSum { get; }
        public abstract int WeaponsAttackSum { get; }

        public Inventory Inventory { get; set; }
        public ICreatureCombatState State { get; set; }

        public Creature(string name, int health, int baseDefense, int baseAttack) : base(name)
        {
            Name = name;
            Health = health;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
            Inventory = new Inventory();
            State = new NormalCombatState();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public void Attack(Creature target)
        {
            int damage = State.CalculateDamage(this);
            GameLogger.Log($"{Name}{State.GetType()} attacks {target.Name} for {damage} damage.");
            target.ReceiveDamage(damage);
        }

        public void ReceiveDamage(int damage)
        {
            int defense = State.CalculateDefense(this);
            int actualDamage = Math.Max(0, damage - defense); // Ensure damage taken is not negative'
            Health -= actualDamage;
            GameLogger.Log($"{Name}{State.GetType()} has {defense} and receives {actualDamage} damage. Remaining health: {Health}");
        }

        public int Attack()
        {
            return State.CalculateDamage(this);
        }

        public bool MoveTo(Tile destinationTile)
        {
            // Check if the destination tile is valid and not blocked
            if (destinationTile == null || !CanMoveTo(destinationTile))
            {
                return false;
            }

            // Remove the creature from the current tile
            CurrentTile?.Contents.Remove(this);

            // Update the creature's current tile
            CurrentTile = destinationTile;
            CurrentTile.Contents.Add(this);
            return true;
        }

        private bool CanMoveTo(Tile tile)
        {
            // Implement logic to check if the tile is walkable. This could include checking for obstacles.
            return tile.Contents.All(obj => obj is not Creature); // Example condition: no other creatures on the tile
        }
    }
}
