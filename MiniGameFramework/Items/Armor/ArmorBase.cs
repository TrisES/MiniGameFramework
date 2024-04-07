using MiniGameFramework.Items.Armor.Interfaces;

namespace MiniGameFramework.Items.Armor
{
    public abstract class ArmorBase : IArmor
    {

        public Guid Id { get; set; }
        public abstract string Name { get; }
        public abstract int Defense { get; }

        public ArmorBase()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{Name} ({Defense} defense)";
        }
    }
}
