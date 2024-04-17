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

    public class Defense
    {
        public int Value { get; }

        public Defense(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Defense value cannot be negative.");
            }
            Value = value;
        }
    }

    // TODO: brug denne klasse i stedet for int, hvor det er relevant, f.eks. i Damage og Defense, så vi kan sikre at værdierne er positive (Liskov substitution principle)
    // Restricting the value to be positive
    public class PositiveInteger
    {
        public int Value { get; }

        public PositiveInteger(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative.");
            }
            Value = value;
        }
    }
}
