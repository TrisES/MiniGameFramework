using MiniGameFramework.Items.Armor.Interfaces;
using MiniGameFramework.WorldClasses;

namespace MiniGameFramework.Items.Armor
{
    public abstract class ArmorBase : IArmor
    {

        public Guid Id { get; set; }
        public abstract string Name { get; }
        public abstract int Defense { get; }
        public Tile? CurrentTile { get; set; }

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
