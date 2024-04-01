using MiniGameFramework.Creatures;

namespace MiniGameFramework.Items
{
    public interface IItem
    {
        string Name { get; set; }

        void Use(Creature user);
    }
}
