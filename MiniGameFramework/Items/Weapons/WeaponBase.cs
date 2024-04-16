using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.WorldClasses;

namespace MiniGameFramework.Items.Weapons
{
    /// <summary>
    /// Abstract 'Weapon' 'Creator' class that implements the 'IWeapon' interface.
    /// </summary>
    public abstract class WeaponBase : IWeapon
    {
        public Guid Id { get; set; }
        public abstract string Name { get; }
        public abstract int Damage { get; }
        public Tile? CurrentTile { get; set; }

        public WeaponBase()
        { 
            Id = new Guid(); 
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} damage)";
        }

    }
}
