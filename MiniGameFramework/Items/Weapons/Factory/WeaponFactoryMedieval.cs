using MiniGameFramework.Items.Weapons.Interfaces;
using MiniGameFramework.Logging;
using System.Diagnostics;

namespace MiniGameFramework.Items.Weapons.Factory
{
    public class WeaponFactoryMedieval : IWeaponFactoryMethod
    {
        GameLogger GameLogger = GameLogger.Instance;

        public IWeapon CreateWeapon(WeaponEnum weapon)
        {
            GameLogger.Log($"{this.GetType().Name} - trying to create weapon: \"{weapon}\"", TraceEventType.Information);

            IWeapon weaponObject;
            switch (weapon)
            {
                case WeaponEnum.Axe:
                    weaponObject = new IronAxe();
                    break;
                case WeaponEnum.Sword:
                    weaponObject = new IronSword();
                    break;
                case WeaponEnum.Dagger:
                    weaponObject = new IronDagger();
                    break;
                default:
                    string message = $"WeaponFactoryMedieval - no class found for weapon: {weapon}";
                    GameLogger.Log(message, System.Diagnostics.TraceEventType.Error);
                    throw new ArgumentException(message);
            }

            GameLogger.Log($"{this.GetType().Name} - created weapon: \"{weaponObject.Name}\"", TraceEventType.Information);
            return weaponObject;
        }
    }
}
