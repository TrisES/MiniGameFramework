using MiniGameFramework.Creatures;

namespace MiniGameFramework.Items
{
    public interface IEquipable
    {
        void Equip(Creature user);
        void Unequip(Creature user);
    }
}
