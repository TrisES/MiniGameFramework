using MiniGameFramework.Items.Weapons.Interfaces;

namespace MiniGameFramework.Items.Weapons
{
    /// <summary>
    /// Abstract 'Weapon' 'Creator' class that implements the 'IWeapon' interface.
    /// </summary>
    public abstract class WeaponBase : IWeapon
    {
        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }

        public WeaponBase(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} damage)";
        }

    }
}
