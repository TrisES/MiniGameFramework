using MiniGameFramework.Items.Armor.Interfaces;

namespace MiniGameFramework.Items.Armor.Factory
{
    public interface IArmorFactoryMethod
    {
        IArmor CreateArmor(string armor);
    }
}
