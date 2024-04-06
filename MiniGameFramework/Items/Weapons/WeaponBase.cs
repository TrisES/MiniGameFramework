using MiniGameFramework.Items.Weapons.Interfaces;

namespace MiniGameFramework.Items.Weapons
{
    /// <summary>
    /// Abstract 'Weapon' 'Creator' class that implements the 'IWeapon' interface.
    /// </summary>
    public abstract class WeaponBase : IWeapon
    {
        public abstract string Name { get; }
        public abstract int Damage { get; }

        public WeaponBase(){}

        public override string ToString()
        {
            return $"{Name} ({Damage} damage)";
        }

    }
}
