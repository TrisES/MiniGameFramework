using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.Logging;

namespace MiniGameFramework.Items.Weapons.Factory
{
    public class WeaponFactoryFuture : IWeaponFactoryMethod
    {
        public IWeapon CreateWeapon(WeaponEnum weapon)
        {
            switch (weapon)
            {
                case WeaponEnum.Axe:
                    return new LaserAxe();
                case WeaponEnum.Sword:
                    return new LaserSword();
                case WeaponEnum.Dagger:
                    return new LaserDagger();
                default:
                    string message = $"WeaponFactoryFuture - no class found for weapon: {weapon}";
                    GameLogger.Log(message, System.Diagnostics.TraceEventType.Error);
                    throw new ArgumentException(message);
            }
        }
    }
}
