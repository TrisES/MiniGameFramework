namespace MiniGameFramework.Creatures
{
    public class Damage
    {
        public int Value { get; }

        public Damage(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Damage value cannot be negative.");
            }
            Value = value;
        }
    }
}
