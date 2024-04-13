using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.Logging;

namespace MiniGameFramework.Items.Weapons.Factory
{
    public class WeaponFactoryMedieval : IWeaponFactoryMethod
    {
        GameLogger GameLogger = GameLogger.Instance;

        public IWeapon CreateWeapon(WeaponEnum weapon)
        {
            switch (weapon)
            {
                case WeaponEnum.Axe:
                    return new IronAxe();
                case WeaponEnum.Sword:
                    return new IronSword();
                case WeaponEnum.Dagger:
                    return new IronDagger();
                default:
                    string message = $"WeaponFactoryMedieval - no class found for weapon: {weapon}";
                    GameLogger.Log(message, System.Diagnostics.TraceEventType.Error);
                    throw new ArgumentException(message);
            }
        }
    }
}
