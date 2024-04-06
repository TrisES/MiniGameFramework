using MiniGameFramework.Items.Weapons.Interfaces;

namespace MiniGameFramework.Items.Weapons.Factory
{
    public interface IWeaponFactoryMethod
    {
        IWeapon CreateWeapon(WeaponEnum weapon);
    }
}
